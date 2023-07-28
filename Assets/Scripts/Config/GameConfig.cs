using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "GameConfig")]
public class GameConfig : ScriptableObject
{
    [Header("С��ϷUI")]
    [Tooltip("����¯")]
    public GameObject Founderer;

    [Tooltip("ұ��¯")]
    public GameObject Furnace;

    [Tooltip("�����")]
    public GameObject Dynamo;
}
