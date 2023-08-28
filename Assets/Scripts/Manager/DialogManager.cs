using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    static public DialogManager instance;
    public List<List<string>> list  = new List<List<string>>();
    public GameObject dialog;
    private List<string> str = new List<string>();

    private Dialog dia;

    private void Awake()
    {
        instance = this; 
     
    }

    private void Insert()
    {
        list.Add(str);
        str.Clear();
    }
    private void Start()
    {
        dia = dialog.GetComponentInChildren<Dialog>();
        str.Add("研究员你好，我是此次卫星制作的总负责人我将引导你完成卫星的制作。现在，发动机的制作出现了一些问题，请你去制造厂看看吧！");
        Insert();
    }

    public void ShowDialog(int index)
    {
        dia.SetDialog(list[index]);
    }

}
