using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	public AudioClip laser;
	public AudioClip error;

	const string LETTERS = "abcdefghijklmnopqrstuvwxyz";
	
	[SerializeField] private WordManager manager;

	private void Update () {
		foreach (char c in Input.inputString) {
			if (LETTERS.Contains(c.ToString())) {
				bool hit;
				GameObject target = manager.DestroyLetter(c, out hit);
				if (hit) {
					AudioSource.PlayClipAtPoint (laser, Vector3.zero);
					PlayerData.Instance.Score++;
				} else {
					AudioSource.PlayClipAtPoint (error, Vector3.zero);
				}
			}
		}
	}
}