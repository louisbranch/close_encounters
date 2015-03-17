using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	
	public Vector3 target;
	
	public float speed = 1f;
	
	private float startTime;
	private float journeyLength;
	
	private void Start() {
		startTime = Time.time;
		journeyLength = Vector3.Distance(transform.position, target);
	}
	
	private void Update() {
		if (transform.position == target) {
			Destroy(gameObject);
		}
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		transform.position = Vector3.Lerp(transform.position, target, fracJourney);
	}

}
