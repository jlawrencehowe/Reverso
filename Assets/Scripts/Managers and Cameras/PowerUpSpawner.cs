using UnityEngine;
using System.Collections;

public class PowerUpSpawner : MonoBehaviour {

    /// <summary>
    /// Programmer: Jacob Howe
    /// </summary>
	public float powerUpMultiplier = 0;
	public GameObject tripleShot, healthUp, invulnerability, powerSwing;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


	
	}

	public void enemyDeath(Vector3 enemyLocation){

		powerUpMultiplier++;

		int random = Random.Range(1, 101);
		if(random <= powerUpMultiplier){
			random = Random.Range(0, 4);
			if(random == 0){
				Instantiate(tripleShot, enemyLocation, this.transform.rotation);
			}
			else if(random == 1){
				Instantiate(healthUp, enemyLocation, this.transform.rotation);
			}
			else if(random == 2){
				Instantiate(invulnerability, enemyLocation, this.transform.rotation);
			}

			else{
				Instantiate(powerSwing, enemyLocation, this.transform.rotation);
			}
			powerUpMultiplier = 0;
		}

	}
}
