using UnityEngine;
using System.Collections;

public class BulletDetonator : MonoBehaviour {
	float lifespan = 3.0f;
	public GameObject fireEffect;
	WinCondition winScript;
	// Use this for initialization
	void Start () 
	{
		GameObject obj = GameObject.Find("WinCondition");	
		winScript = (WinCondition)obj.GetComponent(typeof(WinCondition));
	}
	
	// Update is called once per frame
	void Update () 
	{
		lifespan -= Time.deltaTime;
		
		if(lifespan <= 0)
		{
			Destroy(gameObject);
		}
	}
	
	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "Enemy")
		{
			Explode();
			col.gameObject.tag = "Dead";
			winScript.decrementEnemies();
			Instantiate(fireEffect, col.transform.position,col.transform.rotation);
			Destroy(col.gameObject);
		}
	}
	
	void Explode()
	{
		Destroy(gameObject);
	}	
}
