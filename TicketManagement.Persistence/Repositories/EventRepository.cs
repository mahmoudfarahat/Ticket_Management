using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.Application.Contracts.Persistence;
using TicketManagement.Domain.Entities;

namespace TicketManagement.Persistence.Repositories
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        private readonly TicketDbContext dbContext;

        public EventRepository(TicketDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate)
        {
 var matches = dbContext.Events.Any(e => e.Name.Equals(name) &&
 e.Date.Date.Equals(eventDate.Date));
            return Task.FromResult(matches);
                }
    }
}
