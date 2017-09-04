using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Student : Person {

    // Admissions Vars
    public int satVerbal;
    public int satMath;
    public float gpa;
    //public bool isAdmitted = false;

    public int trstInt = 0;


    public Student()
    {
        effort = UnityEngine.Random.Range(0, 10);
        ability = UnityEngine.Random.Range(0, 10);
        major = "Undecided";
        float admAvg = ModelController.modelController.admissionsAvg;
        float admStd = ModelController.modelController.admissionsDev;
        rand = GameUtil.BellCurveGen(admAvg, admStd);
        float satRand =(float)GameUtil.BellCurveGen(admAvg, admStd);
        satVerbal = Convert.ToInt32((GameUtil.BellCurveGen(satRand, admStd / 4) - 50d) * 6d + 500d);
        satMath = Convert.ToInt32((GameUtil.BellCurveGen(satRand, admStd / 4) - 50d) * 6d + 500d);
        gpa = (float)((GameUtil.BellCurveGen(satRand, admStd / 4) - 50d) * 0.02d + 3d);

        //Determine Race based on stats for decade
        race = GenRace();

        // Generate Interests
        GenInterests(satRand);

    }
    /*
    * Generate Interests
    */
    private void GenInterests(float randNum)
    {
        int numInterest = Math.Abs(Convert.ToInt32(GameUtil.BellCurveGen(1.0f + (randNum / 100 * 2.0f), 0.5f)));
        int interestPoints = Math.Abs(Convert.ToInt32(GameUtil.BellCurveGen(1.0f + (randNum / 100 * 3.0f), 0.5f)));
        trstInt = interestPoints;
        // Assign interests
        for (int i = 0; i < numInterest; i++)
        {
            this.interests.Add(GameUtil.interests[UnityEngine.Random.Range(0, GameUtil.interests.Count)]);
        }

        // Add together duplicate interests
        List<Interest> newInterest = new List<Interest>();
        foreach (Interest interest in this.interests)
        {
            if (!newInterest.Contains(interest))
            {
                interest.exp = 1;
                newInterest.Add(interest);

            } else
            {
                int index = newInterest.FindIndex(listInterest => listInterest.name.Equals(interest.name, StringComparison.Ordinal));
                newInterest[index].exp = 2;
                
            }
        }
        interests = newInterest;

        // Assign interest strengths
        if (numInterest > 0 && interestPoints > 0) {
            for (int i = 1; i == interestPoints; i++)
            {
                int intCount = i % interests.Count();
                interests[intCount].exp++;
            }

        }
        


        //interests.Add(GameUtil.interests[UnityEngine.Random.Range(0, GameUtil.interests.Count)]);
        //interests.Add(GameUtil.interests[UnityEngine.Random.Range(0, GameUtil.interests.Count)]);
    }

    private string GenRace()
    {
        List<string> races = new List<string>()
        {
            "White", "Black", "Hispanic", "Asian/Pacific Islander", "Native American"
        };
        int year = (GameUtil.GetYear(ModelController.modelController.day) - 1970) / 10;
        List<double> raceWeights = new List<double>()
        {
            GameUtil.admissionsWhite[year],GameUtil.admissionsBlack[year], GameUtil.admissionsHispanic[year], GameUtil.admissionsAsianPacific[year], GameUtil.admissionsNative[year]
        };
        return GameUtil.GetRandomCategory(raceWeights, races);
    }

}
