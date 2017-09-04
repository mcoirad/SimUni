using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Tile : MonoBehaviour {

    private CanvasListener uiListener;
    public Vector2 gridPosition = Vector2.zero; 
	
	// Moveables
	public bool isEmpty = true;
	
	// Use this for initialization
	void Start () {
		transform.GetComponent<Renderer>().material.color = Color.clear;
        uiListener = GameObject.Find("Canvas").GetComponent<CanvasListener>();
    }
	
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void OnMouseOver() {
        if (isEmpty)
        {
            transform.GetComponent<Renderer>().material.color = Color.blue;
        } else
        {
            transform.GetComponent<Renderer>().material.color = Color.red;
        }
	}
	
	public void OnMouseExit() {
		transform.GetComponent<Renderer>().material.color = Color.clear;
	}

    public void OnMouseDown()
    {
        if (!uiListener.isPointerOnUI && isEmpty && (MapController.mapController.building != null))
        {
            Building buig = (Instantiate(MapController.mapController.building, new Vector3(this.transform.position.x, this.transform.position.y, 0f), Quaternion.identity));
            buig.gridPosition = this.gridPosition;
            // Assign Sortinglayer based on grid position
            buig.GetComponent<Renderer>().sortingOrder = (Convert.ToInt32(this.gridPosition.y) * -1 + MapController.mapController.mapRows) * MapController.mapController.mapColumns + Convert.ToInt32(this.gridPosition.x) * -1;
            isEmpty = false;
            if (buig.width == 2)
            {
                // set adjacent tile to not empty
                List<Tile> row = MapController.mapController.map[Convert.ToInt32(gridPosition.x) + 1];
                Tile adjTile = row[ Convert.ToInt32(gridPosition.y)];
                adjTile.isEmpty = false;
            }
        }
        
    }
	
	
}
