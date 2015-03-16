using UnityEngine;
using System.Collections;

public class Checker : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Word"){
		Destroy(other.gameObject);
		PlayerData.Instance.Health--;
		}
	}
		/*public float maxGravDist = 4.0f;
		public float maxGravity = 35.0f;
		
		GameObject[] players;
		
		void Start () {
			player = GameObject.FindGameObjectsWithTag("Player");
		}
		
		void FixedUpdate () {
			foreach(GameObject player in players) {
				float dist = Vector3.Distance(player.transform.position, transform.position);
				if (dist <= maxGravDist) {
					Vector3 v = player.transform.position - transform.position;
					Rigidbody2D.AddForce(v.normalized * (1.0f - dist / maxGravDist) * maxGravity);
				}
			}
		}
}*/
}