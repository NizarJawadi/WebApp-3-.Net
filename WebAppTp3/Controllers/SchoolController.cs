﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppTp3.Models;
using WebAppTp3.Models.Repository;

namespace Identity_Test.Controllers
{

    public class SchoolController : Controller
    {
        readonly ISchoolRepository schoolrepository;
        public SchoolController(ISchoolRepository schoolrepository)
        {
            this.schoolrepository = schoolrepository;
        }
        // GET: SchoolController
     
        public ActionResult Index()
        {
            return View(schoolrepository.GetAll());
        }

        // GET: SchoolController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.studentcount = schoolrepository.StudentCount(id);
            ViewBag.StudentAgeAverage = schoolrepository.StudentAgeAverage(id);

            var school = schoolrepository.GetById(id);
            return View(school);
        }

        // GET: SchoolController/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: SchoolController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(School s)
        {
            try
            {
                schoolrepository.Add(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SchoolController/Edit/5
        public ActionResult Edit(int id)
        {
            var school = schoolrepository.GetById(id);
            return View(school);
        }

        // POST: SchoolController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(School s)
        {
            try
            {
                schoolrepository.Edit(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SchoolController/Delete/5
        public ActionResult Delete(int id)
        {
            var school = schoolrepository.GetById(id);
            return View(school);
        }

        // POST: SchoolController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(School s)
        {
            try
            {

                schoolrepository.Delete(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
