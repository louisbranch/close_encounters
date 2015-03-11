using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	private void Update () {
		foreach (char c in Input.inputString) {
			Debug.Log (c);
		}
	}

}