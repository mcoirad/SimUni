using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Person {

    // Hiring/accept
    public bool status;

    // Personal Vars
    public string name;
    public string sex;
    public string race;

	public int effort;
	public int ability;
    public int politics;
    public int praxis;

    public double rand;

    public List<Interest> interests = new List<Interest>();
	
	// Academic Vars
	public string major;
	public List<Course> currentCourses = new List<Course>();



    public Person () {
        
        sex = (UnityEngine.Random.Range(0, 2) == 0 )? "male" : "female";
        name = GameUtil.NameGen(this);
        effort = UnityEngine.Random.Range(0, 10);
		ability = UnityEngine.Random.Range(0, 10);
		major = "Undecided";
        rand = GameUtil.BellCurveGen(ModelController.modelController.admissionsAvg, ModelController.modelController.admissionsDev);
	}

    private void GenerateInterests ()
    {
        
    } 
}
