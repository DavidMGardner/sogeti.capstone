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
using Sogeti.Capstone.Domain.Queries.EventTypeListQuery;
using Sogeti.Capstone.Domain.Queries.RegistrationTypeListQuery;
using Sogeti.Capstone.Web.Application;
using Sogeti.Capstone.Web.ViewModel;
using Sogeti.Capstone.Domain.Commands.CreateEvent;

namespace Sogeti.Capstone.Web.Controllers
{
    public class EventsController : BaseController
    {
        // GET: Events
        public async Task<ActionResult> Index(int? pageId, string searchQuery)
        {
            const int eventsPerPage = 9;

            var viewModel = await GetEventList();
            viewModel = FilterEventViewModels(searchQuery, viewModel);

            ViewBag.NumberOfPages = (int)Math.Max((viewModel.Count() / eventsPerPage), 1.0f);
            viewModel = GetRangeEventViewModels(pageId, eventsPerPage, viewModel);

            if (Request.IsAjaxRequest())
            {
                if (viewModel.Any())
                    return PartialView("_EventsList", viewModel);
                return new EmptyResult();
            }

            return View("Index", viewModel);
        }

        // GET: Events/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            var viewModel = await GetEventViewModelById(id);
            return PartialView("_DetailsPartialView", viewModel);
        }

        // GET: Events/Create
        public async Task<ActionResult> Create()
        {
            var eventViewModel = new EventViewModel
            {
                Title = String.Empty,
                StartDateTime = DateTime.Now,
                EndDateTime = DateTime.Now,
                Description = String.Empty,
                LogoPath = String.Empty,
                LocationInformation = String.Empty
            };

            ViewBag.RegistrationType = await GetRegistrationTypes();
            ViewBag.EventType = await GetEventTypes();

            return View(eventViewModel);
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateEvent([Bind(Include = "Id,Title,StartDateTime,EndDateTime,Description,LogoPath,LocationInformation")] EventViewModel @event)
        {
            if (ModelState.IsValid)
            {
                var command = @event.MapTo<CreateEvent>();
                var result = await Mediator.RequestAsync(command);
                return RedirectToAction("Index");
            }

            return View(@event);
        }

        private static IEnumerable<EventViewModel> GetRangeEventViewModels(int? pageId, int eventsPerPage, IEnumerable<EventViewModel> viewModel)
        {
            int startPage = (pageId ?? 1);
            int startIndex = (startPage - 1) * eventsPerPage;

            viewModel = viewModel.OrderBy(d => d.StartDateTime);

            viewModel = viewModel.Skip(startIndex);
            viewModel = viewModel.Take(eventsPerPage);
            return viewModel;
        }

        private static IEnumerable<EventViewModel> FilterEventViewModels(string filterQuery, IEnumerable<EventViewModel> viewModel)
        {
            if (!String.IsNullOrEmpty(filterQuery))
            {
                filterQuery = filterQuery.ToLower();
                viewModel = viewModel.Where(s => s.Title.ToLower().Contains(filterQuery)
                                                 || s.Description.ToLower().Contains(filterQuery)
                                                 || s.LocationInformation.ToLower().Contains(filterQuery)
                                                 || s.StartDateTime.ToString().Contains(filterQuery)
                                                 || s.EndDateTime.ToString().Contains(filterQuery));
            }
            return viewModel;
        }

        private async Task<IEnumerable<EventViewModel>> GetEventList()
        {
            EventListResult response = await QueryAsync(new EventListQuery());
            IEnumerable<EventViewModel> viewModel = response.Events.Select(m => m.MapTo<EventViewModel>());
            return viewModel;
        }

        private async Task<EventViewModel> GetEventViewModelById(int? id)
        {
            EventByIdResult response = await QueryAsync(new EventByIdQuery(id.ToString()));
            var viewModel = response.Event.MapTo<EventViewModel>();
            return viewModel;
        }

        private async Task<IEnumerable<RegistrationTypeViewModel>> GetRegistrationTypes()
        {
            RegistrationTypeListResult response = await QueryAsync(new RegistrationTypeListQuery());
            IEnumerable<RegistrationTypeViewModel> registrationTypeViewModels =
                response.Categories.Select(m => m.MapTo<RegistrationTypeViewModel>());
            return registrationTypeViewModels;
        }

        private async Task<IEnumerable<EventTypeViewModel>> GetEventTypes()
        {
            EventTypeListResult eventTypeListResult = await QueryAsync(new EventTypeListQuery());
            var eventTypeViewModels = eventTypeListResult.EventTypes.Select(m => m.MapTo<EventTypeViewModel>());
            return eventTypeViewModels;
        }
    }
}
