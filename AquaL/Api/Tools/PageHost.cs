using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AquaL.Api.Tools
{
    /// <summary>
    /// 页面显示窗口工具
    /// </summary>
    class PageHost
    {
        /// <summary>
        /// 页面
        /// </summary>
        public Page Page { get; private set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="page"></param>
        public PageHost(Page page)
        {
            Page = page;
        }
        /// <summary>
        /// 是否隐藏窗口自带的标题栏
        /// </summary>
        public bool HideTitleBar
        {
            get
            {
                try { return (bool)Window.GetWindow(Page).GetType().GetProperty("HideTitleBar").GetValue(Window.GetWindow(Page)); }
                catch { return false; }
            }
            set
            {
                try { Window.GetWindow(Page).GetType().GetProperty("HideTitleBar").SetValue(Window.GetWindow(Page), value); }
                catch { }
            }
        }
        /// <summary>
        /// 窗口主题颜色
        /// </summary>
        public Color ThemeColor
        {
            get
            {
                try { return (Color)Window.GetWindow(Page).GetType().GetProperty("ThemeColor").GetValue(Window.GetWindow(Page)); }
                catch { return Color.FromArgb(255, 231, 72, 86); }
            }
            set
            {
                try { Window.GetWindow(Page).GetType().GetProperty("ThemeColor").SetValue(Window.GetWindow(Page), value); }
                catch { }
            }
        }
        /// <summary>
        /// 窗口宽度
        /// </summary>
        public double Width
        {
            get
            {
                try { return (double)Window.GetWindow(Page).GetType().GetProperty("WindowWidth").GetValue(Window.GetWindow(Page)); }
                catch { return 829; }
            }
            set
            {
                try { Window.GetWindow(Page).GetType().GetProperty("WindowWidth").SetValue(Window.GetWindow(Page), value); }
                catch { }
            }
        }
        /// <summary>
        /// 窗口高度
        /// </summary>
        public double Height
        {
            get
            {
                try { return (double)Window.GetWindow(Page).GetType().GetProperty("WindowHeight").GetValue(Window.GetWindow(Page)); }
                catch { return 548; }
            }
            set
            {
                try { Window.GetWindow(Page).GetType().GetProperty("WindowHeight").SetValue(Window.GetWindow(Page), value); }
                catch { }
            }
        }
        /// <summary>
        /// 窗口标题
        /// </summary>
        public string Title
        {
            get
            {
                try { return (string)Window.GetWindow(Page).GetType().GetProperty("WindowTitle").GetValue(Window.GetWindow(Page)); }
                catch { return "AquaL"; }
            }
            set
            {
                try { Window.GetWindow(Page).GetType().GetProperty("WindowTitle").SetValue(Window.GetWindow(Page), value); }
                catch { }
            }
        }
        /// <summary>
        /// 关闭宿主窗口
        /// </summary>
        public void Close()
        {
            Window.GetWindow(Page).GetType().GetMethod("CloseWindow").Invoke(Window.GetWindow(Page), null);
        }
    }
}
