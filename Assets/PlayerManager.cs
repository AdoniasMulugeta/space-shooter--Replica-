using UnityEngine;
using System.Collections;
[RequireComponent (typeof(Rigidbody))]
public class PlayerManager : MonoBehaviour {
	public float moveSpeed;

	private Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	void Update () {
		movePlayer();
	}
	void movePlayer(){
		float xInput = Input.GetAxis("Horizontal") * moveSpeed;
		float yInput = Input.GetAxis("Vertical") * moveSpeed;
		rb.velocity = Vector3.right * xInput + Vector3.forward * yInput;
	}
}
