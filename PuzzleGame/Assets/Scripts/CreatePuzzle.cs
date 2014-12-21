using UnityEngine;
using System.Collections;

public class CreatePuzzle : MonoBehaviour {
	static public int num = 3;
	static public GameObject[,] objBlock;
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
		objBlock = new GameObject[num,num];
		for(int i = 0; i < num; i++) {
			for(int j = 0; j < num; j++) {
				var obj = GameObject.Instantiate(prefab[randIndex[i,j]], new Vector3(-3+(1*i), -3+(1*j), 0), Quaternion.identity);
				objBlock[i,j] = (GameObject)obj;
				TouchEvent temp = (TouchEvent)objBlock[i,j].GetComponent("TouchEvent");
				temp.row = i;
				temp.column = j;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
