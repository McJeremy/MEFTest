using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;

namespace BusinessLayerLibrary
{
    /// <summary>
    /// 封装中间层MEF的功能
    /// </summary>
    public class MefInitializer
    {
        private static CompositionContainer _container = null;
        private static DirectoryCatalog dir = null;
        /// <summary>
        /// 设定插件存放目录,每指定一个新的目录，将自动重新创建一个新的容器对象
        /// </summary>
        public static String PlugInDir
        {
            set
            {
                dir = new DirectoryCatalog(value);

                _container = new CompositionContainer(dir);
            }
        }
        /// <summary>
        /// 外界通过此属性获取可用的MEF容器
        /// </summary>
        public static CompositionContainer MefContainer
        {
            get
            {
                return _container;
            }
        }
        /// <summary>
        /// 刷新，重新组合组件
        /// </summary>
        public static void Recomposite()
        {
            if (dir != null)
            {
                dir.Refresh();
            }
        }
       

    }
}
