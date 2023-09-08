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
            StartCoroutine(DoTransport(collision.gameObject,0.5f));
        }
    }

    IEnumerator DoTransport(GameObject obj,float tm)
    {
        PlayerManager.instance.Stop();
        TransportorManager.instance.blackPanel.SetActive(true);
        float timer = 0f;
        while (timer <= tm)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            TransportorManager.instance.GetPanel().color = Color.Lerp(new Color(0, 0, 0, 0), new Color(0, 0, 0, 1), timer / tm);
            timer += Time.deltaTime;
        }
        yield return new WaitForSeconds(0.3f);
        Transport(obj, target);
        yield return new WaitForSeconds(0.3f);
        timer = 0f;
        while (timer <= tm)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            TransportorManager.instance.GetPanel().color = Color.Lerp(new Color(0, 0, 0, 1), new Color(0, 0, 0, 0), timer / tm);
            timer += Time.deltaTime;
        }
        TransportorManager.instance.blackPanel.SetActive(false);
        PlayerManager.instance.Resume();
    }
}
