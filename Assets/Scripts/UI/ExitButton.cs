﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour {

	// Use this for initialization
	public void onClick () {
        UIController.uiController.toggleBuildingPanel(null);
	}
	

}
