using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public static CameraController myCam;
    public bool isCameraMoving;

	// Margin for scrolling
	int margin = 40;
	
	// Default Camera Position
	float cameraDepth = -20f;

	// Use this for initialization
	void Awake () {
		myCam = this;
		float cameraX = MapController.mapController.mapColumns / 2;
		float cameraY = MapController.mapController.mapRows / 2;
		transform.position = new Vector3(cameraX, cameraY, cameraDepth);
		
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 mouseEdge = MouseScreenEdge(margin);
		moveCamera(mouseEdge);
		
		
	}
	
	
	void moveCamera(Vector2 mouseEdge) {
        if (isCameraMoving)
        {
            float cameraX = mouseEdge.x * 0.001f + transform.position.x;
            float cameraY = mouseEdge.y * 0.001f + transform.position.y;
            transform.position = new Vector3(cameraX, cameraY, cameraDepth);
        }
		
	}
	
	Vector2 MouseScreenEdge( int margin ) {
		//Margin is calculated in px from the edge of the screen
	 
		Vector2 half = new Vector2( Screen.width/2, Screen.height/2 );
	 
		//If mouse is dead center, (x,y) would be (0,0)
		float x = Input.mousePosition.x - half.x;
		float y = Input.mousePosition.y - half.y;   
		
		//If x is not within the edge margin, then x is 0;
		//In another word, not close to the edge
		if( Mathf.Abs(x) > half.x-margin ) {
		   x += (half.x-margin) * (( x < 0 )? 1 : -1);
		}
		else {
		   x = 0f;
		}
		
		if( Mathf.Abs(y) > half.y - margin ) {
		   y += (half.y - margin) * (( y < 0 )? 1 : -1);
		}
		else {
		   y = 0f;
		}
		// Debug.Log(new Vector2( x, y ));
		return new Vector2( x, y );
	 }
	
}
