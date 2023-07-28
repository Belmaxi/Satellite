using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnace : DeviceBase
{
    internal enum State
    {
        Idel,
        Work,
    }

    private State state = State.Idel;
    public override void Active()
    {
        throw new System.NotImplementedException();
    }
}
