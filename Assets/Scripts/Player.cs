using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using  Sound;

public class Player : MonoBehaviour {

	public static float distanceTreveled;
	public float accereration;
	private  bool touchingPlatform= false;
	private Rigidbody2D rigidbody;
	public Vector2 jump,boost; 
	private static int boosts;
	private Animator TakeshiObata;
	public float nowPosition,pastPosition;
	public  Manager manager;
	public PlatformManager platformsManager;
	public AudioSource jumpSound,deathSound;
	public GameObject deathMenu;
	public bool alive=true;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D> ();
		TakeshiObata = GetComponent<Animator> ();
		platformsManager = FindObjectOfType<PlatformManager> ();
		boosts = 0;
		jumpSound.volume=SoundVolume.effectsVolume;
		deathSound.volume=SoundVolume.effectsVolume;
	}
	public static void AddBoost(){
		boosts++;
		//GUIManager.setBoosts (boosts);
	}

	public float getScore(){
		return distanceTreveled;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag.Equals ("Platform")) {
			touchingPlatform = true;
			TakeshiObata.SetBool ("landing", false);
		} else if (other.gameObject.tag == "Death") {
			manager.restartGame (true);
			deathSound.Play ();
			manager.back.Pause ();
			alive = true;
		}

	}


	void OnTriggerExit2D(Collider2D other){
		if (other.tag.Equals("Platform")) {
			touchingPlatform = false;
		}
	}
	void OnCollisionEnter2D(Collision2D collision){
		TakeshiObata.SetBool ("landing",false);
		if (collision.collider.gameObject.tag == "Death") {
			Time.timeScale = 0f;
			deathSound.Play ();
			manager.back.Pause ();
			alive = true;
			deathMenu.SetActive (true);
		}
	touchingPlatform = true;
	}	

	void OnCollisionExit2D(Collision2D collision){
		touchingPlatform = false;
		if (collision.collider.gameObject.tag == "Death") {
		}
	}
	
	// Update is called once per frame
	void Update () {
		pastPosition = (float)this.gameObject.transform.position.y;
		transform.Translate(4f * Time.deltaTime, 0f,0f);
		if (Input.GetButtonDown("Jump"))
		if (touchingPlatform ) {
			rigidbody.AddForce (jump,ForceMode2D.Impulse);
			jumpSound.Play ();
		}
		else if (boosts>0) {
			rigidbody.AddForce (boost, ForceMode2D.Impulse);
			boosts--;
		//	GUIManager.setBoosts (boosts);
		}
		TakeshiObata.SetBool ("grounded", touchingPlatform);
		distanceTreveled = transform.localPosition.x;
	}
}
