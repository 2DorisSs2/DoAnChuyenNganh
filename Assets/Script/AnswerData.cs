using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class AnswerData : Singleton<AnswerData>
{
    public Data_Answer_Manager data_manager;
    public List<string> An_UI = new List<string>();
    public List<QuestionData> usedQuestions = new List<QuestionData>();
    public QuestionData[] questiondatas;
    public string correctAnswer;
    public string question;
    public void Awake()
    { 
        questiondatas = data_manager.LoadAllQuestionData();
        //GetValue();
    }
    public void GetValue()
    {
        An_UI.Clear();
        if (questiondatas != null && questiondatas.Length > 0)
        {
            List<QuestionData> availableQuestions = new List<QuestionData>(questiondatas);
            availableQuestions.RemoveAll(q => usedQuestions.Contains(q));
            // lấy ra một phần tử bất kỳ
            if(availableQuestions.Count > 0)
            {
                int i = Random.Range(0, questiondatas.Length);
                QuestionData randomquestion = questiondatas[i];
                usedQuestions.Add(randomquestion);
                question = randomquestion.question;
                correctAnswer = randomquestion.correctAnswer;
                An_UI.Add(randomquestion.correctAnswer);
                An_UI.AddRange(randomquestion.wrongAnswers);
            }
            else
            {
                usedQuestions.Clear();
                GetValue();
            }
            
        }
    }
}
