using UnityEngine;
using System.Collections;

public class EnemyShip : MonoBehaviour {

	private Vector2 targetPos;

	public float speed = 1f;

	private float startTime;
	private float journeyLength;

	private void Start() {
		targetPos = GameObject.Find("Player").transform.position;
		startTime = Time.time;
		journeyLength = Vector3.Distance(transform.position, targetPos);
	}

	private void Update() {
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		transform.position = Vector3.Lerp(transform.position, targetPos, fracJourney);
	}

}
