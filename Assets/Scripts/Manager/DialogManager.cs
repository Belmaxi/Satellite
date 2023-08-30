using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

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

    private void Insert(int pos,string message,UnityAction fun = null)
    {
        while(pos >= list.Count) {
            list.Add(new List<string>());
        }
        list[pos].Add(message);
    }
    private void Start()
    {
        dia = dialog.GetComponent<Dialog>();
        Insert(0, "�о�Ա��ã����Ǵ˴������������ܸ������ҽ�������������ǵ����������ڣ�������������������һЩ���⣬����ȥ���쳧�����ɣ�"); //��ҽ������쳧��
        Insert(1, "�����ˣ����ǿ�ʼ�����������ɣ��뽫�ռ����Ĳ��Ϸ��õ�����̨�ԣ��ո�ʰ�𣩡�");//��ɷ�����ƴװС��ϷEngineAseembleGame��
        Insert(2, "��������ƴװ�Ѿ���ɣ���������¯����������Ƥ��������");//�����Ƥ����С��ϷEngineAseembleGame��
        Insert(3, "��Ƥ�����ɹ������ǻ���Ѱ�Һ��ʿ���Ÿ��Ų��ϣ���ȥ�о��������ɡ�");//��ҽ����о�����
        Insert(4, "���Ķ����˵����ѡ����ʵĿ���Ÿ��Ų��ϣ�����ѡ��Ĳ��Ϸ����ڼ�����ϲ��Կ���Ÿ����ԡ�");//���ѡ������ȷ�Ĳ��Ϻ�
        Insert(5, "������ȼ�ϵ�ѡ�����ǵı���ȼ�ϲ����ˣ���ȥ������ѡ��һЩȼ�ϰɣ�ѡ��ȼ��ʱ�뿼�ǳɱ������������������⡣");//���������̵�ѡ����
        Insert(6, "������ȥ���쳧���е����԰ɣ�");//��ҽ��뵽���쳧�������EngineAseembleGame��EngineAseembleGame���̵�ѡ������������
        Insert(7, "������̨�������е�����");//�����ɵ�����EngineTestGame��
        Insert(8, "����Ѿ�������ϣ���ȥ��������ҽ��л���ķ��䣡");//��ҽ��뷢�����������˵�����
        Insert(9, "�����̨�������л���ķ��䡣");
    }

    public void ShowDialog()
    {
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
