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
    private int index = 0;

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
        Insert(); //��ҽ������쳧��
        str.Add("�����ˣ����ǿ�ʼ�����������ɣ��뽫�ռ����Ĳ��Ϸ��õ�����̨�ԣ��ո�ʰ�𣩡�");
        Insert();//��ɷ�����ƴװС��ϷEngineAseembleGame��
        str.Add("��������ƴװ�Ѿ���ɣ���������¯����������Ƥ��������");
        Insert();//�����Ƥ����С��ϷEngineAseembleGame��
        str.Add("��Ƥ�����ɹ������ǻ���Ѱ�Һ��ʿ���Ÿ��Ų��ϣ���ȥ�о��������ɡ�");
        Insert();//��ҽ����о�����
        str.Add("���Ķ����˵����ѡ����ʵĿ���Ÿ��Ų��ϣ�����ѡ��Ĳ��Ϸ����ڼ�����ϲ��Կ���Ÿ����ԡ�");
        Insert();//���ѡ������ȷ�Ĳ��Ϻ�
        str.Add("������ȼ�ϵ�ѡ�����ǵı���ȼ�ϲ����ˣ���ȥ������ѡ��һЩȼ�ϰɣ�ѡ��ȼ��ʱ�뿼�ǳɱ������������������⡣");
        Insert();//���������̵�ѡ����
        str.Add("������ȥ���쳧���е����԰ɣ�");
        Insert();//��ҽ��뵽���쳧�������EngineAseembleGame��EngineAseembleGame���̵�ѡ������������
        str.Add("������̨�������е�����");
        Insert();//�����ɵ�����EngineTestGame��
        str.Add("����Ѿ�������ϣ���ȥ��������ҽ��л���ķ��䣡");
        Insert();//��ҽ��뷢�����������˵�����
        str.Add("�����̨�������л���ķ��䡣");
    }

    public void ShowDialog(int index)
    {
        if(index < 0 || index >= list.Count) { return; }
        dia.SetDialog(list[index]);
        NextDialog();
    }

    public void NextDialog()
    {
        index++;
    }

    public int GetDialogIndex()
    {
        return index;
    }

}
