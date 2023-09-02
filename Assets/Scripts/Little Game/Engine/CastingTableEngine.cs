using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingTableEngine : DeviceBase
{
    public override void Active()
    {
        Instantiate(popObject);
    }
}
