

namespace NotificationService
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using NotificationService.Models;
    using System;
    using System.Collections.Generic;

    public class Utils
    {
        public static JObject ParseRequest(string request)
        {
            return JObject.Parse(request);
        }

        public static string GetTeamName(string request)
        {
            var obj = ParseRequest(request);

            try
            {
                return (string)obj["team"]["name"];
            }
            catch(Exception ex)
            {
                throw new Exception("Invalid request , name not found", ex);
            }
        }


        public static string GetMessage(string request)
        {
            var obj = ParseRequest(request);

            try
            {
                return (string)obj["message"];
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid request , message not found", ex);
            }
        }

        public static List<Developer> GetDevelopers(string request)
        {
            dynamic dynJson = JsonConvert.DeserializeObject(request);
            
            List<Developer> developers = new List<Developer>(); 
            try
            {
                foreach(var dev in dynJson.developers)
                {
                    string name = (string)dev.name;
                    string phone = (string)dev.phone_number;

                    developers.Add(new Developer(name, phone));
                }

                return developers;
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid request , Developers not found", ex);
            }


        }
    }
}
