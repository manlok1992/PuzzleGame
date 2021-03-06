﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreatePuzzle : MonoBehaviour {
	static public readonly int num = 6;
	static public GameObject[] objBlock;
	static public Vector3[,] objPos;
	public int[,] randIndex;
	public GameObject[] prefab;
	AllBall allBallObj;
	enum Direction{UP, DOWN, RIGHT, LEFT, NONE};
	Direction dir;
	bool isMove = false;
	Vector2 fPos;
	TouchEvent tempObj2;
	int arrNum;
	public List<GameObject>delList;

	// Use this for initialization
	void Start () {
		delList = new List<GameObject>();
		randIndex = new int[num,num];
		for(int i = 0; i < num; i++) {
			for(int j = 0; j < num; j++) {
				randIndex[i,j] = UnityEngine.Random.Range(0,prefab.Length-1);
			}
		}
		objBlock = new GameObject[num*num];
		objPos = new Vector3[num,num];
		int n = 0;
		for(int i = 0; i < num; i++) {
			for(int j = 0; j < num; j++) {
				var obj = GameObject.Instantiate(prefab[randIndex[i,j]], new Vector3(+(2*i), +(2*j), 0), Quaternion.identity);
//				GameObject.Instantiate(prefab[prefab.Length-1], new Vector3(+(2*i), +(2*j), 0), Quaternion.identity);
				objBlock[n] = (GameObject)obj;

				GameObject tempObj = (GameObject)(obj);

				objPos[i,j] = objBlock[n].transform.position;
				TouchEvent temp = (TouchEvent)objBlock[n].GetComponent("TouchEvent");
				temp.row = j;
				temp.column = i;
				n++;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(SetRect.isTouchDown) {
			if(Input.GetAxis("Mouse X") < -0.3){
				//Code for action on mouse moving left
				dir = Direction.LEFT;
				print("Mouse moved left");
			}
			if(Input.GetAxis("Mouse X") > 0.3){
				//Code for action on mouse moving right
				dir = Direction.RIGHT;
				print("Mouse moved right");
			}
			if(Input.GetAxis("Mouse Y") < -0.3){
				//Code for action on mouse moving down
				dir = Direction.DOWN;
				print("Mouse moved down");
			}
			if(Input.GetAxis("Mouse Y") > 0.3){
				//Code for action on mouse moving up
				dir = Direction.UP;
				print("Mouse moved up");
			}
			if(Input.GetAxis("Mouse Y") > -0.3 && Input.GetAxis("Mouse Y") < 0.3 
			   && Input.GetAxis("Mouse X") > -0.3 && Input.GetAxis("Mouse X") < 0.3) {
				dir = Direction.NONE;
			}
			print(objBlock.Length);
			for(int i = 0; i < objBlock.Length; i++) {
				SetRect tempRect = (SetRect)objBlock[i].GetComponent("SetRect");
				if(tempRect.isTouch) {
					if(dir == Direction.LEFT) {
						tempRect.isTouch = false;
						tempObj2 = (TouchEvent)objBlock[i].GetComponent("TouchEvent");
						if(tempObj2.column != 0) {
							tempObj2.moveL();
							arrNum = i;
							isMove = true;
							break;
						}
					}
					if(dir == Direction.RIGHT) {
						tempRect.isTouch = false;
						tempObj2 = (TouchEvent)objBlock[i].GetComponent("TouchEvent");
						if(tempObj2.column != num-1) {
							tempObj2.moveR();
							arrNum = i;
							isMove = true;						
							break;
						}
					}
					if(dir == Direction.UP) {
						tempRect.isTouch = false;
						tempObj2 = (TouchEvent)objBlock[i].GetComponent("TouchEvent");
						if(tempObj2.row != num-1) {
							tempObj2.moveU();
							arrNum = i;
							isMove = true;						
							break;
						}
					}
					if(dir == Direction.DOWN) {
						tempRect.isTouch = false;
						tempObj2 = (TouchEvent)objBlock[i].GetComponent("TouchEvent");
						if(tempObj2.row != 0) {
							tempObj2.moveD();
							arrNum = i;
							isMove = true;						
							break;
						}
					}
					

				}
			}
			if(isMove) {
				for(int j = 0; j < objBlock.Length; j++) {
					if(arrNum != j) {
						TouchEvent tempEvent = (TouchEvent)objBlock[j].GetComponent("TouchEvent");
						if(objBlock[j].transform.position == tempObj2.transform.position) {
							if(dir == Direction.LEFT) {
								tempEvent.moveR();
								isMove = false;
								Match();
							}
							if(dir == Direction.RIGHT) {
								tempEvent.moveL();
								isMove = false;
								Match();
							}
							if(dir == Direction.UP) {
								tempEvent.moveD();
								isMove = false;
								Match();
							}
							if(dir == Direction.DOWN) {
								tempEvent.moveU();
								isMove = false;
								Match();
							}
							break;
						}

					}
				}
			}
		}
	}

	void Match() {
		bool des = false;
		int des2;

		for(int n = 0; n < objBlock.Length; n++) {
			TouchEvent eventF = (TouchEvent)objBlock[n].GetComponent("TouchEvent");

			List<GameObject>delList2 = new List<GameObject>();
			des2 = 0;

			for(int k = 0; k < objBlock.Length; k++) {
				TouchEvent eventT = (TouchEvent)objBlock[k].GetComponent("TouchEvent");
				if((eventT.row == eventF.row-1 && eventT.column == eventF.column && eventT.gameObject.tag == eventF.gameObject.tag) || 
				   (eventT.row == eventF.row+1 && eventT.column == eventF.column && eventT.gameObject.tag == eventF.gameObject.tag) || 
				   (eventT.column == eventF.column-1 && eventT.row == eventF.row && eventT.gameObject.tag == eventF.gameObject.tag) || 
				   (eventT.column == eventF.column+1 && eventT.row == eventF.row && eventT.gameObject.tag == eventF.gameObject.tag)) {

//					delList.Add(eventT.gameObject);
//					des = true;

					delList2.Add(eventT.gameObject);
					des2++;
				}
			}

			if(des2 >= 2){
				foreach(GameObject go in delList2) {
					//				Destroy(go);
					delList.Add(go);
				}
				des = true;
			}
			delList2.Clear();
		}



		if(des){

			foreach(GameObject go in delList) {
//				Destroy(go);
//				go.SetActive(false);
				go.GetComponent<SpriteRenderer>().enabled = false;
			}


			//			tempObj2.gameObject.SetActive(false);
			tempObj2.gameObject.GetComponent<SpriteRenderer>().enabled = false;
//			Destroy(tempObj2.gameObject);
		}
		delList.Clear();
	}

	void OnMouseDown() {

	}

	void OnMouseUp() {
		
	}
}
