using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleScreenManager : MonoBehaviour
{

	public GameObject errorText;
	public GameObject settingsMenu;
	public Canvas canvas;
	public Button playButton;
	public Button settingsButton;
	public InputField userNameField;

	private Rect optionsWindow = new Rect ((Screen.width / 2) - 100, Screen.height / 2 - 200, 200, 200);
	private float volume = 1.0f;
	private string clicked = "";
	private bool spawnSettings = false;

	public static string username;

	// Use this for initialization
	void Start ()
	{
		username = "Player";
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void onPlay (InputField userNameInput)
	{
		if (!userNameInput.textComponent.text.Equals ("")) {
			username = userNameInput.textComponent.text;
//			userNameInput.enabled = false;
			Application.LoadLevel ("Champ Select Screen");
		} else {
			GameObject obj = (GameObject)Instantiate (errorText, new Vector3 (0, 0, 0), Quaternion.identity);
			obj.transform.SetParent (canvas.transform, false);
		}
	}

	void OnGUI ()
	{
		if (clicked.Equals ("Settings") && spawnSettings == true) {
			GameObject obj = (GameObject)Instantiate (settingsMenu, new Vector3 (0, 0, 0), Quaternion.identity);
			obj.transform.SetParent (canvas.transform, false);
			spawnSettings = false;

			Button backButton = obj.GetComponentInChildren<Button>();
			backButton.onClick.AddListener(() => removeSettings(obj));
		}
	}
	
	void removeSettings(GameObject obj) 
	{
		Destroy (obj);
		toggleUIInteraction ();
	}

	public void onSettings ()
	{
		clicked = "Settings";
		spawnSettings = true;
		toggleUIInteraction ();
	}

	void doOptionsWindow (int windowID)
	{
		GUILayout.Box ("Volume");
		volume = GUILayout.HorizontalSlider (volume, 0.0f, 1.0f);
		AudioListener.volume = volume;
		if (GUILayout.Button ("Back")) {
			clicked = "";
			toggleUIInteraction ();
		}
		GUI.DragWindow (new Rect (0, 0, Screen.width, Screen.height));
	}

	void toggleUIInteraction ()
	{
		userNameField.interactable = !userNameField.interactable;
		playButton.interactable = !playButton.interactable;
		settingsButton.interactable = !settingsButton.interactable;
	}

}
