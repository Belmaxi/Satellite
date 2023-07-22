using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Vector2 target = new Vector2();

    /// <summary>
    /// 进入门到达某个目的地
    /// </summary>
    /// <param name="tar">目的地</param>
    /// <param name="obj">哪个物品进行传送</param>
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
