using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class APIManager : MonoBehaviour
{
    
    const string API_URL = "https://localhost:7244/api/";
    [SerializeField] UIManager uiManager;
    [SerializeField] ScoreManager scoreManager;
    public Score_Room ScoreRoom;
    public Finished_WaitRoom finished_waitRoom;
    public int EnemyScore = 0;
    public void SetScore(string score, int id)
    {
        StartCoroutine(SetPlayerScore(score, id));
    }
    IEnumerator SetPlayerScore(string score, int id)
    {
        WWWForm form = new WWWForm();
        form.AddField("PlayerScore", score);
        form.AddField("id", id);
        using (UnityWebRequest request = UnityWebRequest.Post(API_URL + "players/ChangeScore", form))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Success Score");
            }
            else
                Debug.Log("Fail Score");
        }
    }
    public void SetFinish(string finish, int id)
    {
        StartCoroutine(SetPlayerFinish(finish, id));
    }
    IEnumerator SetPlayerFinish(string finish, int id)
    {
        WWWForm form = new WWWForm();
        form.AddField("PlayerFinished", finish);
        form.AddField("id", id);
        using (UnityWebRequest request = UnityWebRequest.Post(API_URL + "players/PlayerFinish", form))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Working!");
            }
            else
            {
                Debug.LogError("Error updating player finish: " + request.error);
            }
        }
    }

    public void GetScore(int id)
    {
        StartCoroutine(GetPlayerScore(id));
    }

    IEnumerator GetPlayerScore(int id)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(API_URL + "Players/GetScore/" + id))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                int.TryParse(request.downloadHandler.text ,out EnemyScore);
            }
        }
    }
    public void GetPlayerName(string id)
    {
        StartCoroutine(GetName(id));
        
    }
    IEnumerator GetName(string id)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(API_URL + "Players/Get/" + id))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                if (request.downloadHandler != null)
                {
                    if (request.downloadHandler.text != "")
                    {
                        uiManager.readyP1 = true;
                    }
                    else
                        uiManager.readyP1 = false;
                }
                else
                    uiManager.readyP1 = false;
            }
            else
            {
                Debug.Log("Error, name");
                uiManager.readyP1 = false;
            }
        }
    }

    public void GetEnemyName(int id)
    {
        StartCoroutine(GetEnemy_Name(id));
    }
    IEnumerator GetEnemy_Name(int id)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(API_URL + "Players/Get/" + id))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                ScoreRoom.EnemyName = request.downloadHandler.text;
                Debug.Log("Enemy name received: " + ScoreRoom.EnemyName);
            }
        }
    }
    public void GetPlayer_2Run()
    {
        StartCoroutine(GetPlayer2Name());
    }
    IEnumerator GetPlayer2Name()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(API_URL + "Players/Get/" + 2))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                if (request.downloadHandler != null)
                {
                    if (request.downloadHandler.text != "")
                        uiManager.readyP2 = true;
                }
            }
            else
                Debug.Log("Error ready player 2, cant get name");
        }
    }
    public void SetPlayerName(string newName, int id)
    {
        StartCoroutine(ChangePlayerName(newName,id));
    }
    IEnumerator ChangePlayerName(string newName, int id)
    {
        WWWForm form = new WWWForm();
        form.AddField("Name", newName);
        form.AddField("id", id.ToString());
        using (UnityWebRequest request = UnityWebRequest.Post(API_URL + "players/ChangeName", form))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                
            }
            else
            {
                Debug.LogError("Error updating player name: " + request.error);
            }
        }
    }
    /*public void GetReady(string isReady)
    {
        
        StartCoroutine(ChangePlayerReady(isReady));
    }*/
    
    public void GetFinish(int id)
    {
       StartCoroutine(GetPlayerFinish(id));
    }

    IEnumerator GetPlayerFinish(int id)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(API_URL + "Players/GetFinish/" + id))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                if (request.downloadHandler != null)
                {
                    if (id == 1)
                    {
                        if (request.downloadHandler.text != "0")
                        {
                            finished_waitRoom.isPlayer1Finished = true;
                        }
                    }
                    if (id == 2)
                    {
                        if (request.downloadHandler.text != "0")
                        {
                            finished_waitRoom.isPlayer2Finished = true;
                        }
                    }
                }
            }
            else
                Debug.Log("error - Get finish not work");
        }
    }

    IEnumerator ChangePlayerReady(string isReady)
    {
        WWWForm form = new WWWForm();
        form.AddField("PlayerIsReady", isReady);
        using (UnityWebRequest request = UnityWebRequest.Post(API_URL + "players/ChangeReady", form))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Player is now ready: " + isReady);
            }
            else
            {
                Debug.LogError("Player couldn't be set to ready: " + request.error);
            }
        }
    }

    /*public void CheckPlayerReady(int ready)
    {
        StartCoroutine(CheckReady(ready));
    }
    IEnumerator CheckReady(int ready)
    {
        WWWForm form = new WWWForm();
        form.AddField("IsPlayerReady", ready);
        
    }*/
    IEnumerator GetQuestion(string id)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(API_URL + "Questions/" + id))
        {
            yield return request.SendWebRequest();
            switch (request.result)
            {
                case UnityWebRequest.Result.Success:
                    Debug.Log(request.downloadHandler.text);
                    try
                    {
                        Questions question = JsonUtility.FromJson<Questions>(request.downloadHandler.text);
                        uiManager.QuestionPrinter(question);
                    }
                    catch (System.Exception ex)
                    {
                        Debug.Log(ex.Message + "," + ex.GetBaseException().Message);
                        throw;
                    }
                    break;
            }
        }
    }
    IEnumerator GetCurrectAns(string id)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(API_URL + "players/GetAns/" + id))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log(request.downloadHandler.text);
                try
                {
                    int responseValue;
                    if (int.TryParse(request.downloadHandler.text, out responseValue) && responseValue == Ans1.ButtonID && Ans1.clicked == 1)
                    {
                        Debug.Log("Button 1");
                        scoreManager.Score();
                        uiManager.GetQuestionButtonClicked();
                    }
                    else if (int.TryParse(request.downloadHandler.text, out responseValue) && responseValue == Ans2.ButtonID && Ans2.clicked == 1)
                    {
                        Debug.Log("Button 2");
                        scoreManager.Score();
                        uiManager.GetQuestionButtonClicked();
                    }
                    else if (int.TryParse(request.downloadHandler.text, out responseValue) && responseValue == Ans3.ButtonID && Ans3.clicked == 1)
                    {
                        Debug.Log("Button 3");
                        scoreManager.Score();
                        uiManager.GetQuestionButtonClicked();
                    }
                    else if (int.TryParse(request.downloadHandler.text, out responseValue) && responseValue == Ans4.ButtonID && Ans4.clicked == 1)
                    {
                        Debug.Log("Button 4");
                        scoreManager.Score();
                        uiManager.GetQuestionButtonClicked();
                    }
                    else
                    {
                        uiManager.GetQuestionButtonClicked();
                    }
                }
                catch (System.Exception ex)
                {
                    Debug.Log(ex.Message + "," + ex.GetBaseException().Message);
                    throw;
                }
            }
        }
    }
    public void GetQuestionWrapper(string id)
    {
        StartCoroutine(GetQuestion(id));
    }

    public void GetAnswerWrapper(string id)
    {
        StartCoroutine(GetCurrectAns(id));
    }
}
        
