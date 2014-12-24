using UnityEngine;
using System.Collections;

public class AllBall : MonoBehaviour {
	public GameObject[] goArr;
	int index;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void addBall(GameObject go) {
		index++;
		goArr[index] = go;
	}
}
