/*
 Created by : MADHAN KAMALAKANNAN
 Student ID : 20230907
 Email      : 20230907@mywhitecliffe.com
 Date       : 31 March 2023
*/
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
