using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerListManager : MonoBehaviour
{

	public void AddUsername (string username)
	{
		Text myText = GetComponent<Text> ();
		myText.text = myText.text + "\n" + username;
	}
}
