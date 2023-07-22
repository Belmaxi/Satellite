using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "GameConfig")]
public class GameConfig : ScriptableObject
{
    [Tooltip("阳光")]
    public GameObject Sun;

    [Header("植物")]
    [Tooltip("向日葵")]
    public GameObject SunFlower;


    [Tooltip("豌豆射手")]
    public GameObject PeaShooter;
}
