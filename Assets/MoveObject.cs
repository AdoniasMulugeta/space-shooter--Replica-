using UnityEngine;
using System.Collections;

public class MoveObject : MonoBehaviour {
	public float moveSpeed;
	void Start () {
		GetComponent<Rigidbody>().velocity = Vector3.forward * moveSpeed;
	}
}
