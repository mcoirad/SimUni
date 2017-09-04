using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionButton : MonoBehaviour {

    public string type;
    public string id;
    public Building building;

	// Use this for initialization
	void Start () {
        Sprite buildingSprite = building.GetComponent<SpriteRenderer>().sprite;
        this.GetComponent<Image>().sprite = buildingSprite;
        //thisSprite = spriteRenderer;
        //image = this.GetComponent<Image>().image;
       // GetComponent<Image>().sprite = newSprtie;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // set building type
    public void setBuilding (string buildingName )
    {
        building = Instantiate(Resources.Load(buildingName, typeof(Building))) as Building;
        Start();
    }

    // select building to build
    public void onClick()
    {
        UIController.uiController.toggleBuildingPanel(building);
        MapController.mapController.building = building;
    }
}
