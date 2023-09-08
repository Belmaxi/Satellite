using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransportorManager : MonoBehaviour
{
    static public TransportorManager instance;
    public GameObject blackPanel;

    private void Awake()
    {
        instance = this;
    }

    public Image GetPanel()
    {
        Image image = blackPanel.GetComponentInChildren<Image>();
        return image;
    }

}
