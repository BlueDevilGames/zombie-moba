using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.IO;
using SimpleJSON;

//This class will load in champions from some set of datafiles. From these datafiles gets pulled a list of the names of the champions
//Then map to an image. This class will then assign the positions for the champions on screen. 

//This class will start the timer script and hold the action for what happens when it hits zero. If you do not select a champion, this class assigns 
//the player one. 

public class ChampSelectManager : MonoBehaviour
{
	public Text[] nameLabels;

	// Use this for initialization
	void Start ()
	{
		//TODO: all data needs to be loaded here from an xml file (presumably using another class to parse xml)

		// Load champion data from JSON file
		string data = this.ReadFileToString ("Data\\champion_simple.json");

		JSONNode jsonData = JSON.Parse (data);
		for (int i=0; i<10; i++) {
			nameLabels [i].text = jsonData [i] ["name"] + "\nAD: " + jsonData [i] ["attack"];
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	/// <summary>
	/// Reads the entire file to a string.
	/// </summary>
	/// <returns>string of the file contents</returns>
	/// <param name="path">Path to the file to be read</param>
	string ReadFileToString (string path)
	{
		string str;
		using (StreamReader streamReader = new StreamReader(path)) {
			str = streamReader.ReadToEnd ();
		}
		return str;
	}
}
