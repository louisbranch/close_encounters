using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System.IO;

public class WordManager : MonoBehaviour {

	public GameObject letterPrefab;
	public GameObject wordPrefab;

	protected FileInfo dictionaryFile = null;
	protected StreamReader reader = null;
	protected string text = "";

	private struct Word {
		public string name;
		public GameObject gameObject;
		public int counter;
	}
	
	List<Word> words = new List<Word>();
	Dictionary<string, int> definedWords = new Dictionary<string, int>();
	List<string> tempWords = new List<string>();

	Word target;

	private int value = 0;

	private float nextSpawn = 0;
	private float width;

	private float y;
	private float minX;
	private float maxX;

	private void Awake () {
		width = letterPrefab.GetComponent<Renderer>().bounds.size.x;
		Vector3 camPos = Camera.main.transform.position;
		float camSize = Camera.main.orthographicSize;
		y = camPos.y + camSize;
		minX = camPos.x - camSize;
		maxX = camPos.x + camSize + 1;

		dictionaryFile = new FileInfo("Assets/Resources/Text/Dictionary.txt");
		reader = dictionaryFile.OpenText();
		do {
			text = reader.ReadLine();																	// Reads the line and stores at the string text
			tempWords.Add(text);																		// Adds the text string to List array tempWords
			if (text.Length != 0) {
				foreach(string word in tempWords) {														// For each word in the List array tempWords
					// FIXME For some reason, it does not go to the next text word after the 2nd word
					// OR it reads the word twice, which you can't have more than 2 of the same keys.
					definedWords.Add(text, value++);													// Add the word text and set the value of it 
					foreach(KeyValuePair<string, int> pair in definedWords) {							// For debug purpose
						string entry = pair.Key + " = " + pair.Value;
						Debug.Log(entry);																// Prints the word + the value of the word
					}
				}
			}
		} while(text != null);
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
		string name = tempWords[Random.Range(0, tempWords.Count)];
		GameObject container = (GameObject)Instantiate(wordPrefab, Vector3.zero, Quaternion.identity);
		if (name != null) {
			foreach(char c in name){
				GameObject letter = LoadLetter(c);
				letter.transform.parent = container.transform;
				letter.transform.localPosition = position;
				position.x += width;
			}
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