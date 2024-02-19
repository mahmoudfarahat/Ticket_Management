﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.Application.Contracts.Persistence;

namespace TicketManagement.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        private readonly IEventRepository eventRepository;

        public CreateEventCommandValidator(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 Characters.");

            RuleFor(p => p.Date)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(DateTime.Now);

            RuleFor(e => e)
                .MustAsync(EventNameAndDateUnique)
                .WithMessage("An event with the same name and date already exists.");


            RuleFor(p => p.Price)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .GreaterThan(0);
        }
        private async Task<bool> EventNameAndDateUnique(CreateEventCommand e , CancellationToken token)
        {
            return !(await eventRepository.IsEventNameAndDateUnique(e.Name, e.Date));
        }
    }
}
