using UnityEngine;
using UnityEngine.UI;

public class QuestionHolder : MonoBehaviour
{
    [SerializeField] QuestionBoxText QuestionBoxText;
    [SerializeField] Ans1 ans1;
    [SerializeField] Ans2 ans2;
    [SerializeField] Ans3 ans3;
    [SerializeField] Ans4 ans4;
    [SerializeField] Button Ans1;
    [SerializeField] Button Ans2;
    [SerializeField] Button Ans3;
    [SerializeField] Button Ans4;
    public void GetQuestionAnswer(Questions questions)
    {
        QuestionBoxText.ReciveQuestion(questions.text);
        ans1.ReciveAns1(questions.ans1);
        ans2.ReciveAns2(questions.ans2);
        ans3.ReciveAns3(questions.ans3);
        ans4.ReciveAns4(questions.ans4);
    }
    private void Awake()
    {
        Ans1.onClick.AddListener(NoParametersOnClick);
        Ans2.onClick.AddListener(NoParametersOnClick);
        Ans3.onClick.AddListener(NoParametersOnClick);
        Ans4.onClick.AddListener(NoParametersOnClick);
    }
    private void NoParametersOnClick()
    {
        Debug.Log("Answer Pressed");
    }
}
