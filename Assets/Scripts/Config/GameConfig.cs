using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "GameConfig")]
public class GameConfig : ScriptableObject
{
    [Header("小游戏UI")]
    [Tooltip("铸造炉")]
    public GameObject Founderer;

    [Tooltip("冶炼炉")]
    public GameObject Furnace;

    [Tooltip("发电机")]
    public GameObject Dynamo;
}
