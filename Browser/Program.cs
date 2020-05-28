using EasyTabs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Browser
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppContainer container = new AppContainer();

            //Add the initial Tab
            container.Tabs.Add(
                //The first tab created by default in the App will have the content as frmBrowser
                new TitleBarTab(container)
                {
                    Content = new frmBrowser
                    {
                        Text = "New Tab"
                    }
                }
            );

            //Set initial tab to the first one
            container.SelectedTabIndex = 0;

            //Create tabs and start the app
            TitleBarTabsApplicationContext applicationContext = new TitleBarTabsApplicationContext();
            applicationContext.Start(container);
            Application.Run(applicationContext);
        }
    }
}
