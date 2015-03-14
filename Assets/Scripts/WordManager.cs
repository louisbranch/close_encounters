using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;

public class WordManager : MonoBehaviour {

	public string wordsFile;
	[SerializeField] private int minWordLength;
	[SerializeField] private int maxWordLength;

	[SerializeField] private GameObject letterPrefab;
	[SerializeField] private GameObject wordPrefab;

	private int nextIndex = 0;

	private struct Word {
		public string name;
		public GameObject gameObject;
		public int counter;
		public int index;
	}
	
	private Word[] words = new Word[256];

	private Word target;

	private int currentWordLength;

	private float nextSpawn = 0;
	private float width;

	private float y;
	private float minX;
	private float maxX;

	private Dictionary<int, List<string>> wordsDB;

	private void Awake () {
		width = letterPrefab.GetComponent<Renderer>().bounds.size.x;
		Vector3 camPos = Camera.main.transform.position;
		float camSize = Camera.main.orthographicSize;
		y = camPos.y + camSize;
		minX = camPos.x - camSize;
		maxX = camPos.x + camSize + 1;
		wordsDB = new WordsReader().ReadFromFile(wordsFile);
		currentWordLength = minWordLength;
	}
	
	private void Update () {
		if (Time.time > nextSpawn) {
			CreateRandomWord();
			nextSpawn = Time.time + Random.Range(1,3);
			IncreaseDifficulty();
		}
	}

	private void CreateRandomWord () {
		Vector2 position;
		position.y = y;
		position.x = Random.Range(minX, maxX);
		List<string> wordsList = wordsDB[currentWordLength];
		string name = wordsList[Random.Range(0, wordsList.Count)];
		GameObject parent = (GameObject)Instantiate(wordPrefab, Vector3.zero, Quaternion.identity);
		if (name != null) {
			foreach(char c in name){
				GameObject letter = LoadLetter(c);
				letter.transform.parent = parent.transform;
				letter.transform.localPosition = position;
				position.x += width;
			}
		}
		AddWord(name, parent);
	}
	
	private GameObject LoadLetter (char letter) {
		GameObject instance = (GameObject)Instantiate(letterPrefab, Vector2.zero, Quaternion.identity);
		string name = "Letters/letter" + letter.ToString().ToUpper();
		Sprite sprite = Resources.Load<Sprite>(name);
		instance.GetComponent<SpriteRenderer>().sprite = sprite;
		return instance;
	}

	public bool DestroyLetter (char letter) {
		bool match = false;
		if (target.gameObject == null) { // target is null
			for (int i = 0; i < nextIndex; i++) {
				Word word = words[i];
				if (LetterMatch(word, letter)) {
					match = true;
					target = word;
					RemoveNextLetter(target);
					target.counter++;
					break;
				}
			}
		} else {
			if (LetterMatch(target, letter)) {
				match = true;
				RemoveNextLetter(target);
				target.counter++;
				if (target.counter >= target.name.Length) {
					RemoveWord(target);
				}
			}
		}

		return match;
	}

	private void AddWord(string name, GameObject parent) {
		Word word = new Word();
		word.name = name;
		word.counter = 0;
		word.gameObject = parent;
		word.index = nextIndex;
		words[nextIndex] = word;
		nextIndex++;
	}

	private void RemoveWord(Word word) {
		int lastIndex = nextIndex - 1;
		if (lastIndex >= 0) {
			int currentIndex = word.index;
			Word last = words[lastIndex];
			last.index = currentIndex;
			words[currentIndex] = last;
			Destroy(target.gameObject);
			word.gameObject = null;
			nextIndex--;
		}
	}

	private bool LetterMatch(Word word, char letter) {
		return word.name[word.counter] == letter;
	}

	private void RemoveNextLetter (Word word) {
		Destroy(word.gameObject.transform.GetChild(0).gameObject);
	}

	private void IncreaseDifficulty () {
		currentWordLength = Mathf.Clamp(currentWordLength + 1, minWordLength, maxWordLength);
	}
}
