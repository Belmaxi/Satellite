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
        str.Add("�о�Ա��ã����Ǵ˴������������ܸ������ҽ�������������ǵ����������ڣ�������������������һЩ���⣬����ȥ���쳧�����ɣ�");
        Insert();
    }

    public void ShowDialog(int index)
    {
        dia.SetDialog(list[index]);
    }

}
