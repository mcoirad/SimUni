using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapController : MonoBehaviour {

	public static MapController mapController;
	
	// Define Map Size
	public int mapColumns = 20; 
	public int mapRows = 20;
	
	// List of tiles
	public List <List<Tile>> map = new List<List<Tile>>();
	
	// Terrain Prefabs
	private Transform boardHolder;
	public Tile tile;
	public GameObject background;
	
	// Building examples
	public Building building;
	
	void Awake () {
		mapController = this;
	}
	
	// Use this for initialization
	void Start () {
		
		InitialiseList();
		
	}
	
	// Update is called once per frame
	void Update () {
        /**
		if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
            
			Vector3 mousePos = Input.mousePosition;
			Camera camera = CameraController.myCam.GetComponent<Camera>();
			Vector3 worldPos = camera.ScreenToWorldPoint(mousePos);
			Building buig = (Instantiate (building, new Vector3(worldPos.x, worldPos.y, 0f), Quaternion.identity));
			//Debug.Log(camera.ScreenToWorldPoint(mousePos));
			}
			
		**/
	}
	
	void InitialiseList () {
		boardHolder = new GameObject ("Board").transform;
		Instantiate (background, new Vector3 (0 , 0 , 0f), Quaternion.identity);
		for (int x = 0; x < mapColumns; x++) {
		List <Tile> row = new List<Tile>();
			for (int y = 0; y < mapRows; y++) {
				Tile instance = ((Tile)Instantiate (tile, new Vector3 (x , y , 0f), Quaternion.identity)).GetComponent<Tile>();
				// Give it a goodass grid position, and add to row
				row.Add (instance);
				instance.gridPosition = new Vector2(x, y);
				//Debug.Log (x);
				//Debug.Log (y);
				instance.transform.SetParent (boardHolder);
				
			}
			map.Add(row);
		}
		
	}
}
