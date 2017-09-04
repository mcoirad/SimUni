using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManualAdmissions : UIPanel {

    public int applicantIndex = 0;


    public Text studentDescription;
    public Text studentStatus;
    public Text studentName;

    private List<Student> accepts = new List<Student>();
    private List<Student> denies = new List<Student>();

    private List<Student> applicants = new List<Student>();

    public override void Start()
    {
        base.Start();
        applicants = ModelController.modelController.applicants;
        UpdateCurrentStudent();
    }

    public void AcceptStudent ()
    {
        accepts.Add(applicants[applicantIndex]);
        applicants[applicantIndex].status = true;
        applicantIndex++;
        UpdateCurrentStudent();
    }

    public void DenyStudent ()
    {
        denies.Add(applicants[applicantIndex]);
        applicants[applicantIndex].status = false;
        applicantIndex++;
        UpdateCurrentStudent();
    }

    public void UpdateCurrentStudent ()
    {
        Student student = applicants[applicantIndex];
        studentStatus.text = GetStatusText(student);
        studentDescription.text = GetDescText(student);
        studentName.text = student.name;
    }

    private string GetStatusText (Student student)
    {
        string statusText = "Not Accepted";
        if (student.status)
        {
            statusText = "Currently Accepted";
        }
        return statusText;
    }

    private string GetDescText(Student student)
    {
        string descText = "Sex: " + student.sex + "\n"//
            + "Race: " + student.race + "\n" //
            + "GPA: " + student.gpa + "\n" //
            + "SAT: " + (student.satVerbal + student.satMath) + "/1600 \n" //
            + "Interests: ";

        foreach(Interest studentInt in student.interests)
        {
            descText = descText + studentInt.type + " (" + studentInt.name;
            descText = descText + studentInt.exp;
            //for (int i = 0; i <= studentInt.exp; i++) { descText = descText + "*"; }
            descText = descText + ") ";
        }

        return descText;
    }
}
