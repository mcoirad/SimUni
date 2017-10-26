using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelController : MonoBehaviour {
	
	public static ModelController modelController;

    // Time
    public int startingDecade = 70;
    public int decade;
    public int day;
	
	
	// Speed settings
	public bool gameIsPlay;
	public float gameSpeed = 1f;

    // Institution
    public List<string> values = new List<string>();
	
	// People
	public List<Professor> professors = new List<Professor>();
    public List<Student> applicants = new List<Student>();
	public List<Student> students = new List<Student>();
	public List<Person> people = new List<Person>();


    // Admissions
    //determine general quality of applicants
    public float admissionsAvg = 50f;
    public float admissionsDev = 25f;
    //auto admissions selectivity
    public float genSelect = 8;
    public float genGPA = 5;
    public float genSAT = 5;
    public float genExtra = 5;
    public float genDiv = 5;

    // Financials
    public float discFunds;

    // Logistics
    public int totalSpace;
    public int classroomSpace;
    public int adminSpace;
    public int housingSpace;

	// Academics
	public List<string> majors = new List<string>();
	public List<Course> courses = new List<Course>();

	// Use this for initialization
	void Start () {
		modelController = this;
		testGameSetup();
        decade = startingDecade;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void AdvanceTime () {
		UIController.uiController.gamePlayChange();
		if (!gameIsPlay) {
			InvokeRepeating("AdvanceOneDay", 0f, gameSpeed);
			gameIsPlay = true;
		} else {
			CancelInvoke("AdvanceOneDay");
			gameIsPlay = false;
		}
		
	}
	
	private void AdvanceOneDay () {
		day = day + 1;
        UIController.uiController.daysPassed.text = string.Concat("Day: ", day.ToString());
        peopleUpdate();
	}
	
	void testGameSetup () {

		// Assign majors
		List<object> majorObj = GameUtil.majors.GetColumnByColumn("flag", 0, "major");
		foreach (object obj in majorObj) {
			majors.Add((string)obj);
		}
			
		int numProf = 10;
		for (int i = 0; i < numProf; i++) {
			Professor prof = new Professor();
			prof.major = majors[Random.Range( 0, majors.Count )];
			people.Add(prof);
			professors.Add(prof);
		}
		
		int numStudent= 100;
		for (int i = 0; i < numStudent; i++) {
			Student student = new Student();
			people.Add(student);
			applicants.Add(student);
		}
		
		
	}
	
	// Professors created courses
	void generateCourses() {
		foreach(Professor professor in professors) {
			Course course1 = new Course(professor, professor.major);
			Course course2 = new Course(professor, professor.major);
			professor.currentCourses.Add(course1);
			professor.currentCourses.Add(course2);
			courses.Add(course1);
			courses.Add(course2);
		}
		
		
	}
	
	// Students sign up for courses
	void fillCourses() {
		// Need some sort of probabilty model to handle individual decisions
		
		//int result = list.Find(item => item > 20);
	}
	
	// Process daily acitivities for Person objects
	void peopleUpdate() {
	
	}
	
}
