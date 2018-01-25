using UnityEngine;
using System.Collections;

public class DestroyOnContact : MonoBehaviour {
	public GameObject deathParticle;
	void OnTriggerEnter(Collider other){
		if(deathParticle != null)
			Instantiate(deathParticle,transform.position,transform.rotation);
		Destroy(gameObject);
	}
}
