using UnityEngine;
using System.Collections;

public class TESTRayCast : MonoBehaviour {
	public bool wordInView = false;
	public Transform startPoint, endPoint;
	RaycastHit2D wordHit;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Laser();
	}
	void Laser () {
		Debug.DrawLine(startPoint.position, endPoint.position, Color.red);
		if (Physics2D.Linecast(startPoint.position, endPoint.position, 1 << LayerMask.NameToLayer("Player"))) {
			wordHit = Physics2D.Linecast(startPoint.position, endPoint.position, 1 << LayerMask.NameToLayer("Word"));
			wordInView = true; 
		} else {
			wordInView = false;
		}
		
		//if (Input.GetKeyDown(KeyCode.Space)) {
		//	Destroy (wordHit.collider.gameObject);
		//}
	}
}
