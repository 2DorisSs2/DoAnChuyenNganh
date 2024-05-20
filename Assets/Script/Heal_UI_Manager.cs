using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heal_UI_Manager : MonoBehaviour
{
    public List<Image> list_img_health;
    public int currentIndex = 0;
    public float moveSpeed = 10f;
    public float fadeSpeed = 0.5f;
    private bool isMoving = true;

    private void Start()
    {
        GetAllComponentsImage();
    }
    //private void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.Space))
    //    {
    //        DropHealth();
    //        Debug.Log(currentIndex);
    //    }
    //}
    public void GetAllComponentsImage()
    {
        if (list_img_health == null)
            list_img_health = new List<Image>();
        list_img_health.Clear();

        Image[] images = GetComponentsInChildren<Image>();
       
        foreach (Image img in images)
        {
            
            if (img.gameObject != gameObject)
            {
                list_img_health.Add(img);
            }
        }
    }

    public void DropHealth()
    {
        StartCoroutine(MoveAndFade());
    }

    IEnumerator MoveAndFade()
    {
        float yPos = list_img_health[currentIndex].rectTransform.position.y;
        while(yPos > 400f)
        {
            yPos -= moveSpeed * Time.deltaTime;
            Debug.Log(yPos);
            list_img_health[currentIndex].rectTransform.position = new Vector3(list_img_health[currentIndex].rectTransform.position.x, yPos, list_img_health[currentIndex].rectTransform.position.z);

            Color currentColor = list_img_health[currentIndex].color;
            float newAlpha = Mathf.MoveTowards(currentColor.a,0f,fadeSpeed * Time.deltaTime);
            list_img_health[currentIndex].color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);
            yield return null;
        }
        list_img_health[currentIndex].gameObject.SetActive(false);
        currentIndex++;
        if (currentIndex >= list_img_health.Count)
        {
            Debug.LogError("Thua");
        }
    }
}
