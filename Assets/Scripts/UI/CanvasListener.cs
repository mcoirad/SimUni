using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CanvasListener : MonoBehaviour {

    public bool isPointerOnUI;

    // Use this for initialization
    void Start () {

       
	}
	
	// Update is called once per frame
	void Update () {
        isPointerOnUI = EventSystem.current.IsPointerOverGameObject();
    }
}
