using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class List_Answer_Dialog : MonoBehaviour
{
    public Transform gridRoot;
    public AnswerUi AnswerUIPb;
    public Text text_question;
    public Button_Controller[] list_btn;
    public AnswerUi[] list_an_UI;

    public void Start()
    {
        Show();
    }
    public void Show()
    {
        
        AnswerData.Instance.GetValue();
        UpdateUI();
        CheckState();
    }

    public void UpdateUI()
    {
        var items = AnswerData.Instance.An_UI;
        if (items == null || items.Count <= 0 || !gridRoot || !AnswerUIPb) return;
        ClearChilds();
        Shuffle(items);
        for (int i = 0; i < items.Count; i++)
        {
            string answerText = items[i];
            var answerClone = Instantiate(AnswerUIPb,Vector3.zero,Quaternion.identity);
            answerClone.transform.SetParent(gridRoot);
            answerClone.transform.localPosition = Vector3.zero;
            answerClone.transform.localScale = Vector3.one;
            answerClone.textAnswer.text = answerText;
        }
        text_question.text = AnswerData.Instance.question;
    }
    public void ClearChilds()
    {
        //Debug.Log(gridRoot.childCount);
        //Debug.Log(gridRoot);
        if (!gridRoot || gridRoot.childCount <= 0) return;
        for (int i = 0; i < gridRoot.childCount; i++)
        {
            var child = gridRoot.GetChild(i);
            if (child)
            {
                Destroy(child.gameObject);
            }
        }
    }
    public void Shuffle<T>(List<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
    public void CheckState()
    {
        list_btn = GetComponentsInChildren<Button_Controller>();
        list_an_UI = GetComponentsInChildren<AnswerUi>();
        for(int i = 0; i < list_an_UI.Length; i++)
        {
            if (list_an_UI[i].textAnswer.text == AnswerData.Instance.correctAnswer)
            {
                list_btn[i].buttonValue = true;
            }
            else
            {
                list_btn[i].buttonValue = false;
            }
        }
    }
}

