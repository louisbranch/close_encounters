using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public void StartGame () {
		Application.LoadLevel("Level1");
	}
	
	public void MainMenu () {
		Application.LoadLevel("MainMenu");
	}
	
	public void Credits () {
		Application.LoadLevel("Credits");
	}
	
	public void HowTo () {
		Application.LoadLevel("HowTo");
	}
	
	public void Quit () {
		Application.Quit();
	}
}
