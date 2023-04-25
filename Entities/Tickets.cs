using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskTicketingSystem.Entities
{
    public class Ticket
    {
        public Ticket()
        {

        }
        public string TicketId { get; set; }
        public string TicketOwnerId { get; set; } 
        public string TicketDescription { get; set;}
        public string TicketStatus { get; set;}
        public string TicketResponse { get; set;}
    }
}
