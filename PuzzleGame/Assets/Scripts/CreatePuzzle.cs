using UnityEngine;
using System.Collections;

public class CreatePuzzle : MonoBehaviour {
	public int num = 8;
	public Object[,] obj;
	public int[,] randIndex;
	public GameObject[] prefab;

	// Use this for initialization
	void Start () {
		randIndex = new int[num,num];
		for(int i = 0; i < num; i++) {
			for(int j = 0; j < num; j++) {
				randIndex[i,j] = UnityEngine.Random.Range(0,4);
			}
		}
		obj = new GameObject[num,num];
		for(int i = 0; i < num; i++) {
			for(int j = 0; j < num; j++) {
				obj[i,j] = GameObject.Instantiate(prefab[randIndex[i,j]], new Vector3(-3+(1*i), -3+(1*j), 0), Quaternion.identity);
			}
		}
		foreach(GameObject o in obj) {
			o.AddComponent("TouchEvent");
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
