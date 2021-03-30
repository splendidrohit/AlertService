using NotificationService.WebServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationService
{
    public class mainclass
    {
         static void Main(string[] args)
        {
            call();
        }

        static async void call()
        {
            string req = "{\"team\": {\"name\": \"claims\"}, \"developers\": [{\"name\": \"someone\", \"phone_number\":\"9999999999\"}, {\"name\": \"somebody\", \"phone_number\": \"9111111111\"}]}";

            string req2 = "{\"name\": \"claims\", \"message\": \"Too many 5xx!\"}";
            AlertWebServices service = new AlertWebServices();
            Response res=service.CreateTeam(req);
            Response res2 = await service.ReceiveAlertAsync(req);
            Console.WriteLine(res2.ErrororSuccessMessage);
            Console.ReadKey();
        }
    }
}
