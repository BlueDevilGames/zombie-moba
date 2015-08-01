using UnityEngine;
using System.Collections;

public class Store : MonoBehaviour {

	private bool storeToggle;
	private GameObject inGameGUI;

	// Use this for initialization
	void Start () {
		storeToggle = true;
		inGameGUI = GameObject.FindGameObjectWithTag("InGameGUI");
		GameObject.
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("i")) {
			storeToggle = !storeToggle;
			inGameGUI.SetActive(storeToggle);

		}
	}
}
