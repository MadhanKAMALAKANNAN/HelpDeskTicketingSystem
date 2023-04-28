/*
 Created by : MADHAN KAMALAKANNAN
 Student ID : 20230907
 Email      : 20230907@mywhitecliffe.com , Madhan.KAMALAKANNAN@outlook.com  ,Madhan.KAMALAKANNAN@gmail.com
 Date       : 31 March 2023
*/
using HelpDeskTicketingSystem;
using HelpDeskTicketingSystem.TicketCls;
using HelpDeskTicketingSystem.Entities;
using System.Transactions;

Console.WriteLine("Help Desk Ticketing System Prototype!");
string key = "1";
TicketCls TicketCls = new TicketCls();
do
{
    try
    {
       
     
        Console.WriteLine("------------------------------------");
        Console.WriteLine("Select from following choices");
        Console.WriteLine("------------------------------------");
        Console.WriteLine("0:Exit");
        Console.WriteLine("1:Submit helpdesk ticket");
        Console.WriteLine("2:Show all Ticket");
        Console.WriteLine("3:Respond to ticket by number");
        Console.WriteLine("4:Re-open resolved ticket");
        Console.WriteLine("5:Display ticket stats");

        Console.Write("Enter menu selection 0-5:");
        var key1 = Console.ReadKey();
        Console.WriteLine("");
        if (key1 != null)
        {
            key = key1.KeyChar + "";
        }
        if (key == "0")
        {
            Console.WriteLine("0:Exit");
            break;
        }
        else if (key == "1")
        {
            //Console.WriteLine("1:Submit helpdesk ticket");
            TicketCls.TicketSubmit(); 
        }
        else if (key == "2")
        {
            //Console.WriteLine("2:Show all Ticket");
            TicketCls.ShowAllTicket();
        }
        else if (key == "3")
        {          
           TicketCls.RespondingToTicket();
        }
        else if (key == "4")
        {
            // Console.WriteLine("4:Re-open resolved ticket");
            TicketCls.ReopenTicket();
        }
        else if (key == "5")
        {
            // Console.WriteLine("5:Display ticket stats");
            TicketCls.TickeStats();
        }
        else
        {
            //break;
        }
        Logs.Loggings(String.Format(Environment.NewLine+"Option {0}",key));
    }
    catch(Exception ex) 
    {
        Logs.Loggings(ex.Message);
        Logs.Loggings(Environment.NewLine);
        Logs.Loggings(ex.StackTrace);
    }
    //Console.WriteLine("");
} while (true);
