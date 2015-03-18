using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WordManager : MonoBehaviour {

	public string wordsFile;
	[SerializeField] private int minWordLength;
	[SerializeField] private int maxWordLength;

	[SerializeField] private GameObject letterPrefab;
	[SerializeField] private GameObject wordPrefab;

	private struct Word {
		public string name;
		public GameObject gameObject;
		public int counter;
	}
	
	private List<Word> words = new List<Word>();

	private Word target;

	private int currentWordLength;

	private float nextSpawn = 0;
	private float width;

	private float y;
	private float minX;
	private float maxX;

	private Dictionary<int, List<string>> wordsDB;
	
	private int kills = 0;

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
			nextSpawn = Time.time + Random.Range(0.75f, 1.5f);
		}
	}

	private void CreateRandomWord () {
		Vector2 parentPos;
		Vector2 letterPos = Vector2.zero;
		parentPos.y = y;
		parentPos.x = Random.Range(minX, maxX);
		List<string> wordsList = wordsDB[currentWordLength];
		string name = wordsList[Random.Range(0, wordsList.Count)];
		GameObject parent = (GameObject)Instantiate(wordPrefab, parentPos, Quaternion.identity);
		if (name != null) {
			foreach(char c in name){
				GameObject letter = LoadLetter(c);
				letter.transform.parent = parent.transform;
				letter.transform.localPosition = letterPos;
				letterPos.x += width;
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

	public GameObject DestroyLetter (char letter, out bool hit) {
		hit = false;
		if (target.gameObject == null) { // target is null
			foreach (Word word in words) {
				if (LetterMatch(word, letter)) {
					target = word;
					LockTarget();
					RemoveNextLetter(target);
					target.counter++;
					hit = true;
					break;
				}
			}
		} else {
			if (LetterMatch(target, letter)) {
				RemoveNextLetter(target);
				target.counter++;
				hit = true;
				if (target.counter >= target.name.Length) {
					RemoveWord();
					kills++;
					if (kills % 3 == 0) IncreaseDifficulty();
				}
			}
		}
		return target.gameObject;
	}

	private void AddWord(string name, GameObject parent) {
		Word word = new Word();
		word.name = name;
		word.counter = 0;
		word.gameObject = parent;
		words.Add(word);
	}

	private void RemoveWord() {
		int index = words.FindIndex(w => w.gameObject.Equals(target.gameObject));
		words.RemoveAt(index);
		Destroy(target.gameObject);
		target.gameObject = null;
	}

	private void LockTarget () {
		foreach(SpriteRenderer rendered in target.gameObject.GetComponentsInChildren<SpriteRenderer>()) {
			rendered.color = Color.red;
		}
	}

	private bool LetterMatch(Word word, char letter) {
		return word.name[word.counter] == letter;
	}

	private void RemoveNextLetter (Word word) {
		Destroy(word.gameObject.transform.GetChild(1).gameObject);
	}

	private void IncreaseDifficulty () {
		currentWordLength = Mathf.Clamp(currentWordLength + 1, minWordLength, maxWordLength);
	}
}
