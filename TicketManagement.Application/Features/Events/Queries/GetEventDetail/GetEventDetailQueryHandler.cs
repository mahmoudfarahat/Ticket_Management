using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.Application.Contracts.Persistence;
using TicketManagement.Domain.Entities;

namespace TicketManagement.Application.Features.Events.Queries.GetEventDetail
{
    internal class GetEventDetailQueryHandler : IRequestHandler<GetEventDetailQuery, EventDetailsVm>
    {
        private readonly IMapper mapper;
        private readonly IAsyncRepository<Event> eventRespoitory;
        private readonly IAsyncRepository<Category> categoryRepository;

        public GetEventDetailQueryHandler(IMapper mapper, IAsyncRepository<Event> eventRespoitory, IAsyncRepository<Category> categoryRepository)
        {
            this.mapper = mapper;
            this.eventRespoitory = eventRespoitory;
            this.categoryRepository = categoryRepository;
        }

        public async Task<EventDetailsVm> Handle(GetEventDetailQuery request, CancellationToken cancellationToken)
        {
            var @event = await eventRespoitory.GetByIdAsync(request.Id);
            var eventDetailDto = mapper.Map<EventDetailsVm>(@event);
            var category = await categoryRepository.GetByIdAsync(request.Id);
            eventDetailDto.Category = mapper.Map<CategoryDto>(category);
            return eventDetailDto;
        }
    }
}
