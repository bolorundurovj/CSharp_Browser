using EasyTabs;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Browser
{
    public partial class frmBrowser : Form
    {
        public frmBrowser()
        {
            InitializeComponent();
            //Upgrade the default web browser
            var appName = System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe";
            using (var Key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true))
            Key.SetValue(appName, 99999, RegistryValueKind.DWord);

            //Open Google by Default
            webBrowser1.Navigate("https://www.google.com/");
            
        }

        //Declare Parent Tabs
        protected TitleBarTabs ParentTabs
        {
            get
            {
                return (ParentForm as TitleBarTabs);
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            btnRefresh.Image = imgRefresh.Image;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoBack) webBrowser1.GoBack();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoForward) webBrowser1.GoForward();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.google.com/");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            btnRefresh.Image = imgSpinner.Image;
        }

        private void txtSearchOnUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtSearchOnUrl.Text.Trim().Length > 0)
            {
                //Detect Url
                if (txtSearchOnUrl.Text.Contains("."))
                {
                    //Its a URL
                    webBrowser1.Navigate(txtSearchOnUrl.Text.Trim());
                }
                else
                {
                    //Its a search item
                    webBrowser1.Navigate("https://www.google.com/search?q=" + txtSearchOnUrl.Text.Trim().Replace(" ", "+") + "&oq=joe&aqs=chrome..69i57j46l5j69i60l2.713j0j9&sourceid=chrome&ie=UTF-8");
                };
            }
        }
    }
}
