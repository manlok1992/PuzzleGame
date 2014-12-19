﻿using UnityEngine;
using System.Collections;

public class TouchEvent : MonoBehaviour {
	// Use this for initialization
	Vector2 beginPos;
	bool inUp = false;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(inUp) {
			if(Input.GetAxis("Mouse X") < -0.3){
				//Code for action on mouse moving left
				print("Mouse moved left");
			}
			if(Input.GetAxis("Mouse X") > 0.3){
				//Code for action on mouse moving right
				print("Mouse moved right");
			}
			if(Input.GetAxis("Mouse Y") < -0.3){
				//Code for action on mouse moving down
				print("Mouse moved down");
			}
			if(Input.GetAxis("Mouse Y") > 0.3){
				//Code for action on mouse moving up
				print("Mouse moved up");
			}
		}
	}

	void OnMouseDown() {
		beginPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		inUp = true;
	}

	void OnMouseUp() {
		float dirX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - beginPos.x;
		float dirY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - beginPos.y;
		inUp = false;
	}
}
