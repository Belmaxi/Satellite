using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TV : DeviceBase
{
    [SerializeField] private VideoPlayer player;
    public override void Active()
    {
        player.gameObject.SetActive(true);
        player.Play();
        SoundManager.instance.StopMusic();
    }
}
