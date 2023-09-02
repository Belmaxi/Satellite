using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Goods : MonoBehaviour
{
    [SerializeField] private int biNeng = 0;
    [SerializeField] private int mass = 0;
    [SerializeField] private int cost = 0;
    private TMP_InputField inputField = null;


    private int number = 0;

    public int BiNeng { get => biNeng;}
    public int Mass { get => mass;}
    public int Cost { get => cost;}
    public int Number { get => number;}

    private void Start()
    {
        inputField = GetComponentInChildren<TMP_InputField>();
    }
    public void OnValueChanged()
    {
        int tmp = 0;
        if(int.TryParse(inputField.text,out tmp))
        {
            number = tmp;
        }
        else number = 0;
    }
}
