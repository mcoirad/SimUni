using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MottoSelectScreen : UIPanel {

    public Dropdown motto1;
    public Dropdown motto2;
    public Dropdown motto3;

    public Text mottoText;
    public Text philoText;

    public string motto11;
    public string motto22;
    public string motto33;

    public int politics;
    public int praxis;



    public void UpdateMottoText()
    {
        CheckDuplicates();
        string motto1text = motto1.options[motto1.value].text;
        string motto2text = motto2.options[motto2.value].text;
        string motto3text = motto3.options[motto3.value].text;
        mottoText.text = GameUtil.latinTranslation[motto1text] + ", " + GameUtil.latinTranslation[motto2text] + ", " + GameUtil.latinTranslation[motto3text] + ".";

        
    }

    void CheckDuplicates()
    {
        while (motto1.options[motto1.value].text == motto2.options[motto2.value].text )
        {
            motto2.value = Random.Range(0,motto2.value + 5 % GameUtil.latinTranslation.Count);
        } 
        while (motto3.options[motto3.value].text == motto2.options[motto2.value].text || motto1.options[motto1.value].text == motto3.options[motto3.value].text)
        {
            motto3.value = Random.Range(0, motto3.value + 5 % GameUtil.latinTranslation.Count);
        }
    }

    new public void CloseWindow()
    {
        ModelController.modelController.values.Add(motto1.options[motto1.value].text);
        ModelController.modelController.values.Add(motto2.options[motto2.value].text);
        ModelController.modelController.values.Add(motto3.options[motto3.value].text);
        CameraController.myCam.isCameraMoving = true;
        UIController.uiController.StartCollege();
        Destroy(gameObject);
    }


	// Use this for initialization
	public override void Start () {
        base.Start();
        
        motto2.value = 1;
        motto3.value = 2;
        motto1.value = 3;
        UpdateMottoText();
        uiController = UIController.uiController;


    }

    private void calcPhilosophy()
    {
        politics = (GameUtil.valueStats[motto1.options[motto1.value].text].politics //
            + GameUtil.valueStats[motto2.options[motto2.value].text].politics //
            + GameUtil.valueStats[motto3.options[motto3.value].text].politics) / 3;
        praxis = (GameUtil.valueStats[motto1.options[motto1.value].text].praxis //
            + GameUtil.valueStats[motto2.options[motto2.value].text].praxis //
            + GameUtil.valueStats[motto3.options[motto3.value].text].praxis) / 3;

        string politicsText = "";
        if (politics <= 30) { politicsText = "is very traditional"; }
        else if (politics > 30 && politics <= 40 ) { politicsText = "is somewhat conservative"; }
        else if (politics > 40 && politics <= 50 ) { politicsText = "leans towards the traditional"; }
        else if (politics > 50 && politics <= 60) { politicsText = "is moderately liberal"; }
        else if (politics > 60 && politics <= 70) { politicsText = "is rather forward thinking"; }
        else if (politics > 70 ) { politicsText = "is quite revolutionary"; }

        string praxisText = "";
        if (praxis <= 30) { praxisText = "puts stresses the importance of the books"; }
        else if (praxis > 30 && praxis <= 40) { praxisText = "emphasizes the theoretical"; }
        else if (praxis > 40 && praxis <= 50) { praxisText = "leans toward the theoretical"; }
        else if (praxis > 50 && praxis <= 60) { praxisText = "leans towards the applied"; }
        else if (praxis > 60 && praxis <= 70) { praxisText = "values the importance of practice"; }
        else if (praxis > 70) { praxisText = "is of the belief that doing is learning"; }

        philoText.text = "Your institutional philosophy " + politicsText + ", and your teaching philosophy " + praxisText + ".";
    }

	
	// Update is called once per frame
	void Update () {
        calcPhilosophy();
	}
}
