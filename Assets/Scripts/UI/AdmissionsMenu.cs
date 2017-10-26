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
        if (!UIController.uiController.didUseManualAdmissions)
        {
            AdmitStudents();
        } else
        {
            UIController.uiController.didUseManualAdmissions = false;
        }
        
        List<Student> applicants = ModelController.modelController.applicants;
        int numAdmit = applicants.Count(cc => cc.status);

        if (numAdmit > 0)
        {
            
            int numTotal = applicants.Count();
            float gpaAvg = applicants.Where(student => student.status == true).Sum(student => student.gpa) / numAdmit;
            int satAvg = (applicants.Where(student => student.status == true).Sum(student => student.satVerbal) + applicants.Where(student => student.status == true).Sum(student => student.satMath)) / numAdmit;
            int whiteNum = applicants.Count(student => student.race == "White" && student.status == true) * 100 / numAdmit;
            int blackNum = applicants.Count(student => (student.status == true && student.race == "Black")) * 100 / numAdmit;
            int natNum = applicants.Count(student => (student.status == true && student.race == "Native American")) * 100 / numAdmit;
            int hispNum = applicants.Count(student => (student.status == true && student.race == "Hispanic")) * 100 / numAdmit;
            int asiaNum = applicants.Count(student => (student.status == true && student.race == "Asian/Pacific Islander")) * 100 / numAdmit;

            admitClass.text = "You are currently admitting " + numAdmit + " out of " + numTotal + " applicants" + "\n" //
                + "The average entering GPA is " + gpaAvg + "\n"
                + "The average entering SAT score is " + satAvg + "\n"
                + "Your entering class is approximately " + whiteNum + "% White, " + blackNum + "% Black, " + natNum + "% Native American, " + hispNum + "% Hispanic, " + asiaNum + "% Asian.";

        } else
        {
            admitClass.text = "You are not currently admitting any students! \n"
                + "You might want to lower your admissions standards.";
        }
        
    }

    new public void CloseWindow ()
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
            float satScore = (student.satMath + student.satVerbal - 600) / 200 * (ModelController.modelController.genSAT / 5);
            float gpaScore = (student.gpa - 1) * 5 / 3 * (ModelController.modelController.genGPA / 5);
            float intScore = 0;
            foreach (Interest interest in student.interests)
            {
                intScore = intScore + interest.exp;
            }
            intScore = intScore + (ModelController.modelController.genExtra / 5);
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
