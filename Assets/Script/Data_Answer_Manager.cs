using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using static JsonDataReader;

public class Data_Answer_Manager : MonoBehaviour
{
    public string fileName = "Question_Data";
    
    public QuestionData[] LoadAllQuestionData()
    {
        QuestionData[] datalist = null;
        TextAsset textAsset = Resources.Load<TextAsset>(fileName);
        if (textAsset != null)
        {
            string json_sources = textAsset.text;
            QuestionDataArrayWrapper wrapper = JsonUtility.FromJson<QuestionDataArrayWrapper>(json_sources);
            datalist = wrapper.questions;
        }
        return datalist;
    }

    //private void Start()
    //{
    //    Debug.Log(LoadAllQuestionData());
    //    QuestionData[] data = LoadAllQuestionData();
    //    foreach (QuestionData person in data)
    //    {
    //        Debug.Log("question: " + person.question);
    //    }
    //}
}
