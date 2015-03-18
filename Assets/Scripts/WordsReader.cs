using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class WordsReader {

	private Dictionary<int, List<string>> words = new Dictionary<int,List<string>>();

	public Dictionary<int, List<string>>  ReadFromFile (string name) {
		StringReader reader;
		string word;

		TextAsset file = Resources.Load<TextAsset>("Text/" + name);
		reader = new StringReader(file.text);
		do {
			word = reader.ReadLine();										// Reads the line and stores at the string text
			if (word != null) {												// Skips null in string
				AddWord(word);
			}
		} while(word != null);

		return words;
	}

	private void AddWord (string word) {
		int length = word.Length;
		if (this.words.ContainsKey(length)) {
			List<string> list = this.words[length];
			if (list.Contains(word) == false) {
				list.Add(word);
			}
		}
		else {
			List<string> list = new List<string>();
			list.Add(word);
			this.words.Add(length, list);
		}
	}

}
