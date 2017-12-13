using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour {

	public Vector2 offset, rotationVelocity;
	public float recycleOffset,spawnChance;

	public void SpawnIfAvailable(Vector2 position){
		if(gameObject.activeSelf|| spawnChance<=Random.Range(0f,100f)){
			return;
		}
		transform.localPosition = position + offset;
		gameObject.SetActive (true);
	}

	private void GameOver(){
		gameObject.SetActive (false);
	}

	// Use this for initialization
	void Start () {
		//GameEventManager.GameOver += GameOver;
		gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if (transform.localPosition.x +recycleOffset <Player.distanceTreveled) {
			gameObject.SetActive (false);
			return;
		}
		transform.Rotate (rotationVelocity * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		Player.AddBoost ();
		gameObject.SetActive (false);
		//Destroy (gameObject);


	}
}
