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
            biNeng += good.BiNeng * good.Number;
            mass += good.Mass * good.Number;
            cost += good.Cost * good.Number;
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
        NPCManager.instance.GetController(3).ShowMark();
        ArrowManager.instance.GetArrow(3).SetActive(false);
        Destroy(gameObject);
    }

    private bool check(int biNeng,int mass,int cost)
    {
        int cnt = 0;
        if(biNeng >= 100)
        {
            cnt++;
            biNengObj.color = Color.green;
        }
        else
        {
            biNengObj.color= Color.red;
        }
        if (mass <= 1000)
        {
            cnt++;
            massObj.color = Color.green;
        }
        else
        {
            massObj.color = Color.red;
        }
        if (cost <= 2000)
        {
            cnt++;
            costObj.color = Color.green;
        }
        else
        {
            costObj.color = Color.red;
        }
        if (cnt==3)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}