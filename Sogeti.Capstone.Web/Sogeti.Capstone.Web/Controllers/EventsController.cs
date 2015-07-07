﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ShortBus;
using Sogeti.Capstone.Data.Model;
using Sogeti.Capstone.Domain.Queries.EventListQuery;
using Sogeti.Capstone.Web.Application;
using Sogeti.Capstone.Web.ViewModel;

namespace Sogeti.Capstone.Web.Controllers
{
    public class EventsController : BaseController
    {
        // GET: Events
        public ActionResult Index()
        {
            var response = QueryAsync(new EventListQuery());
            
            return View();
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            return View();
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            var viewModel = new EventViewModel
            {
                Title = String.Empty,
                StartDateTime = DateTime.Now,
                EndDateTime = DateTime.Now,
                Description = String.Empty,
                LogoPath = String.Empty,
                LocationInformation = String.Empty
            };

            return View(viewModel);
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,StartDateTime,EndDateTime,Description,LogoPath,LocationInformation")] Event @event)
        {
            throw new NotImplementedException();
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            throw new NotImplementedException();
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,StartDateTime,EndDateTime,Description,LogoPath,LocationInformation")] Event @event)
        {
            throw new NotImplementedException();

        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            throw new NotImplementedException();

        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            throw new NotImplementedException();

        }
    }
}
