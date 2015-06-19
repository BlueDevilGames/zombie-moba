using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleScreenManager : MonoBehaviour {

	public GameObject errorText;
	public Canvas canvas;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onPlay(InputField userNameInput) {
		if (!userNameInput.textComponent.text.Equals ("")) {
			Debug.Log (userNameInput.textComponent.text);
//			Application.LoadLevel("Champ Select Screen");
		} else {
			GameObject obj = (GameObject) Instantiate(errorText, new Vector3(0, 0, 0), Quaternion.identity);
			obj.transform.SetParent(canvas.transform, false);
		}
	}
}
