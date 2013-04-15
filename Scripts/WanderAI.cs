using UnityEngine;
using System.Collections;

//this isn't a true wander steering AI. It is just a simple waypoint based AI
//I wanted to make a better wander but had trouble making collision detection work in the level,
//so the agent just bounced everywhere.

public class WanderAI : MonoBehaviour {
	public GameObject[] node = new GameObject[3]; //nodes should have same Y coord as the pathfinding object, so it doesn't fly
	Vector3 target = Vector3.zero;
	Vector3 movementDir = Vector3.zero;
	Quaternion rotDir;
	int numNodes = 0;
	int i = 0;
	float speed = 0.5f;
	// Use this for initialization
	void Start () 
	{
		numNodes = node.Length;
		movementDir = node[0].transform.position - transform.position; //finds the vector we need to move in
		rotDir = Quaternion.LookRotation(node[0].transform.position - transform.position);
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.rotation = rotDir;
		transform.position += movementDir * speed * Time.deltaTime;
		
	}
	
	void OnTriggerEnter(Collider other) //sometimes multiple trigger enters with the same object cause variable i to iterate more than once, makes for more random behavior
	{
		//iterate node objects
		i = (i+1) % numNodes; //a fun bit of code that uses modulus to iterate for 0 to node[].length and back
		movementDir = node[i].transform.position - transform.position;
		rotDir = Quaternion.LookRotation(node[i].transform.position - transform.position); //this code rotates the object to face the node, may need to put in LateUpdate...
	}
	
	
}
