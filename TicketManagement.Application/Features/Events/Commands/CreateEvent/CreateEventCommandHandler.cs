using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.Application.Contracts.InfraStructure;
using TicketManagement.Application.Contracts.Persistence;
using TicketManagement.Application.Models.Mail;
using TicketManagement.Domain.Entities;

namespace TicketManagement.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IMapper mapper;
        private readonly IEventRepository eventRepository;
        private readonly IEmailService emailService;

        public CreateEventCommandHandler(IMapper mapper , IEventRepository eventRepository, IEmailService emailService)
        {
            this.mapper = mapper;
            this.eventRepository = eventRepository;
            this.emailService = emailService;
        }

        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var @event = mapper.Map<Event>(request);
            var validator = new CreateEventCommandValidator(eventRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);
            

            @event = await eventRepository.AddAsync(@event);
            var email = new Email()
            {
                To = "gill@snowball.be",
                Body = $"A new event was Created:{request}",
                Subject = "A new event was created"
            };
            try
            {
                await emailService.SendEmail(email);
            }catch (Exception ex)
            {

            }
            return @event.EventId;
        }
    }
}
