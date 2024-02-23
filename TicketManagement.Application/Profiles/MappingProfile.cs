using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.Application.Features.Categories.Commands.CreateCategory;
using TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using TicketManagement.Application.Features.Events.Commands.CreateEvent;
using TicketManagement.Application.Features.Events.Commands.DeleteEvent;
using TicketManagement.Application.Features.Events.Commands.UpdateEvent;
using TicketManagement.Application.Features.Events.Queries.GetEventDetail;
using TicketManagement.Application.Features.Events.Queries.GetEventsExport;
using TicketManagement.Application.Features.Events.Queries.GetEventsList;
using TicketManagement.Domain.Entities;

namespace TicketManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event,EventListVm>().ReverseMap();
            CreateMap<Event, EventDetailsVm>().ReverseMap();
           CreateMap<Category, CreateCategoryDto>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryListVm>();

            CreateMap<Category, CategoryEventListVm>();

            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, DeleteEventCommand>().ReverseMap();

            CreateMap<Event, CategoryEventDto>().ReverseMap();
            CreateMap<Event, EventExportDto>().ReverseMap();
            //CreateMap<Category, CategoryEventListVm>();
            //CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            //CreateMap<Category, CreateCategoryDto>().ReverseMap();
            //CreateMap<Event, CategoryEventDto>().ReverseMap();

            //CreateMap<Event, CreateEventCommand>().ReverseMap();
            //CreateMap<Event, UpdateEventCommand>().ReverseMap();
            //CreateMap<Event, CategoryEventDto>().ReverseMap();
        }
    }
}
