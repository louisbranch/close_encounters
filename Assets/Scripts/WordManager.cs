using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;

public class WordManager : MonoBehaviour {

	public GameObject letterPrefab;
	public GameObject wordPrefab;

	private string[] tempWords = {
        "fucking",
  		"ugly",
		"wahid",
		"loves",
		"richard",
		"win"
	};

	private struct Word {
		public string name;
		public GameObject gameObject;
		public int counter;
	}
	
	List<Word> words = new List<Word>();

	Word target;

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
		string name = tempWords[Random.Range(0, tempWords.Length)];
		GameObject container = (GameObject)Instantiate(wordPrefab, Vector3.zero, Quaternion.identity);
		foreach(char c in name){
			GameObject letter = LoadLetter(c);
			letter.transform.parent = container.transform;
			letter.transform.localPosition = position;
			position.x += width;
		}
		Word word = new Word();
		word.name = name;
		word.counter = 0;
		word.gameObject = container;
		words.Add(word);
	}
	
	private GameObject LoadLetter (char letter) {
		GameObject instance = (GameObject)Instantiate(letterPrefab, Vector2.zero, Quaternion.identity);
		string name = "Letters/letter" + letter.ToString().ToUpper();
		Sprite sprite = Resources.Load<Sprite>(name);
		instance.GetComponent<SpriteRenderer>().sprite = sprite;
		return instance;
	}

	public GameObject DestroyLetter (char letter) {
		if (target.gameObject == null) { // target is null

		} else {

		}

		return target.gameObject;
	}

}