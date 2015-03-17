using UnityEngine;
using System.Collections;

public class RandomEnemy : MonoBehaviour {

	public Sprite[] enemies;
	public string enemyResource;
	public int currentEnemy = -1;

	void Start() {
		if (enemyResource != "") {
			enemies = Resources.LoadAll<Sprite>(enemyResource);
			if (currentEnemy == -1) {
				currentEnemy = Random.Range(0, enemies.Length);
			}
			else if (currentEnemy > enemies.Length) {
				currentEnemy = enemies.Length - 1;
			}
			GetComponent<SpriteRenderer>().sprite = enemies[currentEnemy];
		}
	}
}
