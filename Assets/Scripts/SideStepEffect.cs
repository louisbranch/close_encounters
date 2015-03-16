using UnityEngine;
using System.Collections;

public class SideStepEffect : MonoBehaviour {

	private float startX = 0.5f;
	public float duration = 1f;
	
	void Start () {
		startX = transform.position.x;
	}
	
	void Update () {
		float newX = startX + (startX + Mathf.Cos (Time.time / duration * 2));
		transform.position = new Vector2 (newX , transform.position.y);
	}
}
