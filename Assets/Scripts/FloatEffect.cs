﻿using UnityEngine;
using System.Collections;

public class FloatEffect : MonoBehaviour {

	private float startY = 0.5f;
	public float duration = 1f;
	
	void Start () {
		startY = transform.position.y;
	}
	
	void Update () {
		float newY = startY + (startY + Mathf.Cos (Time.time / duration * 2)) / 4;
		transform.position = new Vector2 (transform.position.x, newY);
	}
}
