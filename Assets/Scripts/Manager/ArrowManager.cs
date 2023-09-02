using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManager : MonoBehaviour
{
    public static ArrowManager instance;
    [SerializeField] private List<GameObject> arrows = new List<GameObject>();

    private void Awake()
    {
        instance = this;
    }

    public GameObject GetArrow(int index)
    {
        return arrows[index];
    }
}
