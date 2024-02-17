﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagement.Application.Features.Events.Queries.GetEventDetail
{
    public class EventDetailsVm
    {
        public Guid EventId { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime Date { get; set; }
        public int Price { get; set; }
        public string ImageUrl { get; set; }
        public string Artist { get; set; }

        public string Description { get; set; }

        public Guid CategoryId { get; set; }
        public CategoryDto Category { get; set; } = default;
    }
}
