using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {

    // Fluff
    public string name;
    public string description;


    // Stats
    public int cost;
    public int space;
    public int decade;

    // Map Space
    public int width;
    public int length;
    public Vector2 gridPosition = Vector2.zero;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
