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
    /// չʾ��Ϸ��ʼ֮ǰ�Ĺ�Ļ����
    /// </summary>
    private void ShowBackGround()
    {


    }
}
