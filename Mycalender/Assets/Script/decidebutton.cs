using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.IO;

public class decidebutton : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool inedit=false;
    public void OnClickdecideButton()
    {
        Debug.Log(inedit);
        if (inedit)
        {//�\��ҏW��
            EditPlan(Edit.changenumber);
            //�\�胊�X�g���ēǂݍ���
            PlanList.LoadPlan();
            InputPlantitle.DeleteNameStatic();
            inedit = false;
            SceneManager.LoadScene("detail");
        }
        else
        {//�\��o�^��
            RegistPlan();
            InputPlantitle.DeleteNameStatic();
            SceneManager.LoadScene("Calender");
        }
    }
    //�\���json�t�@�C���ɓo�^����
    private void RegistPlan()
    {
        DateTime starttime = setstartday.starttime;
        DateTime finish = setstartday.finish;
        Data schedule = new Data();
        schedule.Name = setstartday.planname;
        schedule.StartY = int.Parse(starttime.ToString("yyyy"));
        schedule.StartM = int.Parse(starttime.ToString("MM"));
        schedule.StartD = int.Parse(starttime.ToString("dd"));
        schedule.FinishY = int.Parse(finish.ToString("yyyy"));
        schedule.FinishM = int.Parse(finish.ToString("MM"));
        schedule.FinishD = int.Parse(finish.ToString("dd"));
        string jsonschedule = JsonUtility.ToJson(schedule);
        string path = Application.dataPath + "/savedata.json"; /* ������JSON�t�@�C���̃p�X */
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(jsonschedule);
        writer.Close();
    }
    //1/16�X�V json�t�@�C��n�s�ڂ̗\�������������
    private void EditPlan(int n)
    {
        DateTime starttime = setstartday.starttime;
        DateTime finish = setstartday.finish;
        Data schedule = new Data();
        schedule.Name = setstartday.planname;
        schedule.StartY = int.Parse(starttime.ToString("yyyy"));
        schedule.StartM = int.Parse(starttime.ToString("MM"));
        schedule.StartD = int.Parse(starttime.ToString("dd"));
        schedule.FinishY = int.Parse(finish.ToString("yyyy"));
        schedule.FinishM = int.Parse(finish.ToString("MM"));
        schedule.FinishD = int.Parse(finish.ToString("dd"));
        string jsonschedule = JsonUtility.ToJson(schedule);
        int count = 0;
        //�t�@�C���̃p�X
        string filePath = Application.dataPath + "/savedata.json";
        //�t�@�C����ǂݍ��݂ŊJ��
        System.IO.StreamReader sr = new System.IO.StreamReader(filePath);
        //�ꎞ�t�@�C�����쐬����
        string tmpPath = System.IO.Path.GetTempFileName();
        //�ꎞ�t�@�C�����������݂ŊJ��
        System.IO.StreamWriter sw = new System.IO.StreamWriter(tmpPath);

        //���e����s���ǂݍ���
        while (sr.Peek() > -1)
        {
            //��s�ǂݍ���
            string line = sr.ReadLine();
            //�w�肵���s�ł���΁A�ҏW�����\����i�[����
            if (count == n)
            {
                line = jsonschedule;
            }
            //�ꎞ�t�@�C���ɏ�������
            sw.WriteLine(line);
            count++;
        }
        //����
        sr.Close();
        sw.Close();

        //�ꎞ�t�@�C���Ɠ���ւ���
        System.IO.File.Copy(tmpPath, filePath, true);
        System.IO.File.Delete(tmpPath);
    }
}