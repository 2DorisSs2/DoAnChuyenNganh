using UnityEngine;
using System.Collections.Generic;

public class JsonDataReader : MonoBehaviour
{
    public string jsonFileName = "Question_Data";


    //[System.Serializable]
    //public class QuestionDataArrayWrapper
    //{
    //    public QuestionData[] questions;
    //}

    private void Start()
    {
        //PersonData[] data =  LoadJsonData();
        //foreach (PersonData person in data)
        //{
        //    Debug.Log("Name: " + person.name + ", Age: " + person.age);
        //}
        //QuestionData[] data = LoadJsonData();
        //Debug.Log(data.Length);
        //foreach (QuestionData person in data )
        //{
        //    Debug.Log("question: " + person.question);
        //}
    }

    //private QuestionData[] LoadJsonData()
    //{
    //    QuestionData[] datalist = null;
    //    string jsonFilePath = "Question_Data"; // Đường dẫn tương đối đến tệp JSON trong thư mục Resources

    //    TextAsset jsonFile = Resources.Load<TextAsset>(jsonFileName);

    //    if (jsonFile != null)
    //    {
    //        QuestionDataArrayWrapper data = JsonUtility.FromJson<QuestionDataArrayWrapper>(jsonFile.text);
    //        datalist = data.questions;
    //        return datalist;
    //    }
    //    else
    //    {
    //        Debug.LogError("JSON file not found at path: " + jsonFilePath);
    //        return null;
    //    }
    //}
}
