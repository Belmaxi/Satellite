using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnace : DeviceBase
{
    public override void Active()
    {
        if (!LittleGameManager.instance.GetAchieveState(AchieveState.mengp))
        {
            Instantiate(popObject);
        }
        else
        {
            PlayerManager.instance.Resume();
        }
    }
}
