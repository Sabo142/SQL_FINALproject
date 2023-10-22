using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finished_WaitRoom : MonoBehaviour
{
    public APIManager _apiManager;
    public UIManager UIManager;
    [SerializeField] private GameObject ScoreRoom;
    public bool isPlayer1Finished = false;
    public bool isPlayer2Finished = false;
    void Update()
    {
        if(isPlayer1Finished && isPlayer2Finished)
        {
            gameObject.SetActive(false);
            ScoreRoom.SetActive(true);
        }
    }
    private void OnEnable()
    {
        StartCoroutine(CheckIfPlayerFinished());
    }
    IEnumerator CheckIfPlayerFinished()
    {
        _apiManager.GetFinish(1);
        _apiManager.GetFinish(2);
        yield return new WaitForSeconds(2);
        StartCoroutine(CheckIfPlayerFinished());
    }
}
