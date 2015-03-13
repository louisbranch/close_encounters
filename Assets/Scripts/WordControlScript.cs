using UnityEngine;
using System.Collections;

public class WordControlScript : MonoBehaviour {
	void OnBecameInvisible() {
		Destroy(gameObject);
	}
}
