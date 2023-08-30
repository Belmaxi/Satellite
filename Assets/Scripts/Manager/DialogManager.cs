using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    static public DialogManager instance;
    public List<List<string>> list  = new List<List<string>>();
    public GameObject dialog;
    private List<string> str = new List<string>();
    private int index = 0;

    private Dialog dia;

    private void Awake()
    {
        instance = this; 
     
    }

    private void Insert()
    {
        list.Add(str);
        str.Clear();
    }
    private void Start()
    {
        dia = dialog.GetComponentInChildren<Dialog>();
        str.Add("研究员你好，我是此次卫星制作的总负责人我将引导你完成卫星的制作。现在，发动机的制作出现了一些问题，请你去制造厂看看吧！");
        Insert(); //玩家进入制造厂后
        str.Add("你来了，我们开始制作发动机吧，请将收集到的材料放置到制造台旁（空格拾起）。");
        Insert();//完成发动机拼装小游戏EngineAseembleGame后
        str.Add("发动机的拼装已经完成，请与熔炼炉互动进行蒙皮的制作。");
        Insert();//完成蒙皮制作小游戏EngineAseembleGame后
        str.Add("蒙皮制作成功！我们还需寻找合适抗电磁干扰材料，请去研究所看看吧。");
        Insert();//玩家进入研究所后
        str.Add("请阅读相关说明，选择合适的抗电磁干扰材料，将你选择的材料放置于检测器上测试抗电磁干扰性。");
        Insert();//玩家选择了正确的材料后
        str.Add("接下是燃料的选择，我们的备用燃料不足了，请去电脑旁选购一些燃料吧，选购燃料时请考虑成本，质量，动力等问题。");
        Insert();//玩家完成了商店选购后
        str.Add("下面请去制造厂进行点火测试吧！");
        Insert();//玩家进入到制造厂且完成了EngineAseembleGame、EngineAseembleGame、商店选购这三个部分
        str.Add("与制造台互动进行点火测试");
        Insert();//玩家完成点火测试EngineTestGame后
        str.Add("火箭已经制作完毕，请去发射控制室进行火箭的发射！");
        Insert();//玩家进入发射控制且完成了点火测试
        str.Add("与控制台互动进行火箭的发射。");
    }

    public void ShowDialog(int index)
    {
        if(index < 0 || index >= list.Count) { return; }
        dia.SetDialog(list[index]);
        NextDialog();
    }

    public void NextDialog()
    {
        index++;
    }

    public int GetDialogIndex()
    {
        return index;
    }

}
