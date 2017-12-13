using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  Sound;
public class Manager : MonoBehaviour {

	private Vector2 playerRespawn;
	public Player player;
	public GameObject PauseMenu;
	public AudioSource pause, back;
	public string mainMenu;

	public void pauseLVL(){
		Time.timeScale = 0f;
		PauseMenu.SetActive (true);
	}

	public void continueLVL(){
		Time.timeScale = 1f;
		PauseMenu.SetActive (false);
		back.Play ();
	}

	public void restartLVL(){
		Time.timeScale = 1f;
		Application.LoadLevel(Application.loadedLevel);
	}

	public void exitLVL(){
		Time.timeScale = 1f;
		Application.LoadLevel (mainMenu);
	}

	public void restartGame(bool live){
		if (!live) {
			Debug.Log ("555");
			playerRespawn = new Vector3 (-8f, -2f, 0f);
			StartCoroutine ("RestartGame");
		} else {
			return;
		}
	}

	public IEnumerator RestartGame(){
		player.gameObject.SetActive (false);
		yield return new WaitForSeconds (0.5f);
		player.transform.position = playerRespawn;
		player.gameObject.SetActive (true);
	}
	// Use this for initialization
	void Start () {
		playerRespawn = new Vector3(-8f,-2f,0f);
		pause.volume = SoundVolume.effectsVolume;
			back.volume=SoundVolume.musicVolume;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Time.timeScale==1f) {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			pause.Play ();
			back.Pause ();
			pauseLVL ();
		}
		if (!player.alive)
			back.Pause ();
	}
}
}
