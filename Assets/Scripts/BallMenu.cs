using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().AddForce (new Vector2(Random.Range(-1,3),Random.Range(-3,4)),ForceMode2D.Impulse);
	}
}
