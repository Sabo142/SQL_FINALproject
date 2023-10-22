using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ans4 : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextMeshProUGUI;
    public static int ButtonID = 4;
    public static int clicked = 0;
    public void ReciveAns4(string ans4)
    {
        TextMeshProUGUI.text = ans4;
        gameObject.transform.localScale = Vector3.zero;
        LeanTween.scale(gameObject, Vector3.one, 2);
    }
    public static void ButtonClicked()
    {
        clicked = 1;
    }
}
