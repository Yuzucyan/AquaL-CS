using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AquaL.Api
{
    /// <summary>
    /// AquaL 插件（接口类）
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// 插件名称
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// 插件标识符
        /// </summary>
        string Identifier { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        string Icon { get; set; }
        /// <summary>
        /// 插件支持的Modules Type
        /// </summary>
        List<AquaL.Plugin.PluginJson_Modules> Modules { get; set; }
        /// <summary>
        /// 插件程序集
        /// </summary>
        Assembly Assembly { get; set; }
        /// <summary>
        /// 插件目录（Aqual主目录下的相对路径）
        /// </summary>
        string PluginDirectoryPathRelative { get; set; }
        /// <summary>
        /// 插件描述
        /// </summary>
        string Description { get; set; }
        /// <summary>
        /// 加载完成方法
        /// </summary>
        void Loaded();
    }
    /// <summary>
    /// AquaL 插件接口
    /// </summary>
    public class Plugin : IPlugin
    {
        /// <summary>
        /// 插件名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 插件标识符
        /// </summary>
        public string Identifier { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 插件支持的Modules Type
        /// </summary>
        public List<AquaL.Plugin.PluginJson_Modules> Modules { get; set; }
        /// <summary>
        /// 插件程序集
        /// </summary>
        public Assembly Assembly { get; set; }
        /// <summary>
        /// 插件目录（Aqual主目录下的相对路径）
        /// </summary>
        public string PluginDirectoryPathRelative { get; set; }
        /// <summary>
        /// 插件描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 加载完成方法
        /// </summary>
        public void Loaded() { }
    }
}
