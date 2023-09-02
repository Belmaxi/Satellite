using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Story : MonoBehaviour
{
    [SerializeField] private List<Goods> goods;
    [SerializeField] private TMP_Text biNengObj;
    [SerializeField] private TMP_Text massObj;
    [SerializeField] private TMP_Text costObj;
    [SerializeField] private GameObject OK;

    public void OnGetClicked()
    {

        int biNeng = 0;
        int mass = 0;
        int cost = 0;
        for(int i=0;i<goods.Count; i++)
        {
            Goods good = goods[i];
            biNeng += good.BiNeng;
            mass += good.Mass;
            cost += good.Cost;
        }
        biNengObj.text = "���� " + biNeng.ToString() + " / 100";
        massObj.text = "���� " + mass.ToString() + " / 1000";
        costObj.text = "��Ǯ " + cost.ToString() + " / 2000";
        if (check(biNeng,mass,cost))
        {
            OK.SetActive(true);
        }
        else
        {
            OK.SetActive(false);
        }
    }

    public void OnCloseClicked()
    {
        PlayerManager.instance.Resume();
        Destroy(gameObject);
    }

    public void OnOKClicked()
    {
        LittleGameManager.instance.Achieve(AchieveState.story);
        PlayerManager.instance.Resume();
        Destroy(gameObject);
    }

    private bool check(int biNeng,int mass,int cost)
    {
        if(biNeng <= 100 && mass<=1000 && cost <= 2000)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
