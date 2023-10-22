using TMPro;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

public class UIManager : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private GameObject GetQuestionButton;
    public APIManager _APIManager;
    public TMPro.TMP_InputField QuestionID;
    public TMPro.TMP_InputField NameID;
    [SerializeField] TMP_Text Question;
    [SerializeField] TMP_Text Name;
    [SerializeField] QuestionHolder questionHolder;
    [SerializeField] private GameObject WaitingRoom;
    [SerializeField] private GameObject ReadyRoom;
    [SerializeField] private GameObject GameRoom;
    [SerializeField] private GameObject Finished_waitroom;
    [SerializeField] private GameObject ScoreRoom;
    private List<int> usedQuestionIDs = new List<int>();
    System.Random random = new System.Random();
    public bool readyP1 = false;
    public bool readyP2 = false;
    public string player1_id = "1";
    public int currentID = 1;
    [ContextMenu("name")]
    
    public void ScoreButton()
    {
        Debug.Log(scoreManager.score);
    }
    public void GetQuestionButtonClicked()
    {
        int QuestionID = GetUniqueRandomQuestionID(10);
        _APIManager.GetQuestionWrapper(QuestionID.ToString());
        GetQuestionButton.SetActive(false);
    }
    public void CheckAnswer()
    {
         int questionID = usedQuestionIDs.Last();
        _APIManager.GetAnswerWrapper(questionID.ToString());
    }

    public void AnswerButtonClicked()
    {
        CheckAnswer();
    }
    private int GetUniqueRandomQuestionID(int maxQuestionID)
    {
        int maxAttempts = 10;
        int attempts = 0;
        while (attempts < maxAttempts)
        {
            int randomID = random.Next(1, maxQuestionID + 1);

            if (!usedQuestionIDs.Contains(randomID))
            {
                usedQuestionIDs.Add(randomID);
                return randomID; 
            }

            attempts++;
        }
        _APIManager.SetFinish("1", currentID);
        _APIManager.SetScore(scoreManager.score.ToString(), currentID);
        GameRoom.SetActive(false);
        Finished_waitroom.SetActive(true);
        throw new Exception("No unique QuestionID found after maximum attempts.");
    }
    public void QuestionPrinter(Questions questions)
    {
        questionHolder.GetQuestionAnswer(questions);
    }
    public void NamePrinter(string name)
    {
        Name.text = name;
    }
   public void ReadyButtonClicked()
    {
        StartCoroutine(ReadyButtonActivated());
    }
    IEnumerator ReadyButtonActivated()
    {
        
        _APIManager.GetPlayerName(player1_id);
        yield return new WaitForSeconds(0.5f);
        if (readyP1 == false)
            _APIManager.SetPlayerName(NameID.text, 1);
        else if (readyP1 == true)
        {
            player1_id = "2";
            currentID = 2;
            readyP2 = true;
            _APIManager.SetPlayerName(NameID.text, 2);
        }
        ReadyRoom.SetActive(false);
        WaitingRoom.SetActive(true);
    }

    
}
