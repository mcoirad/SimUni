using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Datab;
using System;
using System.Linq;

public class GameUtil : MonoBehaviour {

    public static GameUtil gameUtil;

    /** 
     * VALUES (moral, ethics etc)
     */

    public static Dictionary<string, string> latinTranslation =
        new Dictionary<string, string>()
        {
                { "Citizenship","Civitas" },
                {"Commerce","Commercio" },
                {"Knowledge", "Scientia" },
                {"Religion", "Religio" },
                {"Discipline", "Disciplinam" },
                {"Virtue", "Virtus" },
                {"Liberty", "Libertas" },
                {"Wisdom", "Sapientia" },
                {"Strength", "Vires" },
                {"Justice", "Justita" },
                {"Christ", "Christo" },
                {"Humanity", "Humanitas" },
                {"Truth", "Veritas" },
            {"Action", "Actio" }
        };

    /** 
    * VALUES 
    * correspond to institutional goals, but have an effect on attracting certain faculty/students
    * all fall somewhere on a 2D spectrum of Tradition/Revolution and Theory/Practice (0-100)
    */

    public class ValueStat
    {
        public int politics { get; set; }
        public int praxis { get; set; }
    }

    public static Dictionary<string, ValueStat> valueStats = new Dictionary<string, ValueStat>()
                    {
                        { "Citizenship", new ValueStat(){ politics = 45, praxis = 75 }},
                        { "Religion", new ValueStat(){ politics = 15, praxis = 50 }},
                        { "Knowledge", new ValueStat(){ politics = 40, praxis = 25 }},
                        { "Discipline", new ValueStat(){ politics = 5, praxis = 80 }},
                        { "Virtue", new ValueStat(){ politics = 15, praxis = 85 }},
                        { "Wisdom", new ValueStat(){ politics = 30, praxis = 60 }},
                        { "Strength", new ValueStat(){ politics = 20, praxis = 70 }},
                        { "Justice", new ValueStat(){ politics = 90, praxis = 90 }},
                        { "Christ", new ValueStat(){ politics = 10, praxis = 15 }},
                        { "Commerce", new ValueStat(){ politics = 25, praxis = 75 }},
                        { "Humanity", new ValueStat(){ politics = 60, praxis = 50 }},
                        { "Truth", new ValueStat(){ politics = 50, praxis = 10 }},
                        { "Liberty", new ValueStat(){ politics = 65, praxis = 60 }},
                        { "Action", new ValueStat(){ politics = 80, praxis = 95 }}
                    };

    /**
     * ACTIVITIES
     * These the things that people can spend time on each day
     */
     
     public class Activity
    {
        public string name { get; set; }
        public string desc { get; set; }
    }

    public static List<Activity> activities = new List<Activity>()
    {
        new Activity() { name = "Study", desc = "Time spent working towards academic goals." },
        new Activity() { name = "Work", desc = "Time spent in some form of employment." },
        new Activity() { name = "Athletics", desc = "Time spent engaging in some form of excersize." },
        new Activity() { name = "Sleep", desc = "Everyone needs some everyday!" }

    };

    /**
* INTERESTS
* Abilities that people can grow. not always academic.
*/



    public static List<Interest> interests = new List<Interest>()
    {
        new Interest() { name = "Biology", type = "Science", exp = 0 },
        new Interest() { name = "Chemisty", type = "Science",exp = 0},
        new Interest() { name = "Physics", type = "Science",exp = 0},
        new Interest() { name = "Painting", type = "Art", exp = 0},
        new Interest() { name = "Drama", type = "Art", exp = 0},
        new Interest() { name = "Film", type = "Art", exp = 0},
        new Interest() { name = "Piano", type = "Music", exp = 0},
        new Interest() { name = "Violin", type = "Music", exp = 0},
        new Interest() { name = "Guitar", type = "Music", exp = 0},
        new Interest() { name = "Soccer", type = "Athletics", exp = 0},
        new Interest() { name = "Tennis", type = "Athletics", exp = 0},
        new Interest() { name = "Basketball", type = "Athletics", exp = 0},
        new Interest() { name = "Science Fiction", type = "Literature", exp = 0},
        new Interest() { name = "Poetry", type = "Literature", exp = 0},
        new Interest() { name = "Spanish Literature", type = "Literature", exp = 0},
        new Interest() { name = "Gender Equality", type = "Activism", exp = 0},
        new Interest() { name = "Economic Issues", type = "Activism", exp = 0},
        new Interest() { name = "Racial Equality", type = "Activism", exp = 0},
    };



    // Define days of the week
    public static Dictionary<int, string> days = new Dictionary<int, string>()
				{
					{0, "Sunday"},
					{1, "Monday"},
					{2, "Tuesday"},
					{3, "Wednesday"},
					{4, "Thursday"},
					{5, "Friday"},
					{6, "Saturday"}
		};
		
	// Define majors
	// FLAGS:
	// 0 - Basic
	// 1 - Expansion
	// 2 - Time Triggered
	// 99 - Undecided
	public static string[] marks = new string[]  { "flag", "major"};
	
	public static DataFrame majors = new DataFrame (){
				names = new List<string> () {
					"flag", "major"
				},
				data = new List<List<object>> (){
					new List<object> {0, "Humanities"},
					new List<object> {0, "Social Sciences"},
					new List<object> {0, "Natural Sciences"},
					new List<object> {1, "Biochemistry"},
					new List<object> {2, "Computer Science"},
					new List<object> {99, "Undecided"}
				} 
		};
	
	// COURSES
	
	public static DataFrame courses = new DataFrame () {
		names = new List<string> () {
			"major", "name", "type"
		},
		data = new List<List<object>> (){
			new List<object> {"Humanities", "Writing", 0} 
		}
	};
	
	
	
	// METHODS
	
	// Method for determining weekday from X days
	public static int getDay(int day) {
		int weekDay = day % 7;
		return weekDay;
	}

    public static int GetYear(int day)
    {
        int year = day / 365 + 1970;
        return year;
    }

    public static double BellCurveGen(float mean, float stdDev)
    {
        // Bell curve
        System.Random rand = new System.Random(UnityEngine.Random.Range(0, 1000)); //reuse this if you are generating many
        double u1 = 1.0 - rand.NextDouble(); //uniform(0,1] random doubles
        double u2 = 1.0 - rand.NextDouble();
        double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                     Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
        double randNormal =
                     mean + stdDev * randStdNormal; //random normal(mean,stdDev^2)
        if (randNormal <= 0) { randNormal = 0; }
        else if (randNormal >= 100) { randNormal = 100; }// no negatives! or over 100s
        return randNormal;
    }

    /*
     * Random Name Generation
     */
     public static string NameGen(Person person)
    {
        List<String> male_prefix = new List<String>()
        {
            "Ja", "Mi", "Ro", "Jo", "Da", "Willi", "Ri", "Tho", "Ma", "Cha", "Ste", "Ga", "Jo"
        };

        List<String> male_suffix = new List<String>()
        {
            "mes", "chael", "bert", "hn", "vid" , "am", "chard", "mas", "rk", "rles", "ven", "ry", "seph"
        };

        List<String> female_prefix = new List<String>()
        {
            "Ma",  "Li", "Patri", "Su", "Debo", "Barba"
        };

        List<String> female_suffix = new List<String>()
        {
            "ry", "nda", "cia", "san", "rah", "ra"
        };

        List<String> surnames = new List<String>()
        {
            "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor"
        };

       


        string studentName = "";
        if (person.sex == "male")
        {
            studentName = male_prefix[UnityEngine.Random.Range(0, male_prefix.Count)] + male_suffix[UnityEngine.Random.Range(0, male_suffix.Count)];
        } else
        {
            studentName = female_prefix[UnityEngine.Random.Range(0, female_prefix.Count)] + female_suffix[UnityEngine.Random.Range(0, female_suffix.Count)];

        }
        studentName = studentName + " " + surnames[UnityEngine.Random.Range(0, surnames.Count)];

        return studentName;
    }

    /*
     * College Admissions By Race
     * https://nces.ed.gov/programs/digest/d15/tables/dt15_306.10.asp?current=yes
     */
    public static List<int> admissionsYears = new List<int>() { 1970, 1980, 1990, 2000, 2010 };
    public static List<double> admissionsWhite = new List<double>() { 7740.5, 8480.7, 9272.6, 8983.5, 10895.9 };
    public static List<double> admissionsBlack = new List<double>() { 943.4, 1018.8, 1147.2, 1548.9, 2677.1 };
    public static List<double> admissionsHispanic = new List<double>() { 352.9, 433.1, 724.6, 1351.0, 2551.0 };
    public static List<double> admissionsAsianPacific = new List<double>() { 169.3, 248.7, 500.5, 845.5, 1087.3 };
    public static List<double> admissionsNative = new List<double>() { 69.7, 77.9, 95.5, 138.5, 179.1 };

    /*
     * Choose result from a list of weights
     */

    public static string GetRandomCategory(List<double> listCat, List<string> listCatName)
    {
        double randSum = listCat.Sum();
        //System.Random random = new System.Random();
        double randNum = UnityEngine.Random.Range(0, (float)randSum);
        // Debug.Log("the randnum = " + randNum);
        double stepSum = 0;
        int catIndex = 0;
        foreach (double listNum in listCat)
        {
            if (randNum <= (stepSum + listNum))
            {
                randNum = listNum;
                break;
            }
            catIndex++;
            stepSum = stepSum + listNum;

        }
        return listCatName[catIndex];
    }


}
