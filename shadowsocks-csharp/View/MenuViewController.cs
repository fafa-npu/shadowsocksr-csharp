﻿using Shadowsocks.Controller;
using Shadowsocks.Model;
using Shadowsocks.Properties;
using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using System.Threading;
using System.Text.RegularExpressions;

namespace Shadowsocks.View
{
    public class MenuViewController
    {
        // yes this is just a menu view controller
        // when config form is closed, it moves away from RAM
        // and it should just do anything related to the config form

        private ShadowsocksController controller;
        private UpdateFreeNode updateFreeNodeChecker;

        private NotifyIcon _notifyIcon;
        private ContextMenu contextMenu1;

        private MenuItem noModifyItem;
        private MenuItem enableItem;
        private MenuItem PACModeItem;
        private MenuItem globalModeItem;
        private MenuItem modeItem;

        private MenuItem ruleBypassLan;
        private MenuItem ruleBypassChina;
        private MenuItem ruleBypassNotChina;
        private MenuItem ruleDisableBypass;

        private MenuItem SeperatorItem;
        private MenuItem ServersItem;
        private MenuItem SelectRandomItem;
        private MenuItem sameHostForSameTargetItem;
        private ConfigForm configForm;
        private SettingsForm settingsForm;
        private ServerLogForm serverLogForm;
        private PortSettingsForm portMapForm;
        private SubscribeForm subScribeForm;
        private LogForm logForm;
        private string _urlToOpen;

        public MenuViewController(ShadowsocksController controller)
        {
            this.controller = controller;

            LoadMenu();

            controller.ToggleModeChanged += controller_ToggleModeChanged;
            controller.ToggleRuleModeChanged += controller_ToggleRuleModeChanged;
            controller.ConfigChanged += controller_ConfigChanged;
            controller.PACFileReadyToOpen += controller_FileReadyToOpen;
            controller.UserRuleFileReadyToOpen += controller_FileReadyToOpen;
            controller.Errored += controller_Errored;
            controller.UpdatePACFromGFWListCompleted += controller_UpdatePACFromGFWListCompleted;
            controller.UpdatePACFromGFWListError += controller_UpdatePACFromGFWListError;
            controller.ShowConfigFormEvent += Config_Click;

            _notifyIcon = new NotifyIcon();
            UpdateTrayIcon();
            _notifyIcon.Visible = true;
            _notifyIcon.ContextMenu = contextMenu1;
            _notifyIcon.MouseClick += notifyIcon1_Click;
            //_notifyIcon.MouseDoubleClick += notifyIcon1_DoubleClick;

            updateFreeNodeChecker = new UpdateFreeNode();
            updateFreeNodeChecker.NewFreeNodeFound += updateFreeNodeChecker_NewFreeNodeFound;

            LoadCurrentConfiguration();

            Configuration cfg = controller.GetCurrentConfiguration();
            if (cfg.isDefaultConfig() || cfg.nodeFeedAutoUpdate)
            {
                updateFreeNodeChecker.CheckUpdate(controller.GetCurrentConfiguration(), !cfg.isDefaultConfig());
            }

        }

        void controller_Errored(object sender, System.IO.ErrorEventArgs e)
        {
            MessageBox.Show(e.GetException().ToString(), String.Format(I18N.GetString("Shadowsocks Error: {0}"), e.GetException().Message));
        }

        private void UpdateTrayIcon()
        {
            int dpi;
            using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
            {
                dpi = (int)graphics.DpiX;
            }
            Configuration config = controller.GetCurrentConfiguration();
            bool enabled = config.sysProxyMode != (int)ProxyMode.NoModify && config.sysProxyMode != (int)ProxyMode.Direct;
            bool global = config.sysProxyMode == (int)ProxyMode.Global;
            bool random = config.random;

            Bitmap icon = null;
            try
            {
                icon = new Bitmap("icon.png");
            }
            catch
            {
                if (dpi < 97)
                {
                    // dpi = 96;
                    icon = Resources.ss16;
                }
                else if (dpi < 121)
                {
                    // dpi = 120;
                    icon = Resources.ss20;
                }
                else
                {
                    icon = Resources.ss24;
                }
                double mul_a = 1.0, mul_r = 1.0, mul_g = 1.0, mul_b = 1.0;
                if (!enabled)
                {
                    mul_g = 0.4;
                }
                else if (!global)
                {
                    mul_b = 0.4;
                    mul_g = 0.8;
                }
                if (!random)
                {
                    mul_r = 0.4;
                }

                {
                    Bitmap iconCopy = new Bitmap(icon);
                    for (int x = 0; x < iconCopy.Width; x++)
                    {
                        for (int y = 0; y < iconCopy.Height; y++)
                        {
                            Color color = icon.GetPixel(x, y);
                            iconCopy.SetPixel(x, y,
                                Color.FromArgb((byte)(color.A * mul_a),
                                ((byte)(color.R * mul_r)),
                                ((byte)(color.G * mul_g)),
                                ((byte)(color.B * mul_b))));
                        }
                    }
                    icon = iconCopy;
                }
            }
            _notifyIcon.Icon = Icon.FromHandle(icon.GetHicon());

            // we want to show more details but notify icon title is limited to 63 characters
            string text = (enabled ?
                    I18N.GetString("System Proxy On: ") + (global ? I18N.GetString("Global") : I18N.GetString("PAC")) :
                    String.Format(I18N.GetString("Running: Port {0}"), config.localPort))  // this feedback is very important because they need to know Shadowsocks is running
                    ;
            _notifyIcon.Text = text.Substring(0, Math.Min(63, text.Length));
        }

        private MenuItem CreateMenuItem(string text, EventHandler click)
        {
            return new MenuItem(I18N.GetString(text), click);
        }

        private MenuItem CreateMenuGroup(string text, MenuItem[] items)
        {
            return new MenuItem(I18N.GetString(text), items);
        }

        private void LoadMenu()
        {
            this.contextMenu1 = new ContextMenu(new MenuItem[] {
                modeItem = CreateMenuGroup("Mode", new MenuItem[] {
                    enableItem = CreateMenuItem("Disable system proxy", new EventHandler(this.EnableItem_Click)),
                    PACModeItem = CreateMenuItem("PAC", new EventHandler(this.PACModeItem_Click)),
                    globalModeItem = CreateMenuItem("Global", new EventHandler(this.GlobalModeItem_Click)),
                    new MenuItem("-"),
                    noModifyItem = CreateMenuItem("No modify system proxy", new EventHandler(this.NoModifyItem_Click))
                }),
                CreateMenuGroup("PAC ", new MenuItem[] {
                    CreateMenuItem("Update local PAC from Lan IP list", new EventHandler(this.UpdatePACFromLanIPListItem_Click)),
                    new MenuItem("-"),
                    CreateMenuItem("Update local PAC from Chn White list", new EventHandler(this.UpdatePACFromCNWhiteListItem_Click)),
                    CreateMenuItem("Update local PAC from Chn IP list", new EventHandler(this.UpdatePACFromCNIPListItem_Click)),
                    CreateMenuItem("Update local PAC from GFWList", new EventHandler(this.UpdatePACFromGFWListItem_Click)),
                    new MenuItem("-"),
                    CreateMenuItem("Update local PAC from Chn Only list", new EventHandler(this.UpdatePACFromCNOnlyListItem_Click)),
                    new MenuItem("-"),
                    CreateMenuItem("Copy PAC URL", new EventHandler(this.CopyPACURLItem_Click)),
                    CreateMenuItem("Edit local PAC file...", new EventHandler(this.EditPACFileItem_Click)),
                    CreateMenuItem("Edit user rule for GFWList...", new EventHandler(this.EditUserRuleFileForGFWListItem_Click)),
                }),
                CreateMenuGroup("Proxy rule", new MenuItem[] {
                    ruleBypassLan = CreateMenuItem("Bypass LAN", new EventHandler(this.RuleBypassLanItem_Click)),
                    ruleBypassChina = CreateMenuItem("Bypass LAN && China", new EventHandler(this.RuleBypassChinaItem_Click)),
                    ruleBypassNotChina = CreateMenuItem("Bypass LAN && not China", new EventHandler(this.RuleBypassNotChinaItem_Click)),
                    new MenuItem("-"),
                    ruleDisableBypass = CreateMenuItem("Disable bypass", new EventHandler(this.RuleBypassDisableItem_Click)),
                }),
                new MenuItem("-"),
                ServersItem = CreateMenuGroup("Servers", new MenuItem[] {
                    SeperatorItem = new MenuItem("-"),
                    CreateMenuItem("Edit servers...", new EventHandler(this.Config_Click)),
                    CreateMenuItem("Import servers from file...", new EventHandler(this.Import_Click)),
                    new MenuItem("-"),
                    CreateMenuItem("Subscribe setting...", new EventHandler(this.SubscribeSetting_Click)),
                    CreateMenuItem("Update subscribe SSR node", new EventHandler(this.CheckNodeUpdate_Click)),
                    CreateMenuItem("Update subscribe SSR node(bypass proxy)", new EventHandler(this.CheckNodeUpdateBypassProxy_Click)),
                    new MenuItem("-"),
                    SelectRandomItem = CreateMenuItem("Load balance", new EventHandler(this.SelectRandomItem_Click)),
                    sameHostForSameTargetItem = CreateMenuItem("Same host for same address", new EventHandler(this.SelectSameHostForSameTargetItem_Click)),
                    new MenuItem("-"),
                    //CreateMenuItem("Server statistic...", new EventHandler(this.ShowServerLogItem_Click)),
                    CreateMenuItem("Disconnect current", new EventHandler(this.DisconnectCurrent_Click)),
                }),
                //SelectRandomItem = CreateMenuItem("Load balance", new EventHandler(this.SelectRandomItem_Click)),
                CreateMenuItem("Server statistic...", new EventHandler(this.ShowServerLogItem_Click)),
                new MenuItem("-"),
                CreateMenuItem("Global settings...", new EventHandler(this.Setting_Click)),
                CreateMenuItem("Port settings...", new EventHandler(this.ShowPortMapItem_Click)),
                new MenuItem("-"),
                CreateMenuItem("Scan QRCode from screen...", new EventHandler(this.ScanQRCodeItem_Click)),
                CreateMenuItem("Import SSR links from clipboard...", new EventHandler(this.CopyAddress_Click)),
                new MenuItem("-"),
                CreateMenuGroup("Help", new MenuItem[] {
                    //CreateMenuItem("Open wiki...", new EventHandler(this.OpenWiki_Click)),
                    CreateMenuItem("Show logs...", new EventHandler(this.ShowLogItem_Click)),
                    //CreateMenuItem("Feedback...", new EventHandler(this.FeedbackItem_Click)),
					new MenuItem("-"),
                    //CreateMenuItem("Gen custom QRCode...", new EventHandler(this.showURLFromQRCode)),
                    //CreateMenuItem("Reset password...", new EventHandler(this.ResetPasswordItem_Click)),
                    //new MenuItem("-"),
                    CreateMenuItem("About...", new EventHandler(this.AboutItem_Click)),
                    CreateMenuItem("Donate...", new EventHandler(this.DonateItem_Click)),
                    new MenuItem("-"),
                    CreateMenuItem("rixCloud...", new EventHandler(this.GorixCloud_Click)),
                }),
                CreateMenuItem("Quit", new EventHandler(this.Quit_Click))
            });
        }

        private void controller_ConfigChanged(object sender, EventArgs e)
        {
            LoadCurrentConfiguration();
            UpdateTrayIcon();
        }

        private void controller_ToggleModeChanged(object sender, EventArgs e)
        {
            Configuration config = controller.GetCurrentConfiguration();
            UpdateSysProxyMode(config);
        }

        private void controller_ToggleRuleModeChanged(object sender, EventArgs e)
        {
            Configuration config = controller.GetCurrentConfiguration();
            UpdateProxyRule(config);
        }

        void controller_FileReadyToOpen(object sender, ShadowsocksController.PathEventArgs e)
        {
            string argument = @"/select, " + e.Path;

            System.Diagnostics.Process.Start("explorer.exe", argument);
        }

        void ShowBalloonTip(string title, string content, ToolTipIcon icon, int timeout)
        {
            _notifyIcon.BalloonTipTitle = title;
            _notifyIcon.BalloonTipText = content;
            _notifyIcon.BalloonTipIcon = icon;
            _notifyIcon.ShowBalloonTip(timeout);
        }

        void controller_UpdatePACFromGFWListError(object sender, System.IO.ErrorEventArgs e)
        {
            GFWListUpdater updater = (GFWListUpdater)sender;
            ShowBalloonTip(I18N.GetString("Failed to update PAC file"), e.GetException().Message, ToolTipIcon.Error, 5000);
            Logging.LogUsefulException(e.GetException());
        }

        void controller_UpdatePACFromGFWListCompleted(object sender, GFWListUpdater.ResultEventArgs e)
        {
            GFWListUpdater updater = (GFWListUpdater)sender;
            string result = e.Success ?
                (updater.update_type <= 1 ? I18N.GetString("PAC updated") : I18N.GetString("Domain white list list updated"))
                : I18N.GetString("No updates found. Please report to GFWList if you have problems with it.");
            ShowBalloonTip(I18N.GetString("Shadowsocks"), result, ToolTipIcon.Info, 1000);
        }

        void updateFreeNodeChecker_NewFreeNodeFound(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(updateFreeNodeChecker.FreeNodeResult))
            {
                List<string> urls = new List<string>();
                updateFreeNodeChecker.FreeNodeResult.TrimEnd('\r', '\n', ' ');
                Configuration config = controller.GetCurrentConfiguration();
                Server selected_server = null;
                if (config.index >= 0 && config.index < config.configs.Count)
                {
                    selected_server = config.configs[config.index];
                }
                try
                {
                    updateFreeNodeChecker.FreeNodeResult = Util.Base64.DecodeBase64(updateFreeNodeChecker.FreeNodeResult);
                }
                catch
                {
                }
                int max_node_num = 0;

                Match match_maxnum = Regex.Match(updateFreeNodeChecker.FreeNodeResult, "^MAX=([0-9]+)");
                if (match_maxnum.Success)
                {
                    try
                    {
                        max_node_num = Convert.ToInt32(match_maxnum.Groups[1].Value, 10);
                    }
                    catch
                    {

                    }
                }
                URL_Split(updateFreeNodeChecker.FreeNodeResult, ref urls);
                int count = 0;
                for (int i = urls.Count - 1; i >= 0; --i)
                {
                    if (!urls[i].StartsWith("ss"))
                        urls.RemoveAt(i);
                }
                if (urls.Count > 0)
                {
                    if (max_node_num <= 0 || max_node_num >= urls.Count)
                    {
                        urls.Reverse();
                    }
                    else
                    {
                        Random r = new Random();
                        Util.Utils.Shuffle(urls, r);
                        urls.RemoveRange(max_node_num, urls.Count - max_node_num);
                    }
                    foreach (string url in urls)
                    {
                        try // try get group name
                        {
                            Server server = new Server(url, null);
                            if (!String.IsNullOrEmpty(server.group))
                            {
                                config.nodeFeedGroup = server.group;
                                break;
                            }
                        }
                        catch
                        { }
                    }
                    if (String.IsNullOrEmpty(config.nodeFeedGroup))
                    {
                        config.nodeFeedGroup = config.nodeFeedURL;
                    }

                    for (int i = config.configs.Count - 1; i >= 0; --i)
                    {
                        if (config.configs[i].id == selected_server.id && config.nodeFeedGroup == selected_server.group)
                        {
                            bool match = false;
                            for (int j = 0; j < urls.Count; ++j)
                            {
                                try // try get group name
                                {
                                    Server server = new Server(urls[j], null);
                                    {
                                        if (selected_server.isMatchServer(server))
                                        {
                                            match = true;
                                            urls.RemoveAt(j);
                                            break;
                                        }
                                    }
                                }
                                catch
                                { }
                            }
                            if (match)
                            {
                                config.configs.RemoveAt(i);
                                config.configs.Add(selected_server);
                            }
                            else
                            {
                                urls.RemoveAt(0);
                            }
                        }
                        if (config.configs[i].id != selected_server.id && config.configs[i].group == config.nodeFeedGroup)
                        {
                            config.configs.RemoveAt(i);
                        }
                    }
                    controller.SaveServersConfig(config);
                    foreach (string url in urls)
                    {
                        if (controller.AddServerBySSURL(url, config.nodeFeedGroup, true))
                            ++count;
                    }
                    config = controller.GetCurrentConfiguration();
                    if (selected_server != null)
                    {
                        bool match = false;
                        for (int i = config.configs.Count - 1; i >= 0; --i)
                        {
                            if (config.configs[i].id == selected_server.id)
                            {
                                config.index = i;
                                match = true;
                                break;
                            }
                            else if (config.configs[i].group == selected_server.group)
                            {
                                if (config.configs[i].isMatchServer(selected_server))
                                {
                                    config.index = i;
                                    match = true;
                                    break;
                                }
                            }
                        }
                        if (!match)
                        {
                            config.index = config.configs.Count - 1;
                        }
                    }
                    else
                    {
                        config.index = config.configs.Count - 1;
                    }
                    controller.SaveServersConfig(config);

                    if (count > 0)
                    {
                        ShowBalloonTip(I18N.GetString("Success"),
                            I18N.GetString("Update subscribe SSR node success"), ToolTipIcon.Info, 10000);
                        return;
                    }
                }
            }
            ShowBalloonTip(I18N.GetString("Error"),
                I18N.GetString("Update subscribe SSR node failure"), ToolTipIcon.Info, 10000);
        }


        void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start(updateChecker.LatestVersionURL);
            _notifyIcon.BalloonTipClicked -= notifyIcon1_BalloonTipClicked;
        }

        private void UpdateSysProxyMode(Configuration config)
        {
            noModifyItem.Checked = config.sysProxyMode == (int)ProxyMode.NoModify;
            enableItem.Checked = config.sysProxyMode == (int)ProxyMode.Direct;
            PACModeItem.Checked = config.sysProxyMode == (int)ProxyMode.Pac;
            globalModeItem.Checked = config.sysProxyMode == (int)ProxyMode.Global;
        }

        private void UpdateProxyRule(Configuration config)
        {
            ruleDisableBypass.Checked = config.proxyRuleMode == (int)ProxyRuleMode.Disable;
            ruleBypassLan.Checked = config.proxyRuleMode == (int)ProxyRuleMode.BypassLan;
            ruleBypassChina.Checked = config.proxyRuleMode == (int)ProxyRuleMode.BypassLanAndChina;
            ruleBypassNotChina.Checked = config.proxyRuleMode == (int)ProxyRuleMode.BypassLanAndNotChina;
        }

        private void LoadCurrentConfiguration()
        {
            Configuration config = controller.GetCurrentConfiguration();
            UpdateServersMenu();
            UpdateSysProxyMode(config);

            UpdateProxyRule(config);

            SelectRandomItem.Checked = config.random;
            sameHostForSameTargetItem.Checked = config.sameHostForSameTarget;
        }

        private void UpdateServersMenu()
        {
            var items = ServersItem.MenuItems;
            while (items[0] != SeperatorItem)
            {
                items.RemoveAt(0);
            }

            Configuration configuration = controller.GetCurrentConfiguration();
            SortedDictionary<string, MenuItem> group = new SortedDictionary<string, MenuItem>();
            const string def_group = "!(no group)";
            string select_group = "";
            for (int i = 0; i < configuration.configs.Count; i++)
            {
                string group_name;
                Server server = configuration.configs[i];
                if (string.IsNullOrEmpty(server.group))
                    group_name = def_group;
                else
                    group_name = server.group;

                MenuItem item = new MenuItem(server.FriendlyName());
                item.Tag = i;
                item.Click += AServerItem_Click;
                if (configuration.index == i)
                {
                    item.Checked = true;
                    select_group = group_name;
                }

                if (group.ContainsKey(group_name))
                {
                    group[group_name].MenuItems.Add(item);
                }
                else
                {
                    group[group_name] = new MenuItem(group_name, new MenuItem[1] { item });
                }
            }
            {
                int i = 0;
                foreach (KeyValuePair<string, MenuItem> pair in group)
                {
                    if (pair.Key == def_group)
                    {
                        pair.Value.Text = "(empty group)";
                    }
                    if (pair.Key == select_group)
                    {
                        pair.Value.Text = "● " + pair.Value.Text;
                    }
                    else
                    {
                        pair.Value.Text = "　" + pair.Value.Text;
                    }
                    items.Add(i, pair.Value);
                    ++i;
                }
            }
        }

        private void ShowConfigForm(bool addNode)
        {
            if (configForm != null)
            {
                configForm.Activate();
                if (addNode)
                {
                    Configuration cfg = controller.GetCurrentConfiguration();
                    configForm.SetServerListSelectedIndex(cfg.index + 1);
                }
            }
            else
            {
                configForm = new ConfigForm(controller, addNode ? -1 : -2);
                configForm.Show();
                configForm.Activate();
                configForm.BringToFront();
                configForm.FormClosed += configForm_FormClosed;
            }
        }

        private void ShowConfigForm(int index)
        {
            if (configForm != null)
            {
                configForm.Activate();
            }
            else
            {
                configForm = new ConfigForm(controller, index);
                configForm.Show();
                configForm.Activate();
                configForm.BringToFront();
                configForm.FormClosed += configForm_FormClosed;
            }
        }

        private void ShowSettingForm()
        {
            if (settingsForm != null)
            {
                settingsForm.Activate();
            }
            else
            {
                settingsForm = new SettingsForm(controller);
                settingsForm.Show();
                settingsForm.Activate();
                settingsForm.BringToFront();
                settingsForm.FormClosed += settingsForm_FormClosed;
            }
        }

        private void ShowPortMapForm()
        {
            if (portMapForm != null)
            {
                portMapForm.Activate();
                portMapForm.Update();
                if (portMapForm.WindowState == FormWindowState.Minimized)
                {
                    portMapForm.WindowState = FormWindowState.Normal;
                }
            }
            else
            {
                portMapForm = new PortSettingsForm(controller);
                portMapForm.Show();
                portMapForm.Activate();
                portMapForm.BringToFront();
                portMapForm.FormClosed += portMapForm_FormClosed;
            }
        }

        private void ShowServerLogForm()
        {
            if (serverLogForm != null)
            {
                serverLogForm.Activate();
                serverLogForm.Update();
                if (serverLogForm.WindowState == FormWindowState.Minimized)
                {
                    serverLogForm.WindowState = FormWindowState.Normal;
                }
            }
            else
            {
                serverLogForm = new ServerLogForm(controller);
                serverLogForm.Show();
                serverLogForm.Activate();
                serverLogForm.BringToFront();
                serverLogForm.FormClosed += serverLogForm_FormClosed;
            }
        }

        private void ShowGlobalLogForm()
        {
            if (logForm != null)
            {
                logForm.Activate();
                logForm.Update();
                if (logForm.WindowState == FormWindowState.Minimized)
                {
                    logForm.WindowState = FormWindowState.Normal;
                }
            }
            else
            {
                logForm = new LogForm(controller);
                logForm.Show();
                logForm.Activate();
                logForm.BringToFront();
                logForm.FormClosed += globalLogForm_FormClosed;
            }
        }

        private void ShowSubscribeSettingForm()
        {
            if (subScribeForm != null)
            {
                subScribeForm.Activate();
                subScribeForm.Update();
                if (subScribeForm.WindowState == FormWindowState.Minimized)
                {
                    subScribeForm.WindowState = FormWindowState.Normal;
                }
            }
            else
            {
                subScribeForm = new SubscribeForm(controller);
                subScribeForm.Show();
                subScribeForm.Activate();
                subScribeForm.BringToFront();
                subScribeForm.FormClosed += subScribeForm_FormClosed;
            }
        }

        void configForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            configForm = null;
            Util.Utils.ReleaseMemory();
        }

        void settingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            settingsForm = null;
            Util.Utils.ReleaseMemory();
        }

        void serverLogForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            serverLogForm = null;
            Util.Utils.ReleaseMemory();
        }

        void portMapForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            portMapForm = null;
            Util.Utils.ReleaseMemory();
        }

        void globalLogForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            logForm = null;
            Util.Utils.ReleaseMemory();
        }

        void subScribeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            subScribeForm = null;
        }

        private void Config_Click(object sender, EventArgs e)
        {
            if (typeof(int) == sender.GetType())
            {
                ShowConfigForm((int)sender);
            }
            else
            {
                ShowConfigForm(false);
            }
        }

        private void Import_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = System.Windows.Forms.Application.StartupPath;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string name = dlg.FileName;
                Configuration cfg = Configuration.LoadFile(name);
                if (cfg.configs.Count == 1 && cfg.configs[0].server == Configuration.GetDefaultServer().server)
                {
                    MessageBox.Show("Load config file failed", "ShadowsocksR");
                }
                else
                {
                    controller.MergeConfiguration(cfg);
                    LoadCurrentConfiguration();
                }
            }
        }

        private void Setting_Click(object sender, EventArgs e)
        {
            ShowSettingForm();
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            controller.Stop();
            if (configForm != null)
            {
                configForm.Close();
                configForm = null;
            }
            if (serverLogForm != null)
            {
                serverLogForm.Close();
                serverLogForm = null;
            }
            _notifyIcon.Visible = false;
            Application.Exit();
        }

        private void OpenWiki_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/breakwa11/shadowsocks-rss/wiki");
        }

        private void FeedbackItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/shadowsocksr/shadowsocksr-csharp/issues/new");
        }

        private void ResetPasswordItem_Click(object sender, EventArgs e)
        {
            ResetPassword dlg = new ResetPassword();
            dlg.Show();
            dlg.Activate();
        }

        private void AboutItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://breakwa11.github.io");
        }

        private void DonateItem_Click(object sender, EventArgs e)
        {
            ShowBalloonTip(I18N.GetString("Donate"), I18N.GetString("Please contract to breakwa11 to get more infomation"), ToolTipIcon.Info, 10000);
        }

        private void GorixCloud_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.rixCloud.com");
        }

        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);

        private void notifyIcon1_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int SCA_key = GetAsyncKeyState(Keys.ShiftKey) < 0 ? 1 : 0;
                SCA_key |= GetAsyncKeyState(Keys.ControlKey) < 0 ? 2 : 0;
                SCA_key |= GetAsyncKeyState(Keys.Menu) < 0 ? 4 : 0;
                if (SCA_key == 2)
                {
                    ShowServerLogForm();
                }
                else if (SCA_key == 1)
                {
                    ShowSettingForm();
                }
                else if (SCA_key == 4)
                {
                    ShowPortMapForm();
                }
                else
                {
                    ShowServerLogForm();
                }
            }
            else if (e.Button == MouseButtons.Middle)
            {
                ShowConfigForm(false);
            }
        }

        private void NoModifyItem_Click(object sender, EventArgs e)
        {
            controller.ToggleMode(ProxyMode.NoModify);
        }

        private void EnableItem_Click(object sender, EventArgs e)
        {
            controller.ToggleMode(ProxyMode.Direct);
        }

        private void GlobalModeItem_Click(object sender, EventArgs e)
        {
            controller.ToggleMode(ProxyMode.Global);
        }

        private void PACModeItem_Click(object sender, EventArgs e)
        {
            controller.ToggleMode(ProxyMode.Pac);
        }

        private void RuleBypassLanItem_Click(object sender, EventArgs e)
        {
            controller.ToggleRuleMode(1);
        }

        private void RuleBypassChinaItem_Click(object sender, EventArgs e)
        {
            controller.ToggleRuleMode(2);
        }

        private void RuleBypassNotChinaItem_Click(object sender, EventArgs e)
        {
            controller.ToggleRuleMode(3);
        }

        private void RuleBypassDisableItem_Click(object sender, EventArgs e)
        {
            controller.ToggleRuleMode(0);
        }

        private void SelectRandomItem_Click(object sender, EventArgs e)
        {
            SelectRandomItem.Checked = !SelectRandomItem.Checked;
            controller.ToggleSelectRandom(SelectRandomItem.Checked);
        }

        private void SelectSameHostForSameTargetItem_Click(object sender, EventArgs e)
        {
            sameHostForSameTargetItem.Checked = !sameHostForSameTargetItem.Checked;
            controller.ToggleSameHostForSameTargetRandom(sameHostForSameTargetItem.Checked);
        }

        private void CopyPACURLItem_Click(object sender, EventArgs e)
        {
            try
            {
                Configuration config = controller.GetCurrentConfiguration();
                string pacUrl;
                pacUrl = "http://127.0.0.1:" + config.localPort.ToString() + "/pac?" + "auth=" + config.localAuthPassword + "&t=" + Util.Utils.GetTimestamp(DateTime.Now);
                Clipboard.SetText(pacUrl);
            }
            catch
            {

            }
        }

        private void EditPACFileItem_Click(object sender, EventArgs e)
        {
            controller.TouchPACFile();
        }

        private void UpdatePACFromGFWListItem_Click(object sender, EventArgs e)
        {
            controller.UpdatePACFromGFWList();
        }

        private void UpdatePACFromLanIPListItem_Click(object sender, EventArgs e)
        {
            controller.UpdatePACFromOnlinePac("https://raw.githubusercontent.com/breakwa11/breakwa11.github.io/master/ssr/ss_lanip.pac");
        }

        private void UpdatePACFromCNWhiteListItem_Click(object sender, EventArgs e)
        {
            controller.UpdatePACFromOnlinePac("https://raw.githubusercontent.com/breakwa11/breakwa11.github.io/master/ssr/ss_white.pac");
        }

        private void UpdatePACFromCNOnlyListItem_Click(object sender, EventArgs e)
        {
            controller.UpdatePACFromOnlinePac("https://raw.githubusercontent.com/breakwa11/breakwa11.github.io/master/ssr/ss_white_r.pac");
        }

        private void UpdatePACFromCNIPListItem_Click(object sender, EventArgs e)
        {
            controller.UpdatePACFromOnlinePac("https://raw.githubusercontent.com/breakwa11/breakwa11.github.io/master/ssr/ss_cnip.pac");
        }

        private void EditUserRuleFileForGFWListItem_Click(object sender, EventArgs e)
        {
            controller.TouchUserRuleFile();
        }

        private void AServerItem_Click(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            controller.SelectServerIndex((int)item.Tag);
        }

        private void CheckNodeUpdate_Click(object sender, EventArgs e)
        {
            updateFreeNodeChecker.CheckUpdate(controller.GetCurrentConfiguration(), true);
        }

        private void CheckNodeUpdateBypassProxy_Click(object sender, EventArgs e)
        {
            updateFreeNodeChecker.CheckUpdate(controller.GetCurrentConfiguration(), false);
        }

        private void ShowLogItem_Click(object sender, EventArgs e)
        {
            ShowGlobalLogForm();
        }

        private void ShowPortMapItem_Click(object sender, EventArgs e)
        {
            ShowPortMapForm();
        }

        private void ShowServerLogItem_Click(object sender, EventArgs e)
        {
            ShowServerLogForm();
        }

        private void SubscribeSetting_Click(object sender, EventArgs e)
        {
            ShowSubscribeSettingForm();
        }

        private void DisconnectCurrent_Click(object sender, EventArgs e)
        {
            Configuration config = controller.GetCurrentConfiguration();
            for (int id = 0; id < config.configs.Count; ++id)
            {
                Server server = config.configs[id];
                server.GetConnections().CloseAll();
            }
        }

        private void URL_Split(string text, ref List<string> out_urls)
        {
            if (String.IsNullOrEmpty(text))
            {
                return;
            }
            int ss_index = text.IndexOf("ss://", 1, StringComparison.OrdinalIgnoreCase);
            int ssr_index = text.IndexOf("ssr://", 1, StringComparison.OrdinalIgnoreCase);
            int index = ss_index;
            if (index == -1 || index > ssr_index && ssr_index != -1) index = ssr_index;
            if (index == -1)
            {
                out_urls.Insert(0, text);
            }
            else
            {
                out_urls.Insert(0, text.Substring(0, index));
                URL_Split(text.Substring(index), ref out_urls);
            }
        }

        private void CopyAddress_Click(object sender, EventArgs e)
        {
            try
            {
                IDataObject iData = Clipboard.GetDataObject();
                if (iData.GetDataPresent(DataFormats.Text))
                {
                    List<string> urls = new List<string>();
                    URL_Split((string)iData.GetData(DataFormats.Text), ref urls);
                    int count = 0;
                    foreach (string url in urls)
                    {
                        if (controller.AddServerBySSURL(url))
                            ++count;
                    }
                    if (count > 0)
                    {
                        Clipboard.Clear();
                        ShowConfigForm(true);
                    }
                }
            }
            catch
            {

            }
        }

        private bool ScanQRCode(Screen screen, Bitmap fullImage, Rectangle cropRect, out string url, out Rectangle rect)
        {
            Bitmap target = new Bitmap(cropRect.Width, cropRect.Height);

            using (Graphics g = Graphics.FromImage(target))
            {
                g.DrawImage(fullImage, new Rectangle(0, 0, cropRect.Width, cropRect.Height),
                                cropRect,
                                GraphicsUnit.Pixel);
            }
            var source = new BitmapLuminanceSource(target);
            var bitmap = new BinaryBitmap(new HybridBinarizer(source));
            QRCodeReader reader = new QRCodeReader();
            var result = reader.decode(bitmap);
            if (result != null)
            {
                url = result.Text;
                double minX = Int32.MaxValue, minY = Int32.MaxValue, maxX = 0, maxY = 0;
                foreach (ResultPoint point in result.ResultPoints)
                {
                    minX = Math.Min(minX, point.X);
                    minY = Math.Min(minY, point.Y);
                    maxX = Math.Max(maxX, point.X);
                    maxY = Math.Max(maxY, point.Y);
                }
                //rect = new Rectangle((int)minX, (int)minY, (int)(maxX - minX), (int)(maxY - minY));
                rect = new Rectangle(cropRect.Left + (int)minX, cropRect.Top + (int)minY, (int)(maxX - minX), (int)(maxY - minY));
                return true;
            }
            url = "";
            rect = new Rectangle();
            return false;
        }

        private bool ScanQRCodeStretch(Screen screen, Bitmap fullImage, Rectangle cropRect, double mul, out string url, out Rectangle rect)
        {
            Bitmap target = new Bitmap((int)(cropRect.Width * mul), (int)(cropRect.Height * mul));

            using (Graphics g = Graphics.FromImage(target))
            {
                g.DrawImage(fullImage, new Rectangle(0, 0, target.Width, target.Height),
                                cropRect,
                                GraphicsUnit.Pixel);
            }
            var source = new BitmapLuminanceSource(target);
            var bitmap = new BinaryBitmap(new HybridBinarizer(source));
            QRCodeReader reader = new QRCodeReader();
            var result = reader.decode(bitmap);
            if (result != null)
            {
                url = result.Text;
                double minX = Int32.MaxValue, minY = Int32.MaxValue, maxX = 0, maxY = 0;
                foreach (ResultPoint point in result.ResultPoints)
                {
                    minX = Math.Min(minX, point.X);
                    minY = Math.Min(minY, point.Y);
                    maxX = Math.Max(maxX, point.X);
                    maxY = Math.Max(maxY, point.Y);
                }
                //rect = new Rectangle((int)minX, (int)minY, (int)(maxX - minX), (int)(maxY - minY));
                rect = new Rectangle(cropRect.Left + (int)(minX / mul), cropRect.Top + (int)(minY / mul), (int)((maxX - minX) / mul), (int)((maxY - minY) / mul));
                return true;
            }
            url = "";
            rect = new Rectangle();
            return false;
        }

        private Rectangle GetScanRect(int width, int height, int index, out double stretch)
        {
            stretch = 1;
            if (index < 5)
            {
                const int div = 5;
                int w = width * 3 / div;
                int h = height * 3 / div;
                Point[] pt = new Point[5] {
                    new Point(1, 1),

                    new Point(0, 0),
                    new Point(0, 2),
                    new Point(2, 0),
                    new Point(2, 2),
                };
                return new Rectangle(pt[index].X * width / div, pt[index].Y * height / div, w, h);
            }
            {
                const int base_index = 5;
                if (index < base_index + 6)
                {
                    double[] s = new double[] {
                        1,
                        2,
                        3,
                        4,
                        6,
                        8
                    };
                    stretch = 1 / s[index - base_index];
                    return new Rectangle(0, 0, width, height);
                }
            }
            {
                const int base_index = 11;
                if (index < base_index + 8)
                {
                    const int hdiv = 7;
                    const int vdiv = 5;
                    int w = width * 3 / hdiv;
                    int h = height * 3 / vdiv;
                    Point[] pt = new Point[8] {
                        new Point(1, 1),
                        new Point(3, 1),

                        new Point(0, 0),
                        new Point(0, 2),

                        new Point(2, 0),
                        new Point(2, 2),

                        new Point(4, 0),
                        new Point(4, 2),
                    };
                    return new Rectangle(pt[index - base_index].X * width / hdiv, pt[index - base_index].Y * height / vdiv, w, h);
                }
            }
            return new Rectangle(0, 0, 0, 0);
        }

        private void ScanScreenQRCode(bool ss_only)
        {
            Thread.Sleep(100);
            foreach (Screen screen in Screen.AllScreens)
            {
                Point screen_size = Util.Utils.GetScreenPhysicalSize();
                using (Bitmap fullImage = new Bitmap(screen_size.X,
                                                screen_size.Y))
                {
                    using (Graphics g = Graphics.FromImage(fullImage))
                    {
                        g.CopyFromScreen(screen.Bounds.X,
                                         screen.Bounds.Y,
                                         0, 0,
                                         fullImage.Size,
                                         CopyPixelOperation.SourceCopy);
                    }
                    bool decode_fail = false;
                    for (int i = 0; i < 100; i++)
                    {
                        double stretch;
                        Rectangle cropRect = GetScanRect(fullImage.Width, fullImage.Height, i, out stretch);
                        if (cropRect.Width == 0)
                            break;

                        string url;
                        Rectangle rect;
                        if (stretch == 1 ? ScanQRCode(screen, fullImage, cropRect, out url, out rect) : ScanQRCodeStretch(screen, fullImage, cropRect, stretch, out url, out rect))
                        {
                            var success = controller.AddServerBySSURL(url);
                            QRCodeSplashForm splash = new QRCodeSplashForm();
                            if (success)
                            {
                                splash.FormClosed += splash_FormClosed;
                            }
                            else if (!ss_only)
                            {
                                _urlToOpen = url;
                                //if (url.StartsWith("http://") || url.StartsWith("https://"))
                                //    splash.FormClosed += openURLFromQRCode;
                                //else
                                splash.FormClosed += showURLFromQRCode;
                            }
                            else
                            {
                                decode_fail = true;
                                continue;
                            }
                            splash.Location = new Point(screen.Bounds.X, screen.Bounds.Y);
                            double dpi = Screen.PrimaryScreen.Bounds.Width / (double)screen_size.X;
                            splash.TargetRect = new Rectangle(
                                (int)(rect.Left * dpi + screen.Bounds.X),
                                (int)(rect.Top * dpi + screen.Bounds.Y),
                                (int)(rect.Width * dpi),
                                (int)(rect.Height * dpi));
                            splash.Size = new Size(fullImage.Width, fullImage.Height);
                            splash.Show();
                            return;
                        }
                    }
                    if (decode_fail)
                    {
                        MessageBox.Show(I18N.GetString("Failed to decode QRCode"));
                        return;
                    }
                }
            }
            MessageBox.Show(I18N.GetString("No QRCode found. Try to zoom in or move it to the center of the screen."));
        }

        private void ScanQRCodeItem_Click(object sender, EventArgs e)
        {
            ScanScreenQRCode(false);
        }

        void splash_FormClosed(object sender, FormClosedEventArgs e)
        {
            ShowConfigForm(true);
        }

        void openURLFromQRCode(object sender, FormClosedEventArgs e)
        {
            Process.Start(_urlToOpen);
        }

        void showURLFromQRCode()
        {
            ShowTextForm dlg = new ShowTextForm("QRCode", _urlToOpen);
            dlg.Show();
            dlg.Activate();
            dlg.BringToFront();
        }

        void showURLFromQRCode(object sender, FormClosedEventArgs e)
        {
            showURLFromQRCode();
        }

        void showURLFromQRCode(object sender, System.EventArgs e)
        {
            showURLFromQRCode();
        }
    }
}
