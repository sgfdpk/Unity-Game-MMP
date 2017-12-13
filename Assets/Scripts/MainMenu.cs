using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using  Sound;

public class MainMenu : MonoBehaviour {

	public AudioSource mainTheme;
	// Use this for initialization
	void Start () {

		//settings = GetComponent<Settings> ();
		MusicVolume.enabled=false;
		EffectsVolume.enabled=false;
		MusicSlider.gameObject.SetActive(false);
		EffectsSlider.gameObject.SetActive(false);
		mainTheme.volume = SoundVolume.musicVolume;
		mainTheme.Play ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public string playLVL;

	public Text MusicVolume;
	public Text EffectsVolume;	
	public Slider MusicSlider;	
	public Slider EffectsSlider;
	//public GameObject settings;
	public Button exit;
	public RectTransform quit;
	private bool settingsON = false;

	public void settingsOn(){
		if (!settingsON) {
			settingsON = true;
			Debug.Log ("www");
			//settings.SetActive (true);
			MusicVolume.enabled=true;
			EffectsVolume.enabled=true;
			MusicSlider.gameObject.SetActive(true);
			EffectsSlider.gameObject.SetActive(true);
			//quit.position.Set(0f,-200f,0f);
			Vector3 pos= quit.transform.position;
			pos.y -= 80f;
			quit.transform.position=pos;
		}
		else {
			Debug.Log ("zzz");
			settingsON = false;
			//settings.SetActive (false);
			MusicVolume.enabled=false;
			EffectsVolume.enabled=false;
			MusicSlider.gameObject.SetActive(false);
			EffectsSlider.gameObject.SetActive(false);
			//exit.transform.position.Set;
			Vector3 pos= quit.transform.position;
			pos.y += 80f;
			quit.transform.position=pos;
		}
	}
	public void settingsVolumeEff(){
		SoundVolume.effectsVolume = EffectsSlider.value;
	}

	public void settingsVolumeMus(){
		SoundVolume.musicVolume = MusicSlider.value;
	}
	public void playGame(){
		Application.LoadLevel (playLVL);
	}

	public void exitGame(){
		Application.Quit ();
	}
}
