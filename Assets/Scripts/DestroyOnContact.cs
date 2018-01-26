using UnityEngine;
using System.Collections;

public class DestroyOnContact : MonoBehaviour {
	public GameObject deathParticle;
	public delegate void destroyEvents();
	public static event destroyEvents eventObstacleDestroyed;
	public static event destroyEvents eventPlayerDestroyed;

	void OnTriggerEnter(Collider other){
		if(deathParticle != null){
			Instantiate(deathParticle,transform.position,transform.rotation);
		}
		if(gameObject.tag == "Bolt" && other.tag == "Obstacle"){
			if (eventObstacleDestroyed != null) eventObstacleDestroyed();
		}
		if(gameObject.tag == "Player" && other.tag == "Obstacle"){
			if (eventPlayerDestroyed != null) eventPlayerDestroyed();
		}
		Destroy(gameObject);
	}
}
