using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
public class PlanList : MonoBehaviour
{
    public static Data[] DataList=new Data[99];//予定のリスト
    public static int datacount;//予定の個数
   
    public static void LoadPlan()
    {
        string datastr = "";
        StreamReader reader;
        //読み取り場所を指定
        reader = new StreamReader(Application.dataPath + "/savedata.json");
        datacount = 0;
        while (reader.Peek() != -1)
        {
            datastr = reader.ReadLine();//一行ずつ読む
            DataList[datacount]=JsonConvert.DeserializeObject<Data>(datastr);//予定を予定リストに登録
            DataList[datacount].IntToString();
            datacount++;
        }
        reader.Close();
    }

    public static void viewPlan()
    {
        int i;
        Debug.Log("datacount:"+datacount);
        for (i = 0; i < datacount; i++)
            DataList[i].view();
    }


    private void Start()
    {
        //最初にsavedataを読み込みリストを作成する
        LoadPlan();
        viewPlan();
    }
}
