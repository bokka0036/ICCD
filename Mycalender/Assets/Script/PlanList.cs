using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
public class PlanList : MonoBehaviour
{
    public static Data[] DataList=new Data[99];//�\��̃��X�g
    public static int datacount;//�\��̌�
   
    public void LoadPlan()
    {
        string datastr = "";
        StreamReader reader;
        //�ǂݎ��ꏊ���w��
        reader = new StreamReader(Application.dataPath + "/savedata.json");
        datacount = 0;
        while (reader.Peek() != -1)
        {
            datastr = reader.ReadLine();//��s���ǂ�
            DataList[datacount]=JsonConvert.DeserializeObject<Data>(datastr);//�\���\�胊�X�g�ɓo�^
            datacount++;
        }
        reader.Close();
    }
    private void Start()
    {
        //�ŏ���savedata��ǂݍ��݃��X�g���쐬����
        LoadPlan();
        int count = 0;
        while (DataList[count] != null)
        {
            DataList[count].view();
            DataList[count].IntToString();
            count++;
        }
        
    }
}
