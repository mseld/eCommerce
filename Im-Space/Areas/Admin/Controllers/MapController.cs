using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using IM.Web.Areas.Admin.Models;
using IM.Web.Controllers;
using IM.Web.DAL;
using IM.Web.DependencyResolution.Filters;
using IM.Web.Domain;
using IM.Web.Helpers;
using IM.Web.Services;

namespace IM.Web.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class MapController : Controller
    {
        private readonly IMapService mapService;

        public MapController(IMapService mapService)
        {
            this.mapService = mapService;
        }

        [AllowAnonymous]
        public JsonResult Branches()
        {
            var model = new LocationsViewModel();

            var locations = mapService.FindAll();
            Mapper.Map(locations, model.Locations);

            return Json(model,JsonRequestBehavior.AllowGet);
        }

        // GET: Admin/Map
        [AccessAuthorize(OperatorRoles.SETTINGS)]
        public ActionResult Index()
        {
            var model = new LocationsViewModel();

            var locations = mapService.FindAll();
            Mapper.Map(locations, model.Locations);

            return View(model);
        }

        [AccessAuthorize(OperatorRoles.OPERATORS + OperatorRoles.WRITE)]
        public ActionResult Create()
        {
            var model = new LocationViewModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AccessAuthorize(OperatorRoles.SETTINGS + OperatorRoles.WRITE)]
        public ActionResult Create(LocationViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    mapService.AddOrUpdate(model);
                    return RedirectToAction("Index")
                        .WithSuccess(string.Format("Location \"{0}\" has been added".TA(),
                            model.Name));
                }
                catch (ArgumentException err)
                {
                    ModelState.AddModelError(err.ParamName ?? string.Empty, err.Message);
                }
            }

            return View(model);
        }


        // GET: Admin/Map/Edit/5
        [AccessAuthorize(OperatorRoles.SETTINGS + OperatorRoles.WRITE)]
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = mapService.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }

            var model = Mapper.Map<LocationViewModel>(location);

            return View(model);
        }

        // POST: Admin/Map/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AccessAuthorize(OperatorRoles.SETTINGS + OperatorRoles.WRITE)]
        public ActionResult Edit(LocationViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    mapService.AddOrUpdate(model);
                    return RedirectToAction("Index")
                        .WithSuccess(string.Format("location \"{0}\" has been updated".TA(),
                            model.Name));
                }
                catch (ArgumentException err)
                {
                    ModelState.AddModelError(err.ParamName ?? string.Empty, err.Message);
                }
            }

            return View(model);
        }


        [AccessAuthorize(OperatorRoles.SETTINGS + OperatorRoles.DELETE)]
        public ActionResult Delete(int id)
        {
            mapService.Delete(id);

            return RedirectToAction("Index")
                .WithWarning("The selected Location have been deleted".TA());
        }
    }
}