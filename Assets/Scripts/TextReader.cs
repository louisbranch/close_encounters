//using UnityEngine;
//using System.Collections;
//using System;
//using System.IO;
//
//public class TextReader : MonoBehaviour {
//	protected FileInfo theSourceFile = null;
//	protected StreamReader reader = null;
//	protected string text = "";
//
//	void Start() {
//		theSourceFile = new FileInfo("Assets/Resources/Text/Dictionary.txt");
//		reader = theSourceFile.OpenText();
//		do {
//			text = reader.ReadLine();
//			print (text);
//		} while(text != null);
//	}
//}

