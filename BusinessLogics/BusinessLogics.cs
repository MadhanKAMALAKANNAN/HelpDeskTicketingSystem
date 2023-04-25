/*
 Created by : MADHAN KAMALAKANNAN
 Student ID : 20230907
 Email      : 20230907@mywhitecliffe.com
 Date       : 31 March 2023
*/
using HelpDeskTicketingSystem.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskTicketingSystem.TicketCls
{
    public class TicketCls
    {
        public List<Ticket> Ticket;
        public List<Staff> staffs;
        public string   needPasswordChange = "Password change";
        public string defaultReponse= "Not Yet Provided";
        public enum TicketStatus
        {
            Open,Inprogress,Closed,ReOpened
        }
        public TicketCls()
        {
            Ticket = new List<Ticket>();
            staffs = new List<Staff>();
            defaultTicket();
        }
        public async void TicketSubmit()
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Submitting Tickets:");
            Console.WriteLine("------------------------------------");
            do
            {
                var staffId = EnterDetails("Enter staff id:");
               

            var staffAlreadyExists = staffs.Where(x => x.staffId == staffId.Result).Any();
            if (!staffAlreadyExists)
            {
                Staff staff = new Staff();
                staff.staffId = staffId.Result;
                var staffName = EnterDetails("Enter staff name:");
                var staffEamil = EnterDetails("Enter staff email:");
                staff.staffName= staffName.Result;
                staff.staffEmail = staffEamil.Result;            
                staffs.Add(staff);
            }
            else
            {
                var staff = staffs.Where(x => x.staffId == staffId.Result).First();
               
                Console.WriteLine("Staff name:{0}", staff.staffName);
                Console.WriteLine("Staff email:{0}", staff.staffEmail);
            }

          
                var probelmDesc = EnterDetails("If you require a new password type: Password change" + Environment.NewLine +"Enter problem description:");
                Ticket ticket = new Ticket();
                if (Ticket.Count == 0)
                {
                    ticket.TicketId = 2000 + "";
                }
                else
                {
                    int ticId = Convert.ToInt32(Ticket.LastOrDefault().TicketId) + 1;
                    ticket.TicketId = ticId + "";
                }
                ticket.TicketOwnerId = staffId.Result;


                ticket.TicketDescription = probelmDesc.Result;

                if (ticket.TicketDescription == needPasswordChange)
                {
                    var response = string.Format("New Password for ticket {0} got generated:{1}", ticket.TicketId, GenerateNewPassword(ticket).Result);
                    Console.WriteLine(response);
                    ticket.TicketStatus = TicketStatus.Closed.ToString();
                    ticket.TicketResponse = response;
                    Ticket.Add(ticket);
                }
                else
                {
                    ticket.TicketStatus = TicketStatus.Open.ToString();
                    ticket.TicketResponse = defaultReponse;
                    Ticket.Add(ticket);
                    Console.WriteLine("New Ticket {0} got created.", ticket.TicketId);
                }
               
            }
            while(ToContinue(""));

            TickeStats();

            // Console.WriteLine("");
            // ShowTicketDetails(ticket.TicketId);

        }
        public async Task<string> EnterDetails(string desc)
        {
            do
            {
                Console.Write(desc);
                var cont = Console.ReadLine();
                if (cont != null && cont.Trim() != "")
                {
                    return cont;

                }
                //Console.WriteLine("");
            } while (true);
        }
        public async Task<string> GenerateNewPassword(Ticket ticket)
        {
            if (ticket != null)
            {
                var newPassword = ticket.TicketId.Substring(0, 2);
                var stName = staffs.Where(x => x.staffId == ticket.TicketOwnerId).Select(x => x.staffName).FirstOrDefault();
                if(stName!=null)
                {
                    newPassword += stName.Substring(0, 3);
                    return newPassword;
                }
            }

            return "newpassword";
        }

        public async void ShowAllTicket()
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Printing Tickets:");
            Console.WriteLine("------------------------------------");
            var tkCont = Ticket.Count();
            var cnt = 0;
            foreach (var ticket in Ticket)
            {
                cnt++;

                Staff staff = staffs.FirstOrDefault(x => x.staffId == ticket.TicketOwnerId);

                Console.WriteLine("Ticket:{0}",ticket.TicketId);
                Console.WriteLine("Submitted by id:{0}", staff.staffId);
                if (staff != null) {
                    Console.WriteLine("Ticket owner :{0}", staff.staffName);
                }
                Console.WriteLine("Contact email is:{0}", staff.staffEmail);
                Console.WriteLine("Description of issue:{0}", ticket.TicketDescription);
                Console.WriteLine("Ticket Status:{0}", ticket.TicketStatus);

                if (ticket.TicketResponse != "")
                {
                    Console.WriteLine("Response :{0}", ticket.TicketResponse);
                }

                if (tkCont != cnt)
                {
                    Console.WriteLine("------------------------------------");
                } 
            }

           
        }
        public async void ShowTicketDetails(string ticketId)
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Displaying the ticket:");
            Console.WriteLine("------------------------------------");

            var ticket = Ticket.Where(x=>x.TicketId == ticketId).FirstOrDefault();
            if(ticket!=null)
            {
                Staff staff = staffs.FirstOrDefault(x => x.staffId == ticket.TicketOwnerId);

                Console.WriteLine("Ticket number:{0}", ticket.TicketId);
                Console.WriteLine("Submitted by id:{0}", staff.staffId);
                if (staff != null)
                {
                    Console.WriteLine("Ticket owner :{0}", staff.staffName);
                }
                Console.WriteLine("Contact email is:{0}", staff.staffEmail);
                Console.WriteLine("Description of issue:{0}", ticket.TicketDescription);
                Console.WriteLine("Ticket Status:{0}", ticket.TicketStatus);

                if (ticket.TicketResponse != "")
                {
                    Console.WriteLine("Response :{0}", ticket.TicketResponse);
                }
               
            }
        }
        public void defaultTicket()
        {
            Staff staff = new Staff();
            staff.staffId = "1";
            staff.staffName = "Madhan";
            staff.staffEmail = staff.staffName+"@WhiteCliffe.co.ac";

            staffs.Add(staff);

           
            Ticket ticket = new Ticket();
            ticket.TicketId = 2000 + "";
           // ticket.TicketStatus = TicketStatus.Open.ToString();
            ticket.TicketDescription = needPasswordChange;
            ticket.TicketOwnerId = staff.staffId;
            //ticket.TicketResponse = defaultReponse;

            //
            var response = string.Format("New Password for ticket {0} got generated:{1}", ticket.TicketId, GenerateNewPassword(ticket).Result);
            Console.WriteLine(response);
            ticket.TicketStatus = TicketStatus.Closed.ToString();
            ticket.TicketResponse = response;
            Ticket.Add(ticket);
            //

           
           
            TickeStats();
           // Console.WriteLine("");
            ShowAllTicket();
        }
        public async void TickeStats()
        {
            //
            var tCnt = 0;
            var tCntO = 0;
            var tCntC = 0;
            var tCntR = 0;
            if (Ticket.Count > 0)
            {
                tCnt = Ticket.Count();
                tCntO = Ticket.Where(x => x.TicketStatus == TicketStatus.Open.ToString()).Count();
                tCntC = Ticket.Where(x => x.TicketStatus == TicketStatus.Closed.ToString()).Count();
                tCntR = Ticket.Where(x => x.TicketStatus == TicketStatus.ReOpened.ToString()).Count();
                tCntO = tCntO + tCntR;
            }
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Displaying Ticket Statistics");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Tickets Submitted: {0}", tCnt);
            Console.WriteLine("Tickets Resolved: {0}", tCntC);
            Console.WriteLine("Tickets To Solve: {0}", tCntO); 

        }

        public async void RespondingToTicket()
        {
           // Console.WriteLine("");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Responding to the ticket");
            Console.WriteLine("------------------------------------");
            bool wantsToContinue = false;
            do
            {
                string ticketId = EnterDetails("Enter ticket number to respond:").Result;
                var ticket = Ticket.Where(x => x.TicketId == ticketId).SingleOrDefault(); 

                if (ticket != null)
                {
                    if (ticket.TicketStatus != TicketStatus.Closed.ToString())//if not closed then respond
                    {
                        Console.WriteLine("The Problem description:{0}",ticket.TicketDescription);
                        ticket.TicketResponse = EnterDetails("Ticket Response:").Result;
                        ticket.TicketStatus = TicketStatus.Closed.ToString();
                        ShowTicketDetails(ticketId); 
                        wantsToContinue = false;
                    }
                    else
                    {
                        //Console.WriteLine("Ticket {0} already {1}",ticketId, ticket.TicketStatus);
                        string cont = string.Format("Ticket {0} already {1}", ticketId, ticket.TicketStatus);
                        wantsToContinue = ToContinue(cont);
                    }
                }
                else
                {
                    // Console.WriteLine("Ticket {0} not found", ticketId);
                    string cont = string.Format("Ticket {0} doe not exists!.", ticketId);
                    wantsToContinue = ToContinue(cont);
                }
            }
            while (wantsToContinue);
            TickeStats();
        }

        public async void ReopenTicket()
        {
           // Console.WriteLine("");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Re-open resolved ticket");
            Console.WriteLine("------------------------------------");
            bool  wantsToContinue = false;
           do
            {
                string ticketId = EnterDetails("Enter ticket number to reopen:").Result;
                var ticket = Ticket.Where(x => x.TicketId == ticketId).SingleOrDefault();

                if (ticket != null)
                {
                    if (ticket.TicketStatus == TicketStatus.Closed.ToString())//if closed then reopen
                    {
                        ticket.TicketStatus = TicketStatus.ReOpened.ToString();

                        ShowTicketDetails(ticketId);
                        wantsToContinue = false;
                    }
                    else
                    {
                        string cont = string.Format("Ticket {0} already {1}", ticketId, ticket.TicketStatus);
                        wantsToContinue = ToContinue(cont); 
                    }
                }
                else
                {
                    string cont = string.Format("Ticket {0} doe not exists!.", ticketId);
                    wantsToContinue = ToContinue(cont); 
                } 
            }
            while(wantsToContinue);
        }

        public bool ToContinue(string cont)
        { 
            Console.WriteLine(cont);
            string ticketIdRp = EnterDetails("Do you want enter another ticket number (y/n):").Result;
            if (ticketIdRp.ToLower() == "y")
            {
                return true;
            } 
            return false;
        }
    }
    
}
