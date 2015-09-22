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
    [ComponentExport(VersionCode = 1)]
    public class MyPlugIn1 : IPlugIn
    {
        public string process()
        {
            return "MyPlugIn1 is processing";
        }
    }
}
