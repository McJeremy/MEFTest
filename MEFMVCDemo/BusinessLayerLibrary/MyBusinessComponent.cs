using Interfacelibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BusinessLayerLibrary
{
    /// <summary>
    /// 一个使用底层插件的虚拟业务类
    /// </summary>
    public class MyBusinessComponent
    {
        /// <summary>
        /// 引用实际上使用的插件
        /// </summary>
        private IPlugIn _plugin=null;
        /// <summary>
        /// 保存所有在PlugIns文件夹下的插件引用
        /// </summary>
        [ImportMany(AllowRecomposition=true)]
        private IEnumerable<Lazy<IPlugIn,IComponentExportMetadataView>> plugIns;
        /// <summary>
        /// 在此动态组合插件，检查所有插件版本，选取版本最高的插件使用
        /// </summary>
        public MyBusinessComponent()
        {
           //获取MEF容器
           CompositionContainer container=MefInitializer.MefContainer;
            //组合组件
           container.ComposeParts(this);
           int plugCount=plugIns.Count();
           if (plugCount == 1)
           {
               _plugin = plugIns.ElementAt(0).Value;
           }
           else
           {
               if (plugCount > 1)
               {
                   int highestVersion = 0;
                   int highestVersionIndex = 0;
                  
                   for (int i = 0; i < plugCount; i++)
                   {
                       var plug = plugIns.ElementAt(i);
                      
                        
                           if (plug.Metadata.VersionCode > highestVersion)
                           {
                               highestVersion =plug.Metadata.VersionCode;
                               highestVersionIndex = i;
                           }
                      
                      
                       //if (plug.Metadata["version_code"] != null)
                       //{
                       //    int version_code = int.Parse(plug.Metadata["version_code"].ToString());
                       //    if (version_code > highestVersion)
                       //    {
                       //        highestVersion = version_code;
                       //        highestVersionIndex = i;
                       //    }
                       //}
                   }
                   _plugin = plugIns.ElementAt(highestVersionIndex).Value;
               }
           }
          
        }
        /// <summary>
        /// 启动某业务处理流程，使用_plugIn所引用的插件
        /// </summary>
        /// <returns></returns>
        public string BeginProcess()
        {
            if (_plugin != null)
            {
                return "调用底层插件的process()方法："+_plugin.process();
            }
            return "无法装载任何插件";
        }
    }
}
