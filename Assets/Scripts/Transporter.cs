using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum Mode
{
    Absolute,//����λ��
    Relative,//���λ��
    ReltativeToPort,//����ڴ����ŵ�λ��
    Transport,//ĳ����������
}
public class Transporter : MonoBehaviour
{
    /// <summary>
    /// ���͵�Ŀ��ص�
    /// </summary>
    public Vector2 target = new Vector2();
    public GameObject targetObj = null;

    /// <summary>
    /// ���ͷ�ʽ
    /// </summary>
    [SerializeField]
    Mode mode = Mode.Absolute;

    /// <summary>
    /// ���봫���ŵ���ĳ��Ŀ�ĵ�
    /// </summary>
    /// <param name="tar">Ŀ�ĵ�</param>
    /// <param name="obj">�ĸ���Ʒ���д���</param>
    private void Transport(GameObject obj,Vector3 pos)
    {
        switch (mode)
        {
            case Mode.Absolute:
                obj.transform.position = pos;
                break;
            case Mode.Relative:
                obj.transform.position += pos;
                break;
            case Mode.ReltativeToPort:
                obj.transform.position = transform.position + pos;
                break;
            case Mode.Transport:
                obj.transform.position = targetObj.transform.position + pos;
                break;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Transport(collision.gameObject,target);
        }
    }
}
