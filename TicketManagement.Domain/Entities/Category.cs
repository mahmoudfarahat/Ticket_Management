using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.Domain.Common;

namespace TicketManagement.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public Guid CategoryId { get; set; }    

        public string Name { get; set; } = string.Empty;

        public ICollection<Event>? events { get; set; }
    }
}
