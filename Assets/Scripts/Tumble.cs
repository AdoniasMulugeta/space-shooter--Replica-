using UnityEngine;
using System.Collections;

public class Tumble : MonoBehaviour {
	public float tumbleSpeed;
	void Start () {
		GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumbleSpeed;
	}
}
