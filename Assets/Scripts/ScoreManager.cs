using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text score, hiScore;
	public int Nscore, NhiScore;
	public Player player;

	private bool scoreIncrease;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player> ();
		if (PlayerPrefs.HasKey ("HighScore"))
			NhiScore = PlayerPrefs.GetInt ("HighScore");
		else {
			PlayerPrefs.SetInt ("HighScore", 0);
			PlayerPrefs.Save ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		Nscore = (int)(player.getScore () + 8.06);
		if (Nscore>NhiScore) {
			PlayerPrefs.SetInt ("HighScore", Nscore);
			PlayerPrefs.Save ();
		}
		score.text = "Score: "+ Nscore;
		hiScore.text = "High Score: "+ NhiScore;
	}
}
