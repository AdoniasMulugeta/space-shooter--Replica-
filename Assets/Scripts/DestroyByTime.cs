using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {
	public float timeDelay;
	void Start () {
		Destroy(gameObject,timeDelay);
	}
}
