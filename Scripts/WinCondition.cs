using UnityEngine;
using System.Collections;

public class WinCondition : MonoBehaviour {
	public int numEnemies = 8;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(numEnemies <=0)
		{
			Debug.Log("win");	
		}
	}
	
	public void decrementEnemies()
	{
		numEnemies--;
	}
}
