using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public Boundary spawnBoundary;
	public Transform spawnPointReference;
	public GameObject[] astroids;
	public float spawnWait;
	public float waveWait;
	void Start () {
		StartCoroutine(spawnObstacleWave(10,astroids,astroids.Length));
	}

	void Update () {

	}
	Transform generateSpawnPoint(){
		Transform spawnPoint = spawnPointReference;
		spawnPoint.position = Vector3.up * spawnPoint.position.y +
							  Vector3.forward * spawnPoint.position.z +
							  Vector3.right * Random.Range(spawnBoundary.left,spawnBoundary.right);
		return spawnPoint;
	}
	IEnumerator spawnObstacleWave(int obstacleAmount,GameObject[] obstacles,int variety){
		for (int i=0; i < obstacleAmount; i++){
			spawnObstacle(obstacles[Random.Range(0,Mathf.Clamp(variety,0,obstacles.Length))],generateSpawnPoint());
			yield return new WaitForSeconds(spawnWait);
		}
	}
	void spawnObstacle(GameObject obstacle,Transform spawnPoint){
		Instantiate(obstacle,spawnPoint.position,spawnPoint.rotation);
	}
}
