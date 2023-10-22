using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score_Room : MonoBehaviour
{
    public APIManager APIManager;
    public UIManager UIManager;
    public ScoreManager ScoreManager;
    public TextMeshProUGUI Winner_name;
    public string EnemyName;
    void Update()
    {
        
    }

    public void OnEnable()
    {
        
        StartCoroutine(GetEnemyScore());
        
    }
    IEnumerator GetEnemyScore()
    {
        
        if(UIManager.currentID == 1)
            APIManager.GetScore(2);
        else
            APIManager.GetScore(1);
        yield return new WaitForSeconds(1);
        if (ScoreManager.score > APIManager.EnemyScore)
        {
            UIManager.NamePrinter(UIManager.NameID.text);
        }
        else
        {
            if (UIManager.currentID == 1)
            {
                APIManager.GetEnemyName(2);
                yield return new WaitForSeconds(1);
                Winner_name.text = EnemyName;
                UIManager.NamePrinter(EnemyName);
            }
            else
            {
                APIManager.GetEnemyName(1);
                yield return new WaitForSeconds(1);
                Winner_name.text = EnemyName;
                UIManager.NamePrinter(EnemyName);
            }
        }
    }
}
