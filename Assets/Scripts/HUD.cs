using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour 
{	public GameObject player;
	public Text score = null;
	public Text highScore = null;
	public Text health = null;
	public GameObject explosionPrefab;

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
		if (Input.GetKeyDown(KeyCode.Escape))
		    Application.LoadLevel(0);

		this.score.text = "Score: " + PlayerData.Instance.Score.ToString();
		this.highScore.text = "HighScore: " + PlayerData.Instance.HighScore.ToString();
		this.health.text = "Health: " + PlayerData.Instance.Health.ToString();

		if (PlayerData.Instance.Health == 0)
			DestroyMe();
	}

	void OnLevelWasLoaded ()
	{
		if (Application.loadedLevelName == "MainMenu")
		{
			PlayerData.Instance.Score = 0;
			PlayerData.Instance.Health = 3; 
			Destroy (this.gameObject);
		}
	}
	void DestroyMe () { //Creates explosion based on ships position
		//Destroy (player);
		GameObject explosionObject = Instantiate(this.explosionPrefab) as GameObject;
		explosionObject.transform.position = player.transform.position;
	}
}
