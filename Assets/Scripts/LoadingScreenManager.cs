using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using SimpleJSON;

public class LoadingScreenManager : MonoBehaviour
{
	public GameObject champSelect;
	public Transform picturesLayout;
	public Transform[] playerLayoutPoints;
	public Transform[] enemyLayoutPoints;

	private Hashtable champNameToIndex = new Hashtable ();

	// Use this for initialization
	void Start ()
	{
		setupChampNameToIndex ();

		foreach (Transform point in playerLayoutPoints) {
			GameObject obj = (GameObject)Instantiate (champSelect, point.position, point.rotation);
			// Setup object layout
			Transform trans = obj.transform;
			trans.SetParent (picturesLayout, true);
			trans.FindChild ("Champ Select Image").localScale = new Vector3 (2f, 2f, 1f);
			trans.FindChild ("Champ Select Button").localScale = new Vector3 (2f, 2f, 1f);
			trans.FindChild ("Champ Select Text").localPosition = new Vector3 (0f, -130f, 0f);
			// Fill object with data
			Text txt = obj.GetComponentInChildren<Text> ();
			txt.text = ChampSelectManager.champ;
			Debug.Log ("Created champ " + ChampSelectManager.champ + " with username " + TitleScreenManager.username);
			// TODO create champ object here, using jsonData[champNameToIndex [ChampSelectManager.champ]]["attack"]
		}
		foreach (Transform point in enemyLayoutPoints) {
			GameObject obj = (GameObject)Instantiate (champSelect, point.position, point.rotation);
			// Setup object layout
			Transform trans = obj.transform;
			trans.SetParent (picturesLayout, true);
			trans.FindChild ("Champ Select Image").localScale = new Vector3 (2f, 2f, 1f);
			trans.FindChild ("Champ Select Text").localPosition = new Vector3 (0f, -130f, 0f);
		}

	}

	/// <summary>
	/// Sets up a map of champ name to the corresponding index in the json data
	/// </summary>
	private void setupChampNameToIndex ()
	{
		for (int i = 0; i < ChampSelectManager.NUM_CHAMPIONS; i++) {
			champNameToIndex.Add (ChampSelectManager.jsonData [i] ["name"], i);
		}
	}
}
