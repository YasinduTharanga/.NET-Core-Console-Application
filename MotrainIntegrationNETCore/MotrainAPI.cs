using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MotrainIntegrationNETCore
{
    public class MotrainAPI
    {
        private readonly DataContext _context;

        public MotrainAPI()
        {
            _context = new DataContext();
        }

        public void ProcessMotrainAPI(int userID, int iCSID, string courseName, int motrainStatus, int coursePoints, string email, string fullName, string address, string city, string state, string country)
        
        {

            //try
            //{
            //    //Check the available Motrain teams
            //    var httpTeamWebRequest = (HttpWebRequest)WebRequest.Create(motrianRequestTeamAPIUrl);
            //    httpTeamWebRequest.ContentType = "application/json";
            //    httpTeamWebRequest.Method = "GET";
            //    var motrainTeamAPIresult = string.Empty;
            //    var existingPlayer = "";
            //    var createdPlayerDtails = "";
            //    var awardCoinstoMotrainPlayer = "";
            //    //string createdPlayerDtails = new JObject();
            //    httpTeamWebRequest.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + motrainAPIKey);
            //    try
            //    {

            //        using (var motrainTeamResponse = httpTeamWebRequest.GetResponse() as HttpWebResponse)
            //        {
            //            if (httpTeamWebRequest.HaveResponse && motrainTeamResponse != null)
            //            {
            //                using (var readerData = new StreamReader(motrainTeamResponse.GetResponseStream()))
            //                {
            //                    //Motrain teams API response
            //                    motrainTeamAPIresult = readerData.ReadToEnd();
            //                    // JSON array string into a JArray object
            //                    JArray teamArray = JArray.Parse(motrainTeamAPIresult);
            //                    //creates an empty JSON object
            //                    JObject jsonObject = new JObject();

            //                    foreach (JObject item in teamArray)
            //                    {
            //                        teamID = item["id"].ToString();
            //                        //Check Existing Motrain Player
            //                        existingPlayer = checkPlayer.CheckExistingPlayer(teamID, email);
            //                        // Parse the JSON string array to json array
            //                        JArray jsonExistingPlayerArray = JArray.Parse(existingPlayer);

            //                        if (jsonExistingPlayerArray.Count == 0)
            //                        {
            //                            //Create New Motrain Player
            //                            createdPlayerDtails = createPlayer.CreateMotrainPlayer(teamID, email, firstName, lastName
            //                                , adderss1, adderss2, city, state, country);

            //                            // Convert JSON string to JObject
            //                            JObject jsonObjectCreatePlayer = JsonConvert.DeserializeObject<JObject>(createdPlayerDtails);
            //                            motrainPlayerUserID = jsonObjectCreatePlayer["id"].ToString();
            //                            //Awards coins to Motrain Newly Player
            //                            awardCoinstoMotrainPlayer = awardCoins.AwardCoinstoMotrainPlayer(motrainPlayerUserID, coursePoints, courseName);
            //                            if (awardCoinstoMotrainPlayer.Length > 0)
            //                            {
            //                                using (SqlConnection conn = new SqlConnection(connectionString))
            //                                {
            //                                    conn.Open();
            //                                    //Update Motrain table
            //                                    using (SqlCommand cmd = new SqlCommand("APIUpdateMotrainStatus", conn))
            //                                    {
            //                                        cmd.CommandType = CommandType.StoredProcedure;
            //                                        cmd.Parameters.Add("@motrainStatus", SqlDbType.Int).Value = 1;
            //                                        cmd.Parameters.Add("@UserID", SqlDbType.Text).Value = userID;
            //                                        cmd.Parameters.Add("@iCSID", SqlDbType.Int).Value = iCSID;
            //                                        cmd.Parameters.Add("@motrainPlayerUserID", SqlDbType.Text).Value = motrainPlayerUserID;

            //                                        SqlDataReader dreader = cmd.ExecuteReader();

            //                                        if (dreader.Read())
            //                                        {
            //                                            string finalresult = dreader["result"].ToString();

            //                                        }
            //                                        dreader.Close();
            //                                    }
            //                                    conn.Close();
            //                                }

            //                            }
            //                        }
            //                        else
            //                        {
            //                            foreach (JObject existingPlayerObject in jsonExistingPlayerArray)
            //                            {

            //                                motrainPlayerUserID = existingPlayerObject["id"].ToString();
            //                                //Awards coins to Motrain Newly Player
            //                                awardCoinstoMotrainPlayer = awardCoins.AwardCoinstoMotrainPlayer(motrainPlayerUserID, coursePoints, courseName);
            //                                if (awardCoinstoMotrainPlayer.Length > 0)
            //                                {
            //                                    using (SqlConnection conn = new SqlConnection(connectionString))
            //                                    {
            //                                        conn.Open();
            //                                        //Update Motrain table
            //                                        using (SqlCommand cmd = new SqlCommand("APIUpdateMotrainStatus", conn))
            //                                        {
            //                                            cmd.CommandType = CommandType.StoredProcedure;
            //                                            cmd.Parameters.Add("@motrainStatus", SqlDbType.Int).Value = 1;
            //                                            cmd.Parameters.Add("@UserID", SqlDbType.Text).Value = userID;
            //                                            cmd.Parameters.Add("@iCSID", SqlDbType.Int).Value = iCSID;
            //                                            cmd.Parameters.Add("@motrainPlayerUserID", SqlDbType.Text).Value = motrainPlayerUserID;

            //                                            SqlDataReader dreader = cmd.ExecuteReader();

            //                                            if (dreader.Read())
            //                                            {
            //                                                string finalresult = dreader["result"].ToString();

            //                                            }
            //                                            dreader.Close();
            //                                        }
            //                                        conn.Close();
            //                                    }

            //                                }
            //                            }

            //                        }

            //                    }

            //                    //string resultJson = jsonObject.ToString();

            //                    MotrainIntegrationNETCore.Logger.Debug("Json Response:" + teamArray);


            //                }
            //            }
            //        }
            //    }
            //    catch (WebException e)
            //    {
            //        if (e.Response != null)
            //        {
            //            using (var errorResponse = (HttpWebResponse)e.Response)
            //            {
            //                using (var readererorrDate = new StreamReader(errorResponse.GetResponseStream()))
            //                {
            //                    string error = readererorrDate.ReadToEnd();
            //                    motrainTeamAPIresult = error;
            //                    MotrainIntegrationNETCore.Logger.Debug("Json Response Error:" + motrainTeamAPIresult);
            //                }
            //            }

            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    string error = ex.ToString();
            //    MotrainIntegrationNETCore.Logger.Error(error);
            //    throw;
            //}

        }

        
    }
}
