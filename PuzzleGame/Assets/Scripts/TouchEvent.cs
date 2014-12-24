using UnityEngine;
using System.Collections;

public class TouchEvent : MonoBehaviour {
	// Use this for initialization
	Vector2 beginPos;
	public bool isTouchDown = false;
	public int row, column;
	public bool isMove = false;
	enum Direction{UP, DOWN, RIGHT, LEFT, NONE};
	Direction dir;
	static string moveDir = "";
	static Vector2 fPos;
	void Start () {
		dir = Direction.NONE;
	}

	// Update is called once per frame
	void Update () {	
//		if(isTouchDown) {
//			if(Input.GetAxis("Mouse X") < -0.3){
//				//Code for action on mouse moving left
//				dir = Direction.LEFT;
//				print("Mouse moved left");
//			}
//			if(Input.GetAxis("Mouse X") > 0.3){
//				//Code for action on mouse moving right
//				dir = Direction.RIGHT;
//				print("Mouse moved right");
//			}
//			if(Input.GetAxis("Mouse Y") < -0.3){
//				//Code for action on mouse moving down
//				dir = Direction.DOWN;
//				print("Mouse moved down");
//			}
//			if(Input.GetAxis("Mouse Y") > 0.3){
//				//Code for action on mouse moving up
//				dir = Direction.UP;
//				print("Mouse moved up");
//			}
//			if(Input.GetAxis("Mouse Y") > -0.3 && Input.GetAxis("Mouse Y") < 0.3 
//			   && Input.GetAxis("Mouse X") > -0.3 && Input.GetAxis("Mouse X") < 0.3) {
//				dir = Direction.NONE;
//				print("None");
//			}
//		}
//		if(!isMove && isTouchDown) {
//			move();
//		}
	}

	public void moveL(){
		gameObject.transform.position = new Vector3(transform.position.x-2, transform.position.y, 0);
		column--;
	}
	
	public void moveR(){
		gameObject.transform.position = new Vector3(transform.position.x+2, transform.position.y, 0);
		column++;
	}
	
	public void moveU(){
		gameObject.transform.position = new Vector3(transform.position.x, transform.position.y+2, 0);
		row++;
	}
	
	public void moveD(){
		gameObject.transform.position = new Vector3(transform.position.x, transform.position.y-2, 0);
		row--;
	}

	void move() {
		if(dir == Direction.LEFT) {
			moveDir = "Left";
			if(row != 0) {
//				TouchEvent tempObj = (TouchEvent)CreatePuzzle.objBlock[row-1, column].GetComponent("TouchEvent");
//				Vector3 tempPos = gameObject.transform.position;
//				gameObject.transform.position = CreatePuzzle.objBlock[row-1, column].transform.position;
//				CreatePuzzle.objBlock[row-1, column].transform.position = tempPos;
//				if(CreatePuzzle.objBlock[row-1, column].transform.position == CreatePuzzle.objPos[row-1, column]) {
//					CreatePuzzle.objBlock[row-1, column].transform.position = CreatePuzzle.objPos[row, column];
////					tempObj.row++;
//					Debug.Log ("match");
//				}
//				gameObject.transform.position = CreatePuzzle.objPos[row-1, column];
//				row--;
//				isMove = true;
			}
		}
		else if(dir == Direction.RIGHT) {
			moveDir = "Right";
			if(row != CreatePuzzle.num-1) {
//				TouchEvent tempObj = (TouchEvent)CreatePuzzle.objBlock[row+1, column].GetComponent("TouchEvent");
//				Vector3 tempPos = gameObject.transform.position;
//				gameObject.transform.position = CreatePuzzle.objBlock[row+1, column].transform.position;
				//				CreatePuzzle.objBlock[row+1, column].transform.position = tempPos;
//				if(CreatePuzzle.objBlock[row+1, column].transform.position == CreatePuzzle.objPos[row+1, column]) {
//					CreatePuzzle.objBlock[row+1, column].transform.position = CreatePuzzle.objPos[row, column];
//					tempObj.row--;
//					Debug.Log ("match");
//				}
//				row++;
//				tempObj.row--;
//				isMove = true;
			}
		}
		else if(dir == Direction.UP) {
			if(column != CreatePuzzle.num-1) {
//				TouchEvent tempObj = (TouchEvent)CreatePuzzle.objBlock[row, column+1].GetComponent("TouchEvent");
//				Vector3 tempPos = gameObject.transform.position;
//				gameObject.transform.position = CreatePuzzle.objBlock[row, column+1].transform.position;
//				CreatePuzzle.objBlock[row, column+1].transform.position = tempPos;
//				column++; 
//				tempObj.column--;
//				isMove =true;
			} 
		}
		else if(dir == Direction.DOWN) {
			if(column != 0) {
//				TouchEvent tempObj = (TouchEvent)CreatePuzzle.objBlock[row, column-1].GetComponent("TouchEvent");
//				Vector3 tempPos = gameObject.transform.position;
//				gameObject.transform.position = CreatePuzzle.objBlock[row, column-1].transform.position;
//				CreatePuzzle.objBlock[row, column-1].transform.position = tempPos;
//				column--;
//				tempObj.column++;
//				isMove = true;
			}
		}
		else {
			moveDir = "";
		}	
	}

	void OnMouseDown() {
	}

	void OnMouseUp() {
//		isMove = false;
//		float dirX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - beginPos.x;
//		float dirY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - beginPos.y;
//		isTouchDown = false;
	}
}
