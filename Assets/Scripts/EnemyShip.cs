using UnityEngine;
using System.Collections;

public class EnemyShip : MonoBehaviour {
	
	public Transform start;
	public Transform end;

	public float speed = 1f;

	private float startTime;
	private float journeyLength;

	private void Start() {
		start = transform;
		end = GameObject.Find("Player").transform;
		startTime = Time.time;
		journeyLength = Vector3.Distance(start.position, end.position);
	}

	private void Update() {
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		transform.position = Vector3.Lerp(start.position, end.position, fracJourney);
	}

}
