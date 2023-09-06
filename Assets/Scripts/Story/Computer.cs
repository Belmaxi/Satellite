using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : DeviceBase
{
    public override void Active()
    {
        if (LittleGameManager.instance.GetAchieveState(AchieveState.story))
        {
            PlayerManager.instance.Resume();
            return;
        }
        else
        {
            //SoundManager.instance.PlaySound("");
            Instantiate(popObject);
        }
    }
}
