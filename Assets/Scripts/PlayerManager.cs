using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary{
	public float left,right,top,bottom;
}
[RequireComponent (typeof(Rigidbody))]
public class PlayerManager : MonoBehaviour {
	public float moveSpeed;
	public float tiltAmount;
	public GameObject boltPrefab;
	public Transform boltSpawn;
	public float refireWait;
	public Boundary boundary;

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
		checkBoundary();
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
	void checkBoundary(){
		float xClamp = Mathf.Clamp(transform.position.x,boundary.right,boundary.left);
		float zClamp = Mathf.Clamp(transform.position.z,boundary.bottom,boundary.top);
		float yClamp = transform.position.y;
		transform.position = Vector3.right * xClamp + Vector3.up * yClamp + Vector3.forward * zClamp;
	}
}
