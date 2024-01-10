using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
public class PlanList : MonoBehaviour
{
    public static Data[] DataList=new Data[99];
    public static int datacount = 0;
    public void setData(Data data)
    {
        DataList[datacount] = data;
        datacount++;
    }
    public void LoadPlan()
    {
        string datastr = "";
        StreamReader reader;
        //�ǂݎ��ꏊ���w��
        reader = new StreamReader(Application.dataPath + "/savedata.json");
        while (reader.Peek() != -1)
        {
            datastr = reader.ReadLine();//��s���ǂ�
             setData(JsonConvert.DeserializeObject<Data>(datastr));//�\���\�胊�X�g�ɓo�^
        }
        reader.Close();
    }
    private void Start()
    {
        LoadPlan();
        int count = 0;
        while (DataList[count] != null)
        {
            DataList[count].view();
            count++;
        }
        Debug.Log(datacount);
    }
}
