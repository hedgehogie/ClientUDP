using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
//Kommentar
namespace ClientUDP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bitte geben Sie ein Datum an (DD.MM.YYYY): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Ihre Eingabe: ");
            Console.WriteLine(date);

            Boolean done = false;
            Boolean exception_thrown = false;
            
            Socket sending_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress send_to_address = IPAddress.Parse("127.0.0.1");
            
            IPEndPoint sending_end_point = new IPEndPoint(send_to_address, 11000);

            string text_to_send = date.ToShortDateString();
            byte[] send_buffer = Encoding.ASCII.GetBytes(text_to_send);
            Console.WriteLine("sending to address: {0} port: {1}", sending_end_point.Address, sending_end_point.Port);
            try
            {
                sending_socket.SendTo(send_buffer, sending_end_point);
            }
            catch (Exception send_exception)
            {
                exception_thrown = true;
                Console.WriteLine(" Exception {0}", send_exception.Message);
            }
            if (exception_thrown == false)
            {
                Console.WriteLine("Message has been sent to the broadcast address");
            }
            else
            {
                exception_thrown = false;
                Console.WriteLine("The exception indicates the message was not sent.");
            }
        }
    }
}
