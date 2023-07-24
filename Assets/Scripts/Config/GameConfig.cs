using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "GameConfig")]
public class GameConfig : ScriptableObject
{
    [Tooltip("��Ʒ")]
    public GameObject Sun;

    [Header("ֲ��")]
    [Tooltip("���տ�")]
    public GameObject SunFlower;


    [Tooltip("�㶹����")]
    public GameObject PeaShooter;
}
