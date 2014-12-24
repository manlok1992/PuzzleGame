using UnityEngine;
using System.Collections;

public class SetRect : MonoBehaviour {
	public Rect rect;
	public Vector2 fPos;
	static public bool isTouchDown = false;
	public bool isTouch = false;
	// Use this for initialization
	void Start () {
		rect = new Rect(transform.position.x-1,transform.position.y-5, 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
		rect.Set(transform.position.x-1,transform.position.y-5, 1, 1);
	}
	void OnGUI() {
		//		GUI.Box(rect, "1");
		Vector3 vec = Camera.main.WorldToScreenPoint(new Vector3(rect.x,rect.y, 0));
//		Vector3 vec2= Camera.main.WorldToScreenPoint(new Vector3(1,1, 0));
//		GUI.Box(new Rect(vec.x, vec.y,70,70), "1");

	}
	
	void OnMouseDown() {
		isTouchDown = true;
		isTouch = true;
		fPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}
	
	void OnMouseUp() {
//		isTouch = false;
		isTouchDown = false;
	}
}
