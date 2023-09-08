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
    [SerializeField] private GameObject StartObj;
    [SerializeField] private SoundParameter soundParameter;


    private void Start()
    {
        StartCoroutine(DoTypeString());
    }

    IEnumerator DoTypeString()
    {
        for(int k = 0;k< strings.Count;k++)
        {
            string now = "";
            string type = strings[k];
            for (int i = 0; i < type.Length; i++)
            {
                yield return new WaitForSeconds(typeSpeed);
                now = now + type[i];
                m_Text.text = now;
                SoundManager.instance.PlaySound("typecharacter");
            }
            yield return new WaitForSeconds(speed);
        }
        SoundManager.instance.PlayMusic("Startbgm");
        StartObj.SetActive(true);
        gameObject.SetActive(false);
    }
}
