


namespace NotificationService.WebServices
{
    using NotificationService.Models;
    using NotificationService.Storage;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class AlertWebServices
    {
        IStorage storage;
        public AlertWebServices()
        {
            storage = InMemoryCache.GetInstance();
        }

        public Response CreateTeam(string request)
        {
            Response response = new Response();
            try
            {
                string teamName = Utils.GetTeamName(request);
                List<Developer> developers = Utils.GetDevelopers(request);

                Team team = new Team(teamName);
                foreach (Developer dev in developers)
                {
                    team.AddDeveloper(dev);
                }
                storage.SaveTeam(team);
                response.Success = true;
                response.ResponseCode = 200;
                response.ErrororSuccessMessage = "Successfully Saved";
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.ResponseCode = 500;
                response.ErrororSuccessMessage = ex.Message;
            }

            return response;
        }

        public async Task<Response> ReceiveAlertAsync(string request)
        {
            Response response = new Response();
            try
            {
                string teamName = Utils.GetTeamName(request);
                string message = Utils.GetMessage(request);

                Team team = storage.GetTeam(teamName);
                Developer dev = team.GetSomeDeveloper();
                Dictionary<string,string> req = new Dictionary<string, string>();
                req.Add("phone_number", dev.Phone);
                req.Add("message", message);
                HttpClient client = new HttpClient();
                var content = new FormUrlEncodedContent(req);

                var res = await client.PostAsync("https://run.mocky.io/v3/fd99c100-f88a-4d70-aaf7-393dbbd5d99f", content);

                response.Success = true;
                response.ResponseCode = 200;
                response.ErrororSuccessMessage = "Successfully sent alert " + res;

            }
            catch(Exception ex)
            {
                response.Success = false;
                response.ResponseCode = 500;
                response.ErrororSuccessMessage = ex.Message;
            }

            return response;
        }
    }
}
