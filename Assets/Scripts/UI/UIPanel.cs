using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanel : MonoBehaviour {

    public static UIController uiController;

    // Use this for initialization
    public virtual void Start()
    {
        CameraController.myCam.isCameraMoving = false;
        uiController = UIController.uiController;
    }

    public void CloseWindow()
    {
        CameraController.myCam.isCameraMoving = true;
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
