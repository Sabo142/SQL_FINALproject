using TMPro;
using UnityEngine;

public class QuestionBoxText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextMeshProUGUI;
    public void ReciveQuestion(string question)
    {
        TextMeshProUGUI.text = question;
        gameObject.transform.localScale = Vector3.zero;
        LeanTween.scale(gameObject, Vector3.one, 2);
    }
}
