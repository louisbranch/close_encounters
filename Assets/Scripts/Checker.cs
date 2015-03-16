using UnityEngine;
using System.Collections;

public class Checker : MonoBehaviour {

	public AudioClip Ouch;

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Word"){
			AudioSource.PlayClipAtPoint (Ouch, Vector3.zero);
			Destroy(other.gameObject);
			PlayerData.Instance.Health--;
		}
	}
}