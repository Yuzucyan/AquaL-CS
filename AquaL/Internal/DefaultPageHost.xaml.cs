using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AquaL.Internal
{
    /// <summary>
    /// DefaultPageHost.xaml 的交互逻辑
    /// </summary>
    public partial class DefaultPageHost : Window
    {
        /// <summary>
        /// 加载的页面
        /// </summary>
        Page LoadContent = null;
        /// <summary>
        /// 主题颜色
        /// </summary>
        public Color ThemeColor
        {
            get
            {
                return themeColor;
            }
            set
            {
                themeColor = value;
                WindowActivated(null, null);
            }
        } 
        Color themeColor = Color.FromArgb(255, 231, 72, 86);
        /// <summary>
        /// 窗口标题
        /// </summary>
        public string WindowTitle
        {
            get
            {
                return windowTitle;
            }
            set
            {
                windowTitle = value;
                this.Title = value;
                this.title.Content = value;
            }
        }
        string windowTitle = "AquaL";
        /// <summary>
        /// 窗口宽度
        /// </summary>
        public double WindowWidth
        {
            get { return this.Width; }
            set { this.Width = value; }
        }
        /// <summary>
        /// 窗口高度
        /// </summary>
        public double WindowHeight
        {
            get { return this.Height; }
            set { this.Height = value; } }
        /// <summary>
        /// 是否需要隐藏标题栏颜色
        /// </summary>
        public bool HideTitleBar
        {
            get
            {
                return hTitleBar;
            }
            set
            {
                if (value)
                {
                    Titler.Background = new SolidColorBrush(Colors.Transparent);
                    hTitleBar = value;
                    content.Margin = new Thickness(1, 0, 0, 0);
                }
                else
                {
                    Titler.Background = new SolidColorBrush(ThemeColor);
                    hTitleBar = value;
                    content.Margin = new Thickness(1, 30, 0, 0);
                }
            }
        }
        bool hTitleBar = false;

        public DefaultPageHost(Page content)
        {
            InitializeComponent();
            LoadContent = content;
        }

        public DefaultPageHost()
        {
            InitializeComponent();
            LoadContent = new DefaultFrameHost();
        }

        private void Window_Move(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void WindowActivated(object sender, EventArgs e)
        {
            Body.Effect = new DropShadowEffect() { Direction = 270, ShadowDepth = 0, Color = ThemeColor, RenderingBias = RenderingBias.Performance, Opacity = 0.3, BlurRadius = 10 };
            WindowBorder.BorderBrush = new SolidColorBrush(ThemeColor);
            if (!HideTitleBar)
                Titler.Background = new SolidColorBrush(ThemeColor);
        }

        private void WindowDeactivated(object sender, EventArgs e)
        {
            Body.Effect = new DropShadowEffect() { Direction = 270, ShadowDepth = 0, Color = Colors.Gray, RenderingBias = RenderingBias.Performance, Opacity = 0.3, BlurRadius = 10 };
            WindowBorder.BorderBrush = new SolidColorBrush(Colors.Gray);
            if (!HideTitleBar)
                Titler.Background = new SolidColorBrush(Colors.Gray);
        }

        public void SetThemeColor(Color themeColor)
        {
            ThemeColor = themeColor;
            Body.Effect = new DropShadowEffect() { Direction = 270, ShadowDepth = 0, Color = ThemeColor, RenderingBias = RenderingBias.Performance, Opacity = 0.3, BlurRadius = 10 };
            WindowBorder.BorderBrush = new SolidColorBrush(ThemeColor);
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            this.content.Content = LoadContent;
        }
        /// <summary>
        /// 关闭窗口
        /// </summary>
        public void CloseWindow()
        {
            this.Close();
        }
    }
}
