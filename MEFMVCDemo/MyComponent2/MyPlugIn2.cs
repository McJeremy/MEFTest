using Interfacelibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace MyComponent1
{
    [Export(typeof(IPlugIn))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    //[ExportMetadata("version_code",2)]
    [ComponentExport(VersionCode = 2)]
    public class MyPlugIn2 : IPlugIn
    {
        public string process()
        {
            return "MyPlugIn2 is processing";
        }
    }
}
