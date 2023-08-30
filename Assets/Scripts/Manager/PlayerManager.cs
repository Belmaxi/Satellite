using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    static public PlayerManager instance;
    public PlayerController player;

    private void Awake()
    {
        instance = this;
    }

    public void Stop()
    {
        player.Stop();
    }

    public void Resume()
    {
        player.Resume();
    }

    /// <summary>
    /// ��ȡ��ҵ�λ��
    /// </summary>
    /// <returns></returns>
    public Vector3 GetPosition()
    {
        return Vector3.zero;
        return player.gameObject.transform.position;
    }
}
