using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempController : MonoBehaviour
{
    private Scrollbar bar;
    public Image timerBar;
    public float speed = 1f;
    public float power = 0.1f;

    public float downLimit = 0.5f;
    public float upLimit = 0.9f;

    public float timer = 8f;
    public AudioSource audioSource;
    private void Start()
    {
        StartCoroutine(DoTimeDecline());
        bar = GetComponentInChildren<Scrollbar>();
        bar.size = 0.7f;
        timer = 8f;
    }
    void Update()
    {
        bar.size -= speed * Time.deltaTime;
        if(bar.size <= downLimit || bar.size >= upLimit)
        {
            PlayerManager.instance.Resume();
            SoundManager.instance.PlaySound("error");
            Destroy(gameObject.transform.parent.parent.gameObject);
        }
        Jump();
        if (isok())
        {
            PlayerManager.instance.Resume();
            LittleGameManager.instance.Achieve(AchieveState.mengp);
            NPCManager.instance.GetController(1).ShowMark();
            ArrowManager.instance.GetArrow(1).SetActive(false);
            SoundManager.instance.PlaySound("rightchoice");
            audioSource.Stop();
            Destroy(gameObject.transform.parent.parent.gameObject);
        }

    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            bar.size += power;
        }
    }

    bool isok()
    {
        if(timerBar.fillAmount < 0.01f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator DoTimeDecline()
    {
        float tmpTimer = timer;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            timerBar.fillAmount = timer / tmpTimer;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
