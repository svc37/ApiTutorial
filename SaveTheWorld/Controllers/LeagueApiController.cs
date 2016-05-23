using SaveTheWorld.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SaveTheWorld.Controllers
{
    /*
     * Greyson! Since we are using our local machines as our Elastic databases and they are different at the moment
     * I figured it would be easier to use the League Api.  This call just brings back some match data.
     * 
     * 
     * The controller is basically where we would house all of our api calls. 
     */
    public class LeagueApiController : ApiController
    {
        public LeagueApiResponse GetLeagueApiInfo()
        {
            // we would have this url constructed before we get to this call. It would look something like
            // ourElasticSearchUrl/index/document/WhateverDataWeNeed
            string url = "https://na.api.pvp.net/api/lol/na/v2.2/match/1900729148?api_key=da9643c8-6599-4608-adad-ecfe2e8007ce";

            //There are several different ways of doing the reqeust and getting the response, but they basically do the same thing
            //feel free to play around with the different ways if you want.  
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));
            WebResponse response = request.GetResponse();
            StreamReader streamReader = new StreamReader(response.GetResponseStream());
            String responseData = streamReader.ReadToEnd();

            //So far we have made a request to a url, gotten a response from the url, then read the response.
            //This line does two things.  Converts the above string (responseData) into Json and tells the Json what
            //it's "data contract" will be.  (LeagueApiResponse)
            LeagueApiResponse json = Newtonsoft.Json.JsonConvert.DeserializeObject<LeagueApiResponse>(responseData);//Newtonsoft is the .dll that we brought in.
            return json;

            //you'll get a warning for "unreachable code detected" below.  That is becuase this method will stop
            //running once it hits the "return" just above this comment.  Ignore the warning. 

            //Now that we have put the Json into a class we have access to any part of the information.
            int matchId = json.MatchID;
            int participantId = json.Participants.FirstOrDefault().ParticipantID;
            //FirstOrDefault() is used because there is more than 1 participant.
            //this gets the current participant.  Usually used when itterating through them all.

            //this is where we used IEnumberable in the LeagueApiResponse class in the Models folder

        }
    }
}
