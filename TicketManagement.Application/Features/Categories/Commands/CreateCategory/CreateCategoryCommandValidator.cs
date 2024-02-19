using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.Application.Features.Events.Commands.CreateEvent;

namespace TicketManagement.Application.Features.Categories.Commands.CreateCategory
{
    internal class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
    }
}
