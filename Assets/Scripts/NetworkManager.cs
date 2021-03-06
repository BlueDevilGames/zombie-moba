﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NetworkManager : MonoBehaviour
{
	public GameObject playerList;
	public Transform canvas;
	public GameObject temp;

	private const string typeName = "Zombies";
	private const string gameName = "TestMOBAGame";
	
	private void StartServer ()
	{
		Network.InitializeServer (4, 25000, !Network.HavePublicAddress ());
		MasterServer.RegisterHost (typeName, gameName);
	}

	void SpawnList ()
	{
		GameObject obj = (GameObject)Network.Instantiate (playerList, new Vector3 (0f, 0f, 0f), Quaternion.identity, 0);
		obj.transform.SetParent (canvas, false);
//		temp.GetComponent<TitleScreenManager> ().setPlayerList (obj);
	}

	void OnServerInitialized ()
	{
		SpawnList ();
		Debug.Log ("Server Initializied");
	}
	void OnGUI ()
	{
		if (!Network.isClient && !Network.isServer) {
			if (GUI.Button (new Rect (100, 100, 250, 100), "Start Server"))
				StartServer ();
			
			if (GUI.Button (new Rect (100, 250, 250, 100), "Refresh Hosts"))
				RefreshHostList ();
			
			if (hostList != null) {
				for (int i = 0; i < hostList.Length; i++) {
					if (GUI.Button (new Rect (400, 100 + (110 * i), 300, 100), hostList [i].gameName))
						JoinServer (hostList [i]);
				}
			}
		}
	}
	
	private HostData[] hostList;
	
	private void RefreshHostList ()
	{
		MasterServer.RequestHostList (typeName);
	}
	
	void OnMasterServerEvent (MasterServerEvent msEvent)
	{
		if (msEvent == MasterServerEvent.HostListReceived)
			hostList = MasterServer.PollHostList ();
	}
	
	private void JoinServer (HostData hostData)
	{
		Network.Connect (hostData);
	}
	
	void OnConnectedToServer ()
	{
		Debug.Log ("Server Joined");
		SpawnList ();
	}
	
	
}