using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class PlayerListManager : NetworkBehaviour
{
	[SyncVar]
	string usernameSync;

	public void AddUsername (string username)
	{
		Text myText = GetComponent<Text> ();
		myText.text = usernameSync + "\n" + username;
		usernameSync = myText.text;
		Debug.Log ("after: " + usernameSync);
	}
}
