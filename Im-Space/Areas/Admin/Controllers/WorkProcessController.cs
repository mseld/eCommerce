using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IM.Web.Controllers;
using IM.Web.DependencyResolution.Filters;
using IM.Web.Domain;
using IM.Web.Helpers;
using IM.Web.Services;
using Newtonsoft.Json;

namespace IM.Web.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class WorkProcessController : BaseController
    {
        private readonly IWorkProcessService workProcessService;

        public WorkProcessController(IWorkProcessService workProcessService)
        {
            this.workProcessService = workProcessService;
        }

        // GET: Admin/WorkProcess
        public PartialViewResult Index(WorkProcessType type)
        {
            return PartialView("_Index", type);
        }

        public JsonResult Progress(WorkProcessType type)
        {
            var jobs = workProcessService.Find(type).Where(p => p.IsRunning).ToList();

            return JsonSuccess(jobs);
        }
    }
}