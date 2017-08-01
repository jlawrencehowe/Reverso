using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {


	public GameObject enemy;
	private GameObject spawnedEnemy;
	//private bool delaySpawn = false;
	private float delayTimer = 3;


	// Use this for initialization
	void Start () {
	
		spawnedEnemy = Instantiate(enemy, this.transform.position, this.transform.rotation) as GameObject;

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if(spawnedEnemy == null){
			delayTimer -= Time.deltaTime;
			if(delayTimer <= 0){
				spawnedEnemy = Instantiate(enemy, this.transform.position, this.transform.rotation) as GameObject;
				delayTimer = 3;
			}
		}

	
	}
}
