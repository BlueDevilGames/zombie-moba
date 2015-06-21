using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadingScreenManager : MonoBehaviour
{
	public GameObject champSelect;
	public Transform picturesLayout;
	public Transform[] playerLayoutPoints;
	public Transform[] enemyLayoutPoints;

	// Use this for initialization
	void Start ()
	{
		foreach (Transform point in playerLayoutPoints) {
			GameObject obj = (GameObject)Instantiate (champSelect, point.position, point.rotation);
			Transform trans = obj.transform;
			trans.SetParent (picturesLayout, true);
			trans.FindChild ("Champ Select Image").localScale = new Vector3 (2f, 2f, 1f);
			trans.FindChild ("Champ Select Text").localPosition = new Vector3 (0f, -130f, 0f);
		}
		foreach (Transform point in enemyLayoutPoints) {
			GameObject obj = (GameObject)Instantiate (champSelect, point.position, point.rotation);
			Transform trans = obj.transform;
			trans.SetParent (picturesLayout, true);
			trans.FindChild ("Champ Select Image").localScale = new Vector3 (2f, 2f, 1f);
			trans.FindChild ("Champ Select Text").localPosition = new Vector3 (0f, -130f, 0f);
		}

	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
