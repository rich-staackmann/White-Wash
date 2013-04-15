using UnityEngine;
using System.Collections;

//This is a simple script to implement raycast and physics based projectiles
//
public class PlayerShoot : MonoBehaviour {
	public GameObject bullet;
	public WinCondition winScript;
	Camera c;
	RaycastHit hit;
	public int numDetonators = 2;
	int gunType = 1; //1 is for gun, 2 is for detonator
	// Use this for initialization
	void Start () 
	{
		c = Camera.main;
		gunType = 1;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Alpha1))
			gunType = 1;
		if(Input.GetKeyDown(KeyCode.Alpha2))
			gunType = 2;
		
		
		if(Input.GetButtonDown("Fire1") && gunType == 1)
		{
			rayShoot();
			audio.Play(); //play the attached gunshot sound
		}
		
		if(Input.GetButtonDown("Fire1") && gunType == 2)
		{	
			if(numDetonators > 0)
			{
				GameObject theBullet =	(GameObject)Instantiate(bullet,c.transform.position + c.transform.forward,c.transform.rotation);
				theBullet.rigidbody.AddForce(c.transform.forward * 35.0f,ForceMode.Impulse);
				numDetonators--; //decrease detonator inventory
			}
		}
	}
	
	void rayShoot() //a raycast based shooting method
	{
		if(Physics.Raycast(c.transform.position,c.transform.forward, out hit, 100))
		{
				if(hit.collider.name ==("Enemy"))
				{
					Destroy(hit.collider.gameObject);
					winScript.decrementEnemies(); //the winScript keeps tack of our victory condition(kill all enemies) so we call it's decrementEnemeis function
				}
		}
	}
	
	void OnGUI()
	{
		GUI.Box(new Rect(10,Screen.height/2,100,30), "Detonators: " + numDetonators.ToString()); //numbers of detonators available
	}
}
