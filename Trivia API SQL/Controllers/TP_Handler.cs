using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;

namespace TriviaAPI
{
    public class DBHandler
    {
        const string CONNECTION_STRING = "Server=localhost; database=test; UID=root; password=1593572486Kr";
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader reader;
        public string SetPlayerScore = $"UPDATE `test`.`players` SET `Score` = '*' WHERE `PlayerID` = ";
        const string GetPlayerScoreQuery = "SELECT Score FROM test.players WHERE PlayerID =";
        public string SetPlayerFinish = $"UPDATE `test`.`players` SET `Finish` = '*' WHERE `PlayerID` =";
        const string GetPlayerFinishQuery = "SELECT Finish FROM test.players WHERE PlayerID =";
        const string GetPlayerQuery = "SELECT Name FROM test.players WHERE PlayerID = ";
        const string GetQuestionQuery = "SELECT * FROM test.questions WHERE QuestionId = ";
        public string GetCurrectAnsOne = "SELECT CurrectID FROM test.questions WHERE QuestionID = ";
        public string AddPlayerQuery = $"UPDATE `test`.`players` SET `Name` = '*' WHERE `PlayerID` = ";
        public string PlayerIsReady = $"UPDATE `test`.`players` SET `Ready` = 1 WHERE `PlayerID` = {playerReadyID}";
        public static int playerID = 1;
        public static int playerReadyID = 1;
        public void RunAddQuery(string query)
        {
            try
            {
                Connect();
                Console.WriteLine(playerID);
                cmd = new MySqlCommand(query, con);
                reader = cmd.ExecuteReader();
            }
            catch (Exception ex) { }
            Disconnect();
        }

        public string RunStringQuery(string query)
        {
            string result = null;
            try
            {
                Connect();
                cmd = new MySqlCommand(query, con);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result = reader.GetString(0);
                }
            }
            catch (Exception ex) { }
            Disconnect();
            return result;
        }

        public Question RunQuestionQuery(string query)
        {
            Question result = null;
            try
            {
                Connect();
                cmd = new MySqlCommand(query, con);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result = new Question(reader.GetString("Text"),
                        reader.GetString("Ans1"),
                        reader.GetString("Ans2"),
                        reader.GetString("Ans3"),
                        reader.GetString("Ans4"),
                        reader.GetInt16("CurrectID"));
                }
            }
            catch (Exception ex) { }
            Disconnect();
            return result;
        }

        public int RunPlayerReady(string query)
        {
            
            try
            {
                Connect();
                
                
                    cmd = new MySqlCommand(query, con);
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {

                        int result = reader.GetInt32("Ready");
                        if(result == 1)
                        {
                        return result;
                    }

                    }
                
            }
            catch (Exception ex) { }
            Disconnect();
            return -1;
            
        }


        public string GetCurrectAns(int questionID)
        {
            return RunStringQuery(GetCurrectAnsOne + questionID);
        }

        public string GetPlayerName(int id)
        {
            return RunStringQuery(GetPlayerQuery + id);
        }

        public Question GetQuestion(int id)
        {
            return RunQuestionQuery(GetQuestionQuery + id);
        }

        public string GetPlayerFinish(int id)
        {
            return RunStringQuery(GetPlayerFinishQuery + id);
        }

        public void AddPlayer(string name, int id)
        {
            Console.WriteLine(id);
            playerID = id;
            RunAddQuery(AddPlayerQuery.Replace("*", name) + id.ToString());
           //playerID++;
        }
        public void PlayerReady(string ready)
        {
            RunAddQuery(PlayerIsReady.Replace("*", ready));
            //playerReadyID++;
        }
        public void SetScore(string score, int id)
        {
            RunAddQuery(SetPlayerScore.Replace("*", score) + id.ToString());

        }

        public string GetScore(int id)
        {
            return RunStringQuery(GetPlayerScoreQuery + id);
        }
        public void Finish(string finish, int id)
        {
            playerID = id;
            RunAddQuery(SetPlayerFinish.Replace("*", finish) + id.ToString());
            
        }
        
        public void Connect()
        {
            try
            {
                //connect to my database
                con = new MySqlConnection(CONNECTION_STRING);
                con.Open();
                Console.WriteLine(con.State);
                
            }
            catch
            {
                con.Close();
            }
        }

        public void Disconnect()
        {
            con.Close();
        }
    }
}
