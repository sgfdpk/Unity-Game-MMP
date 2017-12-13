using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	private Vector3 playerPosition;
	private float distanceToMove;
	public Player player;


	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player> ();
		playerPosition = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		distanceToMove = player.transform.position.x - playerPosition.x;
		transform.position = new Vector3 (transform.position.x+distanceToMove,transform.position.y,transform.position.z);
		playerPosition = player.transform.position;
	}
}
