using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public Transform cameraPosition;
	public float speed;

	public void Update() {
		if (cameraPosition != null) {
			transform.RotateAround(cameraPosition.position, Vector3.up, speed * Time.deltaTime);
		}
	}
}
