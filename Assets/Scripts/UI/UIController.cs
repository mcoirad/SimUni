using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public static UIController uiController;
    public Text daysPassed;
    public Button gamePlayButton;
    public Canvas canvas;

    // Start Panels
    public int panelNum = 0;
    public MottoSelectScreen mottoSelectScreen;
    public AdmissionsMenu admissionsMenu;
    public AdmissionsEditor admissionsEditor;
    public ManualAdmissions manualAdmissions;
    
    // Button Logic


    // Selection Backgroud  
    public Image selectBackground;
    public string activeSelect;

    // Building panel
    public bool isActiveBuilding = false;
    public Building buildBuilding;
    private Image buildingPanel;

    // Use this for initialization
    void Start()
    {
        uiController = this;
        StartCollege();

        //setupMenu();
    }

    // Update is called once per frame
    void Update()
    {

       // daysPassed.text = string.Concat("Day: ", ModelController.modelController.day.ToString());


    }

    public void gamePlayChange()
    {
        if (ModelController.modelController.gameIsPlay)
        {
            gamePlayButton.GetComponentInChildren<Text>().text = "Play";
        }
        else
        {
            gamePlayButton.GetComponentInChildren<Text>().text = "Pause";
        }
    }

    //public void build

    public void setupMenu(string menu)
    {

        if (menu == "building" && activeSelect != "building")
        {
            activeSelect = menu;
            setupBuildingMenu(ModelController.modelController.decade);
        }
        else if (menu == "building" && activeSelect == "building")
        {
            // kill buildingmenu
            activeSelect = "";
            foreach (Transform child in selectBackground.transform)
            {
                OptionButton.Destroy(child.gameObject);
            }
        } else if (menu == "financial" && activeSelect != "financial")
        {

        } else if (menu == "financial" && activeSelect == "financial")
        {

        }
    }

    public void StartCollege ()
    {
        switch (panelNum)
        {
            case 0:
                OpenMottoSelection();
                panelNum++;
                break;
            case 1:
                OpenAdmissionsMenu();
                panelNum++;
                break;

        }
    }

    /** 
     * UI Instantiation Methods
     */

    public void OpenWindow(UIPanel uiObject)
    {
        uiObject = Instantiate(uiObject, uiObject.transform.position, uiObject.transform.rotation);
        uiObject.transform.SetParent(canvas.transform, false);
    }

    public void OpenMottoSelection ()
    {
        OpenWindow(mottoSelectScreen);
    }

    public void OpenAdmissionsMenu ()
    {
        OpenWindow(admissionsMenu);
    }

    public void OpenAdmissionsEditor ()
    {
        OpenWindow(admissionsEditor);
    }

    public void OpenManualAdmissions ()
    {
        OpenWindow(manualAdmissions);
    }


    public void ShowPanel (UIPanel uiPanel)
    {
        uiPanel = Instantiate(uiPanel, uiPanel.transform.position, uiPanel.transform.rotation);
        uiPanel.transform.SetParent(canvas.transform, false);
    }

    public void toggleBuildingPanel (Building building)
    {
        if (isActiveBuilding)
        {
            
            
            Debug.Log("is active, turning off");
            CameraController.myCam.isCameraMoving = true;
            Destroy(buildingPanel.gameObject);
            isActiveBuilding = false;
            // Kill building panel
        } else
        {
            //Find Canvas in the Scene
            Canvas canvas = (Canvas)GameObject.FindObjectOfType(typeof(Canvas));

            // Activate building panel
            buildingPanel = Instantiate(AssetHolder.assetHolder.buildingPanel, new Vector3(canvas.transform.position.x, canvas.transform.position.y, canvas.transform.position.z), Quaternion.identity);
            buildingPanel.transform.SetParent(canvas.transform);
            //buildingOption.building = building;
            //RectTransform rectWidth = buildingOption.GetComponent<RectTransform>();
            //rectWidth.localPosition = new Vector3(buildingTransform.position.x - (buildingTransform.rect.width / 2) + (rectWidth.rect.width / 2) + (i * rectWidth.rect.width), buildingTransform.position.y, buildingTransform.position.z);
            buildingPanel.transform.Find("Building Preview").gameObject.GetComponent<Image>().sprite = building.GetComponent<SpriteRenderer>().sprite;
            buildingPanel.transform.Find("Building Name").gameObject.GetComponent<Text>().text = building.name;
            buildingPanel.transform.Find("Cost Text").gameObject.GetComponent<Text>().text = building.cost.ToString("n0");
            buildingPanel.transform.Find("Space Text").gameObject.GetComponent<Text>().text = building.space.ToString("n0");
            buildingPanel.transform.Find("Description").gameObject.GetComponent<Text>().text = building.description;

            CameraController.myCam.isCameraMoving = false;
            isActiveBuilding = true;
        }
    }


    private void setupBuildingMenu(int decade)
    {
        List<Building> buildings = AssetHolder.assetHolder.buildingsList;
        //Building[] buildings = FindObjectsOfType(typeof(Building)) as Building[];

       // Building[] buildings = Resources.LoadAll("Prefabs/UI/Buildings/", typeof(Building)) as Building[];

        int i = 0;

        foreach (Building building in buildings)
        {
            if (building.decade == decade)
            {
                //decadeBuildings.Add(building);
                RectTransform buildingTransform = selectBackground.GetComponent<RectTransform>();
                RectTransform buildingTransform2 = building.GetComponent<RectTransform>();
                OptionButton buildingOption = Instantiate(AssetHolder.assetHolder.optionButton, new Vector3(buildingTransform.position.x - (buildingTransform.rect.width / 2), buildingTransform.position.y, buildingTransform.position.z), Quaternion.identity);
                buildingOption.building = building;
                RectTransform rectWidth = buildingOption.GetComponent<RectTransform>();
                rectWidth.localPosition = new Vector3(buildingTransform.position.x - (buildingTransform.rect.width / 2) + (rectWidth.rect.width / 2) + (i * rectWidth.rect.width), buildingTransform.position.y, buildingTransform.position.z);

                //Find Canvas in the Scene
                Canvas canvas = (Canvas)GameObject.FindObjectOfType(typeof(Canvas));
                buildingOption.transform.SetParent(selectBackground.transform);
                i = i + 1;
            }

           
            /*  RectTransform buildingTransform = selectBackground.GetComponent<RectTransform>();
            RectTransform buildingTransform2 = building.GetComponent<RectTransform>();
            OptionButton buildingOption = Instantiate(building, new Vector3(buildingTransform.position.x - (buildingTransform.rect.width / 2), buildingTransform.position.y, buildingTransform.position.z), Quaternion.identity);
            RectTransform rectWidth = buildingOption.GetComponent<RectTransform>();
            rectWidth.localPosition = new Vector3(buildingTransform.position.x - (buildingTransform.rect.width / 2) + (rectWidth.rect.width / 2), buildingTransform.position.y, buildingTransform.position.z);

            //Find Canvas in the Scene
            Canvas canvas = (Canvas)GameObject.FindObjectOfType(typeof(Canvas));
            buildingOption.transform.SetParent(selectBackground.transform);
            /*  OptionButton building = AssetHolder.assetHolder.test;
              RectTransform buildingTransform = selectBackground.GetComponent<RectTransform>();
              RectTransform buildingTransform2 = building.GetComponent<RectTransform>();
              OptionButton buildingOption = Instantiate(building, new Vector3(buildingTransform.position.x - (buildingTransform.rect.width / 2) , buildingTransform.position.y, buildingTransform.position.z), Quaternion.identity);
              RectTransform rectWidth = buildingOption.GetComponent<RectTransform>(); 
              rectWidth.localPosition = new Vector3(buildingTransform.position.x - (buildingTransform.rect.width / 2) + (rectWidth.rect.width / 2), buildingTransform.position.y, buildingTransform.position.z);

              //Find Canvas in the Scene
              Canvas canvas = (Canvas)GameObject.FindObjectOfType(typeof(Canvas));
              buildingOption.transform.SetParent(selectBackground.transform);
              Debug.Log("cool beans"); */
            // display building menu
        }
    }


}
