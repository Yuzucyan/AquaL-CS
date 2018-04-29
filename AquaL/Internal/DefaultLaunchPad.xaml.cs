using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace AquaL.Internal
{
    /// <summary>
    /// DefaultLaunchPad.xaml 的交互逻辑
    /// </summary>
    public partial class DefaultFrameHost : Page
    {
        public DefaultFrameHost()
        {
            InitializeComponent();
        }
        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            SwitchBackground();
            Api.Tools.PageHost host = new Api.Tools.PageHost(this);
            host.HideTitleBar = true;
            host.ThemeColor = Color.FromArgb(255, 0, 122, 204);

            DefaultPageHost dph = new DefaultPageHost(new Views.SelectDefaultModulePage());
            dph.Show();

        }

        void SwitchBackground()
        {
            // 加载背景图片
            if (Directory.Exists("Backgrounds"))
            {
                // TODO 判断程序目录下是否存在Backgrounds文件夹，
                //      如果有则遍历文件夹内所有文件并随机一张jpg /png/jpeg/bmp作为壁纸
                DirectoryInfo dirInfo = new DirectoryInfo("Backgrounds"); // 获取目录
                FileInfo[] filesInfo = dirInfo.GetFiles(); // 获取文件列表
                List<FileInfo> caseFilesInfo = new List<FileInfo>(); // 图片列表
                                                                     // 遍历文件
                foreach (FileInfo fi in filesInfo)
                {
                    // 判断是否为图片后缀名
                    if (fi.Extension == ".png" || fi.Extension == ".jpg"
                        || fi.Extension == ".jpeg" || fi.Extension == ".bmp")
                        caseFilesInfo.Add(fi);
                }
                // 如果图片列表不为空则随机一张图片
                if (caseFilesInfo.Count != 0)
                {
                    int randomSelectImageIndex = 0;
                    Random rd = new Random();
                    randomSelectImageIndex = rd.Next(0, caseFilesInfo.Count);
                    // 加载图片并设置为壁纸
                    BitmapImage bm = new BitmapImage(new Uri(caseFilesInfo[randomSelectImageIndex].FullName, UriKind.Absolute));
                    backgroundTop.Source = bm;
                    backgroundBottom.Source = bm;
                }

            }
        }
    }
}
