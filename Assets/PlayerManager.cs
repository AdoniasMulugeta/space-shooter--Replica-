using UnityEngine;
using System.Collections;
[RequireComponent (typeof(Rigidbody))]
public class PlayerManager : MonoBehaviour {
	public float moveSpeed;
	public float tiltAmount;
	public GameObject boltPrefab;
	public Transform boltSpawn;
	public float refireWait;

	private Rigidbody rb;
	private float nextFire;

	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	void Update () {
		movePlayer();
		tiltPlayer();
		fireOnClick();
	}
	void movePlayer(){
		float xInput = Input.GetAxis("Horizontal") * moveSpeed;
		float yInput = Input.GetAxis("Vertical") * moveSpeed;
		rb.velocity = Vector3.right * xInput + Vector3.forward * yInput;
	}
	void tiltPlayer(){
		float xInput = Input.GetAxis("Horizontal") * -tiltAmount;
		transform.rotation = Quaternion.Euler(Vector3.forward * xInput);
	}
	void fireOnClick(){
		if(Input.GetButton("Fire1")&& Time.time > nextFire || Input.GetButtonDown("Fire1")){
			Instantiate(boltPrefab,boltSpawn.position,boltSpawn.rotation);
			nextFire = Time.time + refireWait;
		}

	}
}
