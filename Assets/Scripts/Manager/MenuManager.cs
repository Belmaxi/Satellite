using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    static public MenuManager instance;
    public GameObject menu;
    public GameObject map;

    private void Awake()
    {
        instance = this; 
    }

    private void Start()
    {
        
    }

    /// <summary>
    /// 展示游戏开始之前的过幕动画
    /// </summary>
    private void ShowBackGround()
    {


    }
}
