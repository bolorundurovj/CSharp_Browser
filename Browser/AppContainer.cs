using EasyTabs;
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
    public partial class AppContainer : TitleBarTabs
    {
        public AppContainer()
        {
            InitializeComponent();

            AeroPeekEnabled = true;
            TabRenderer = new ChromeTabRenderer(this);
        }

        // Handle Create New Tab Method
        public override TitleBarTab CreateTab()
        {
            {
                return new TitleBarTab(this)
                {
                    //The content will be an instance of another form...... Here it will be a new instance of frmBrowser
                    Content = new frmBrowser
                    {
                        Text = "VJ's Browser"
                    }
                };
            }
        }
    }
}
