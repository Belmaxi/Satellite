using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Vector2 target = new Vector2();

    /// <summary>
    /// �����ŵ���ĳ��Ŀ�ĵ�
    /// </summary>
    /// <param name="tar">Ŀ�ĵ�</param>
    /// <param name="obj">�ĸ���Ʒ���д���</param>
    private void EnterTheDoor(GameObject obj,Vector2 pos)
    {
        obj.transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EnterTheDoor(collision.gameObject,target);
        }
    }
}
