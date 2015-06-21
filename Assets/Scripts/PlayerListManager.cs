using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using System.Collections;

public class PlayerListManager : NetworkBehaviour
{
	[SyncVar]
	string
		usernameSync = "Players:";

	public void AddUsername (string username)
	{
//		if (!isServer) {
//			this.SendReadyToBeginMessage (username);
//		}
		Text myText = GetComponent<Text> ();
		myText.text = usernameSync + "\n" + username;
		usernameSync = myText.text;
	}

	const short MyBeginMsg = 1002;
	NetworkClient m_client;
	
	public void SendReadyToBeginMessage (string message)
	{
		var msg = new StringMessage (message);
		m_client.Send (MyBeginMsg, msg);
	}
	
	public void Start ()
	{
		m_client = this.GetComponent<NetworkClient> ();
		NetworkServer.RegisterHandler (MyBeginMsg, OnServerReadyToBeginMessage);
	}
	
	void OnServerReadyToBeginMessage (NetworkMessage netMsg)
	{
		string beginMessage = netMsg.ReadMessage<StringMessage> ().ToString ();
		Debug.Log ("received OnServerReadyToBeginMessage " + beginMessage);
		usernameSync = usernameSync + beginMessage;
	}
}
