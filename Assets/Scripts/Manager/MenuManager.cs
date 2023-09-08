using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    static public MenuManager instance;
    public GameObject menu;
    public GameObject map;
    public GameObject startDialog;

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
    public void ShowBackGround()
    {
        startDialog.SetActive(true);
        menu.SetActive(false);
    }

    public void HideBackGround()
    {
        startDialog.SetActive(false);
    }
}
