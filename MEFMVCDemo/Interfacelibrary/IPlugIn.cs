using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfacelibrary
{
    /// <summary>
    /// 所有插件，都必须实现此接口
    /// </summary>
    public interface IPlugIn
    {
        string process();
    }
}
