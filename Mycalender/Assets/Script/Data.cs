using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//�\��̍\����Data
public class Data
{
    public string Name;
    public int StartY;
    public int StartM;        
    public int StartD;
    public int FinishY;
    public int FinishM;
    public int FinishD;
    public DateTime Start;
    public DateTime Finish;
    public void view()
    {
        Debug.Log("Name:" + Name + ", StartY:" + StartY + ", StartM:" + StartM + ", StartD:" + StartD + ", FinishY:" + FinishY + ", FinishM:" + FinishM + ", FinishD:" + FinishD);
    }
    //������Ă���N,��,����DateTime�^�ɕϊ�
    public void IntToString()
    {
        Start = new DateTime(StartY, StartM, StartD);
        Finish = new DateTime(FinishY, FinishM, FinishD);
    }

}
