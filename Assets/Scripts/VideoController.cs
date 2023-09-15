using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    private VideoPlayer player;
    [SerializeField] private GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<VideoPlayer>();
        player.loopPointReached += Show;
    }

    private void Show(VideoPlayer source)
    {
        print(1);
        StartCoroutine(DoTransport(1f));
    }

    IEnumerator DoTransport(float tm)
    {
        TransportorManager.instance.blackPanel.SetActive(true);
        float timer = 0f;
        while (timer <= tm)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            TransportorManager.instance.GetPanel().color = Color.Lerp(new Color(0, 0, 0, 0), new Color(0, 0, 0, 1), timer / tm);
            timer += Time.deltaTime;
        }
        obj.SetActive(true);
    }

}
