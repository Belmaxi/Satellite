using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageController : MonoBehaviour
{
    [SerializeField] private TMP_Text m_Text;

    [SerializeField] private List<string> strings = new List<string>();
    [SerializeField] private float typeSpeed;
    [SerializeField] private float speed;
    private GameObject StartObj;


    private void Start()
    {
        StartObj = GameObject.Find("StartCanva");
        for(int i =  0; i < strings.Count; i++)
        {
            string s = strings[i];
            DoTypeString(s);
        }

        StartObj.SetActive(true);
        gameObject.SetActive(false);
    }

    IEnumerator DoTypeString(string type)
    {
        string now = "";
        for(int i = 0; i < type.Length; i++)
        {
            yield return new WaitForSeconds(typeSpeed);
            now = now + type[i];
            m_Text.text = now;
            
        }
        yield return new WaitForSeconds(speed);
    }
}
