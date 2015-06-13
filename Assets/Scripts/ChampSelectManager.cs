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

	public GameObject champSelect;
	public Transform champSelectLayout;
	public Transform[] champSelectLayoutPoints;
	public Transform playerLayout;
	public Transform[] playerLayoutPoints;

	private int numSelected = 0;
	private JSONNode jsonData;

	// Use this for initialization
	void Start ()
	{
		// Load and parse champion data from JSON file to instantiate champ images/text
		loadData ();

		// Add click handlers to images
	}

	/// <summary>
	/// Handles action when champion has been clicked, populates player's team image/text
	/// </summary>
	/// <param name="name">Name of the champion selected</param>
	void champ_onClick (string name)
	{
		if (numSelected >= 3) {
			return;
		}
		GameObject obj = (GameObject)Instantiate (champSelect, playerLayoutPoints [numSelected].position, playerLayoutPoints [numSelected].rotation);
		Transform trans = obj.transform;
		trans.SetParent (playerLayout, true);
		// Fill object with data
		Text txt = obj.GetComponentInChildren<Text> ();
		txt.text = name;
		numSelected++;
	}

	/// <summary>
	/// Loads champion data and fills UI text/images.
	/// </summary>
	void loadData ()
	{
		string data = this.ReadFileToString (DATA_FILE_PATH);
		jsonData = JSON.Parse (data);
		for (int i = 0; i < NUM_CHAMPIONS; i++) {
			GameObject obj = (GameObject)Instantiate (champSelect, champSelectLayoutPoints [i].position, champSelectLayoutPoints [i].rotation);
			Transform trans = obj.transform;
			trans.SetParent (champSelectLayout, true);
			// Fill object with data
			Text txt = obj.GetComponentInChildren<Text> ();
			txt.text = jsonData [i] ["name"];
			Button btn = obj.GetComponentInChildren<Button> ();
			btn.onClick.AddListener (() => champ_onClick (txt.text));
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
