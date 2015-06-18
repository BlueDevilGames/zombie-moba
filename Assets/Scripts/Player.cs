using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public float speed = 10f;
	
	void Update ()
	{
		if (GetComponent<NetworkView>().isMine) {
			InputMovement ();
		}
	}
	
	void InputMovement ()
	{
		if (Input.GetKey (KeyCode.W))
			GetComponent<Rigidbody> ().MovePosition (GetComponent<Rigidbody> ().position + Vector3.forward * speed * Time.deltaTime);
		
		if (Input.GetKey (KeyCode.S))
			GetComponent<Rigidbody> ().MovePosition (GetComponent<Rigidbody> ().position - Vector3.forward * speed * Time.deltaTime);
		
		if (Input.GetKey (KeyCode.D))
			GetComponent<Rigidbody> ().MovePosition (GetComponent<Rigidbody> ().position + Vector3.right * speed * Time.deltaTime);
		
		if (Input.GetKey (KeyCode.A))
			GetComponent<Rigidbody> ().MovePosition (GetComponent<Rigidbody> ().position - Vector3.right * speed * Time.deltaTime);
	}
}
