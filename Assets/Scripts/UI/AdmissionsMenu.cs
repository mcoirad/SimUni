using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class AdmissionsMenu : UIPanel {

    public Text admitClass;

    public override void Start()
    {
        base.Start();
        UpdateAdmitClass();

    }

    private void UpdateAdmitClass()
    {
        AdmitStudents();
        int numAdmit = ModelController.modelController.applicants.Count(cc => cc.status);
        int numTotal = ModelController.modelController.applicants.Count();
        admitClass.text = "You are currently admitting " + numAdmit + " out of " + numTotal + " applicants";
    }

    public void CloseWindow ()
    {
        CameraController.myCam.isCameraMoving = true;
        Destroy(gameObject);
    }

    public void OpenManualAdmit()
    {
        uiController.OpenManualAdmissions();
        CloseWindow();

    }
    


    public void OpenAdmissionsSettings()
    {
        uiController.OpenAdmissionsEditor();
        CloseWindow();
    }

    public void AutoAdmit()
    {
        AdmitStudents();
        CloseWindow();
    }

    private void AdmitStudents()
    {
        foreach(Student student in ModelController.modelController.applicants)
        {
            float appScore = 0;
            
            // SAT 1-5
            float satScore = (student.satMath + student.satVerbal - 600) / 200;
            float gpaScore = (student.gpa - 1) * 5 / 3;
            float intScore = 0;
            foreach (Interest interest in student.interests)
            {
                intScore = intScore + interest.exp;
            }
            appScore = satScore + gpaScore + intScore;

            if (appScore >= ModelController.modelController.genSelect)
            {
                student.status = true;
            } else
            {
                student.status = false;
            }
        }
    }


}
