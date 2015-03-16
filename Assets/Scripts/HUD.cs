using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour 
{
	public Text score = null;
	public Text highScore = null;

	// Unity Script Singleton:

	private static HUD instance = null;

	void Awake ()
	{
		if (instance == null)
		{
			GameObject.DontDestroyOnLoad(this.gameObject);
			instance = this;
		}
		else
		{
			GameObject.Destroy(this.gameObject);
		}
	}
	
	// Update score and high score text values each frame.
	void Update ()
	{
		this.score.text = "Score: " + PlayerData.Instance.Score.ToString();
		this.highScore.text = "HighScore: " + PlayerData.Instance.HighScore.ToString();
	}

	void OnLevelWasLoaded ()
	{
		if (Application.loadedLevelName == "MainMenu")
		{
			PlayerData.Instance.Score = 0;
			Destroy (this.gameObject);
		}
	}
}
