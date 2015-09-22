using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayerLibrary;
using System.IO;

namespace MefMvc.Web.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 实例化相应的业务逻辑组件
        /// </summary>
        private MyBusinessComponent component = new MyBusinessComponent();
        /// <summary>
        /// 启动执行业务流程
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Information=component.BeginProcess();
            return View();
        }
        /// <summary>
        /// 上传组件以更新系统
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateSystem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UpdateSystem(HttpPostedFileBase plugin)
        {
            if (plugin != null)
            {
                
                string PlugDir = Server.MapPath("~/PlugIns");
                             
                string SaveFileName = PlugDir + "/" +Path.GetFileName(plugin.FileName);
                if(System.IO.File.Exists(SaveFileName)==false)
                    plugin.SaveAs(SaveFileName);
                
                MefInitializer.Recomposite();
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
