using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialog : MonoBehaviour
{
    public Text DialogText; //Panel���Ӽ�Text
    [TextArea(1, 3)] public List<string> DialogTextList; //��ŶԻ����� ǰ���������Ϊ����Inspector����������������ʾ������
    public int currentIndex;//�Ի���������
    
    public void CloseDialog() //���Closeִ�У��رնԻ�Panel
    {
        gameObject.SetActive(false);
    }

    public void ContinueDialog()    //���Continue��ťִ�У������¾仰
    {
        currentIndex++;
        if (currentIndex < DialogTextList.Count)
        {
            DialogText.text = DialogTextList[currentIndex];
        }
        else
        {
            CloseDialog();
        }
    }

    public void SetDialog(List<string> strings)
    {
        DialogTextList = strings;
        gameObject.SetActive(true);
    }

    private void OnEnable() //�ڼ���Ի���尴ťʱ������Ŀ����Ϊ��ʹ������0
    {
        currentIndex = 0;
        DialogText.text = DialogTextList[currentIndex];
    }

}
