using TMPro;
using UnityEngine;

public class Ans1 : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextMeshProUGUI;
    public static int ButtonID = 1;
    public static int clicked = 0;
    public void ReciveAns1(string ans1)
    {
        TextMeshProUGUI.text = ans1;
        gameObject.transform.localScale = Vector3.zero;
        LeanTween.scale(gameObject, Vector3.one, 2);
    }
    public static void ButtonClicked()
    {
        clicked = 1;
    }
}