using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
public enum AchieveState
{
    puzzle,
    engine,
    mengp,
}
public class LittleGameManager : MonoBehaviour
{
    
    public static LittleGameManager instance;
    public bool[] stateList = new bool[6];
    
    private void Awake()
    {
        instance = this;
    }

    public void Achieve(AchieveState state)
    {
        stateList[(int)state] = true;
    }

    public bool GetAchieveState(AchieveState state)
    {
        return stateList[(int)state];
    }
}
