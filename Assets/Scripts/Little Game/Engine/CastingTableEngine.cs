using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingTableEngine : DeviceBase
{
    public override void Active()
    {
        if (LittleGameManager.instance.GetAchieveState(AchieveState.engine))
        {
            PlayerManager.instance.Resume();
            return;
        }
        Instantiate(popObject);
    }
}
