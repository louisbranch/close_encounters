using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	const string LETTERS = "abcdefghijklmnopqrstuvwxyz";

	AudioSource source;
	
	[SerializeField] private WordManager manager;

	private void Awake () {
		source = GetComponent<AudioSource>();
	}

	private void Update () {
		foreach (char c in Input.inputString) {
			if (LETTERS.Contains(c.ToString())) {
				GameObject target = manager.DestroyLetter(c);
				if (target != null) {
					source.Play();
					PlayerData.Instance.Score++;
				}
			}
		}
	}
}