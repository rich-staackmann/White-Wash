using UnityEngine;
using System.Collections;

public class WanderAI : MonoBehaviour {
	public GameObject[] node = new GameObject[3]; //nodes should have same Y coord as the pathfinding object, so it doesn't fly
	Vector3 target = Vector3.zero;
	Vector3 movementDir = Vector3.zero;
	int numNodes = 0;
	int i = 0;
	float speed = 0.5f;
	// Use this for initialization
	void Start () 
	{
		numNodes = node.Length;
		movementDir = node[0].transform.position - transform.position; //finds the vector we need to move in
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		transform.position += movementDir * speed * Time.deltaTime;
		
	}
	
	void OnTriggerEnter(Collider other)
	{
		//iterate of node objects
		i = (i+1) % numNodes; //a fun bit of code that uses modulus to iterate for 0 to node[].length and back
		movementDir = node[i].transform.position - transform.position;
	}
	
	
}
