using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum Mode
{
    Absolute,//绝对位置
    Relative,//相对位置
    ReltativeToPort,//相对于传送门的位置
    Transport,//某个物体身上
}
public class Transporter : MonoBehaviour
{
    /// <summary>
    /// 传送的目标地点
    /// </summary>
    public Vector2 target = new Vector2();
    public GameObject targetObj = null;

    /// <summary>
    /// 传送方式
    /// </summary>
    [SerializeField]
    Mode mode = Mode.Absolute;

    /// <summary>
    /// 进入传送门到达某个目的地
    /// </summary>
    /// <param name="tar">目的地</param>
    /// <param name="obj">哪个物品进行传送</param>
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
