using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaL.Api
{
    /// <summary>
    /// 使用Intent来运行某个模块
    /// </summary>
    public class Intent
    {
        /// <summary>
        /// 使用默认模块运行这个Intent，如果没有默认模块则询问用户
        /// </summary>
        /// <param name="Type">模块类型</param>
        /// <param name="Data">数据</param>
        /// <returns></returns>
        public static IntentResult Run(string Type, object Data)
        {
            bool useDefaultModule = false;
            // TODO 查找默认模块

            List<SupportPlugin> supportPlugins = new List<SupportPlugin>();
            foreach (Plugin plg in AquaL.Plugin.Manager.Plugins)
            {
                foreach (AquaL.Plugin.PluginJson_Modules plgModule in plg.Modules)
                {
                    if (plgModule.Type == Type)
                        supportPlugins.Add(new SupportPlugin() { Plugin = plg, Data = plgModule.Data, Location = plgModule.Location, Method = plgModule.Method });
                }
            }


            return null;
        }
    }

    public class IntentResult
    {
        /// <summary>
        /// 谁来负责运行这个Module
        /// </summary>
        public Type WhoType { get; set; }
    }

    public class SupportPlugin
    {
        /// <summary>
        /// 插件
        /// </summary>
        public Plugin Plugin { get; set; }
        /// <summary>
        /// 模块的"命名空间.类名"
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// 模块的方法名
        /// </summary>
        public string Method { get; set; }
        /// <summary>
        /// 默认Data
        /// </summary>
        public object Data { get; set; }
    }
}
