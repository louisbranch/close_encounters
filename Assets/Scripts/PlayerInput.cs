using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	public AudioClip laserSound;
	public AudioClip errorSound;

	private Vector3 lastPos;
	
	const string LETTERS = "abcdefghijklmnopqrstuvwxyz";

	[SerializeField] private GameObject projectile;
	[SerializeField] private WordManager manager;

	private void Update () {
		foreach (char c in Input.inputString) {
			if (LETTERS.Contains(c.ToString())) {
				bool hit;
				GameObject target = manager.DestroyLetter(c, out hit);
				if (hit) {
					if (target != null) {
						lastPos = target.transform.position;
					}
					GameObject laser = (GameObject) Instantiate(projectile, transform.position, Quaternion.identity);
					laser.transform.LookAt(transform.position + Vector3.forward, lastPos);
					laser.GetComponent<Projectile>().target = lastPos;
					AudioSource.PlayClipAtPoint (laserSound, Vector3.zero);
					PlayerData.Instance.Score++;
				} else {
					AudioSource.PlayClipAtPoint (errorSound, Vector3.zero);
				}
			}
		}
	}
}