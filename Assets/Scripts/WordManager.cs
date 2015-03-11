using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;

public class WordManager : MonoBehaviour {

	public GameObject letterPrefab;
	public GameObject wordPrefab;

	private string[] words = {
        "fucking",
  		"ugly",
		"wahid",
		"loves",
		"richard",
		"win"
	};
	
	List<GameObject> currentWords = new List<GameObject>();

	private float nextSpawn = 0;
	private float width;

	private float y;
	private float minX;
	private float maxX;

	private void Awake () {
		width = letterPrefab.renderer.bounds.size.x;
		Vector3 camPos = Camera.main.transform.position;
		float camSize = Camera.main.orthographicSize;
		y = camPos.y + camSize;
		minX = camPos.x - camSize;
		maxX = camPos.x + camSize + 1;
	}
	
	private void Update () {
		if (Time.time > nextSpawn) {
			CreateRandomWord();
			nextSpawn = Time.time + Random.Range(1,3);
		}
	}

	private void CreateRandomWord () {
		Vector2 position;
		position.y = y;
		position.x = Random.Range(minX, maxX);
		string word = words[Random.Range(0, words.Length)];
		GameObject container = (GameObject)Instantiate(wordPrefab, Vector3.zero, Quaternion.identity);
		foreach(char c in word){
			GameObject letter = LoadLetter(c);
			letter.transform.parent = container.transform;
			letter.transform.localPosition = position;
			position.x += width;
		}
		currentWords.Add(container);
	}
	
	private GameObject LoadLetter (char letter) {
		GameObject instance = (GameObject)Instantiate(letterPrefab, Vector2.zero, Quaternion.identity);
		string name = "Letters/letter" + letter.ToString().ToUpper();
		Sprite sprite = Resources.Load<Sprite>(name);
		instance.GetComponent<SpriteRenderer>().sprite = sprite;
		return instance;
	}

}