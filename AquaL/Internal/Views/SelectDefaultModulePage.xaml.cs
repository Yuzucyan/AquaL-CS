using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AquaL.Internal.Views
{
    /// <summary>
    /// SelectDefaultModulePage.xaml 的交互逻辑
    /// </summary>
    public partial class SelectDefaultModulePage : Page
    {
        public SelectDefaultModulePage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Api.Tools.PageHost host = new Api.Tools.PageHost(this);
            host.Width = 550;
            host.Height = 592;
            host.Title = "打开方式";
        }
    }
}
