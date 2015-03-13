using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	const string LETTERS = "abcdefghijklmnopqrstuvwxyz";
	
	private WordManager manager;

	private void Awake () {
		manager = GetComponent<WordManager>();
	}

	private void Update () {
		foreach (char c in Input.inputString) {
			if (LETTERS.Contains(c.ToString())) {
				manager.DestroyLetter(c);
			}
		}
	}
}