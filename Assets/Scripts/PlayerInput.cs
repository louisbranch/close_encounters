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
				GameObject target = manager.DestroyLetter(c);
				if (target != null) {
					AudioSource.PlayClipAtPoint (laser, Vector3.zero);
					PlayerData.Instance.Score++;
				}
				if (target == null) {
					AudioSource.PlayClipAtPoint (error, Vector3.zero);
				}
			}
		}
	}
}