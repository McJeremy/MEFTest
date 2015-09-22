using Interfacelibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace Interfacelibrary
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class,AllowMultiple=false)]
    public class ComponentExportAttribute:ExportAttribute
    {
        /// <summary>
        /// 本组件的版本号
        /// </summary>
        public int VersionCode { get; set; }
        public ComponentExportAttribute()
            : base(typeof(IPlugIn))
        {

        }
    }
}
