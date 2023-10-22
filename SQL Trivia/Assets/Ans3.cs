using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ans3 : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextMeshProUGUI;
    public static int ButtonID = 3;
    public static int clicked = 0;
    public void ReciveAns3(string ans3)
    {
        TextMeshProUGUI.text = ans3;
        gameObject.transform.localScale = Vector3.zero;
        LeanTween.scale(gameObject, Vector3.one, 2);
    }
    public static void ButtonClicked()
    {
        clicked = 1;
    }
}
