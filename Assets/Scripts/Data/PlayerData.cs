﻿using UnityEngine;
using System.Collections;

public class PlayerData 
{
	// C# Class Singleton:

	private static PlayerData instance = null;

	public static PlayerData Instance
	{
		get {
			if (instance == null)
			{
				instance = new PlayerData();
			}
			return instance;
		}
	}


	// PlayerData Constructor:
	private PlayerData ()
	{
		// Initialize high score with the score stored in PlayerPrefs. 
		highScore = PlayerPrefs.GetInt("HighScore");
	}


	// Accessors:

	private int score = 0;

	public int Score
	{
		get {
			return this.score;
		}
		set {
			score = value;
			if (score > highScore)
			{
				this.highScore = score;
				PlayerPrefs.SetInt("HighScore", highScore);
			}
		}
	}

	private int highScore = 0;

	public int HighScore
	{
		get {
			return this.highScore;
		}
	}
	private int health = 10;
	public int Health {
		get {
			return this.health;
		}

		set {
			health = value;
			//if (health <= 0)
				//Application.LoadLevel(0);
		}

	}

}
