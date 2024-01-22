using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Globalization;

//予定の構造体Data
public class Data
{
    public string Name;
    public string Startstr;
    public string Finishstr;
    public DateTime Start;
    public DateTime Finish;
    public void view()
    {
        Debug.Log("Name:" + Name + ",Start:"+Start+"Finish:"+Finish);
    }
    //文字列をDateTime型に変換,1/21更新
    public void IntToString()
    {
        CultureInfo provider = CultureInfo.InvariantCulture;
        string format= "yyyy/MM/dd/ HH:mm:ss";
        Start = DateTime.ParseExact(Startstr,format,provider);
        Finish = DateTime.ParseExact(Finishstr,format,provider);
    }

}
