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
	const string DATA_FILE_PATH = "Data\\champion_simple.json";
	const int NUM_CHAMPIONS = 10;

	public Text[] nameLabels;
	public Image[] images;
	public Text[] playerSelectedNameLabels;

	private int numSelected = 0;

	// Use this for initialization
	void Start ()
	{
		// Load and parse champion data from JSON file
		loadData ();

		// Add click handlers to images
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("mouse down");
			RaycastHit hit = new RaycastHit ();
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			Transform select = GameObject.FindWithTag ("Champion").transform;
			if (Physics.Raycast (ray, out hit, (float)100.0)) {
				playerSelectedNameLabels [numSelected].text = "Asfd";
				numSelected++;
			}
		}
	}

	/// <summary>
	/// Loads champion data and fills UI text/images.
	/// </summary>
	void loadData ()
	{
		string data = this.ReadFileToString (DATA_FILE_PATH);
		JSONNode jsonData = JSON.Parse (data);
		for (int i = 0; i < NUM_CHAMPIONS; i++) {
			nameLabels [i].text = jsonData [i] ["name"] + "\nAD: " + jsonData [i] ["attack"];
		}
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
