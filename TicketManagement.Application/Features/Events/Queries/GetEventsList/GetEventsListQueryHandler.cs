﻿using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.Application.Contracts.Persistence;
using TicketManagement.Domain.Entities;

namespace TicketManagement.Application.Features.Events.Queries.GetEventsList
{
    public class GetEventsListQueryHandler : IRequestHandler<GetEventsListQuery, List<EventListVm>>
    {
        private readonly IMapper mapper;
        private readonly IAsyncRepository<Event> eventRepository;

        public GetEventsListQueryHandler(IMapper mapper, IAsyncRepository<Event> eventRepository)
        {
            this.mapper = mapper;
            this.eventRepository = eventRepository;
        }
        public async Task<List<EventListVm>> Handle(GetEventsListQuery request, CancellationToken cancellationToken)
        {
            var allEvents = (await eventRepository.ListAllAsync()).OrderBy(x => x.Date);
            return mapper.Map<List<EventListVm>>(allEvents);
        }
    }
}
