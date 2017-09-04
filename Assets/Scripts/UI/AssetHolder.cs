using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssetHolder : MonoBehaviour {

    public static AssetHolder assetHolder;


    // Building UI
    public OptionButton optionButton;
    public List<Building> buildingsList = new List<Building>();
    public Image buildingPanel;

    // Use this for initialization
    void Start () {
        assetHolder = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
