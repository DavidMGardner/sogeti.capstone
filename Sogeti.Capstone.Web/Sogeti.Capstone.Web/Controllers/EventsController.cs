using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Moo.Extenders;
using ShortBus;
using Sogeti.Capstone.Data.Model;
using Sogeti.Capstone.Domain.Queries.EventByIdQuery;
using Sogeti.Capstone.Domain.Queries.EventListQuery;
using Sogeti.Capstone.Web.Application;
using Sogeti.Capstone.Web.ViewModel;

namespace Sogeti.Capstone.Web.Controllers
{
    public class EventsController : BaseController
    {
        // GET: Events
        public async Task<ActionResult> Index()
        {
            EventListResult response = await QueryAsync(new EventListQuery());
            IEnumerable<EventViewModel> viewModel = response.Events.Select(m => m.MapTo<EventViewModel>());

            return View(viewModel);
        }

        // GET: Events/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            var viewModel = await GetEventViewModelById(id);
            return View(viewModel);
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
        public ActionResult Create([Bind(Include = "Id,Title,StartDateTime,EndDateTime,Description,LogoPath,LocationInformation")] EventViewModel @event)
        {
            throw new NotImplementedException();
        }

        // GET: Events/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            var viewModel = await GetEventViewModelById(id);
            return View(viewModel);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,StartDateTime,EndDateTime,Description,LogoPath,LocationInformation")] EventViewModel @event)
        {
            throw new NotImplementedException();

        }

        // GET: Events/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            var viewModel = await GetEventViewModelById(id);
            return View(viewModel);

        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            throw new NotImplementedException();

        }

        private async Task<EventViewModel> GetEventViewModelById(int? id)
        {
            var viewModel = (await QueryAsync(new EventByIdQuery(id.ToString()))).MapTo<EventViewModel>();
            return viewModel;
        }

    }
}
