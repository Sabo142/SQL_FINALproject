using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ans2 : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextMeshProUGUI;
    public static int ButtonID = 2;
    public static int clicked = 0;
    public void ReciveAns2(string ans2)
    {
        TextMeshProUGUI.text = ans2;
        gameObject.transform.localScale = Vector3.zero;
        LeanTween.scale(gameObject, Vector3.one, 2);
    }
    public static void ButtonClicked()
    {
        clicked = 1;
    }
}
