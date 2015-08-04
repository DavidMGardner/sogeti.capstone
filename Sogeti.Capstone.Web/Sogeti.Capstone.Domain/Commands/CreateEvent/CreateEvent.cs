using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShortBus;

namespace Sogeti.Capstone.Domain.Commands.CreateEvent
{
    public class CreateEvent : IAsyncRequest<CreateEventResult>
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Description { get; set; }
        public string LogoPath { get; set; }
        public string LocationInformation { get; set; }

        public CreateEvent()
        {
            
        }

        public CreateEvent(string id, string title, DateTime startDateTime, DateTime endDateTime, string description, string logoPath, string locationInformation)
        {
            Id = id;
            Title = title;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            Description = description;
            LogoPath = logoPath;
            LocationInformation = locationInformation;
        }
    }

    public class CreateEventResult
    {
        public int Id { get; set; }
    }
}
