using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Course {

	public List<Student> students = new List<Student>();
	public Professor professor;
	public string major;
	
	public string Major {get; set;}
	
	public Course (Professor profInput, string majInput) {
		professor = profInput;
		major = majInput;
	}
	

}
