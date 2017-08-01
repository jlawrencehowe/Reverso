using UnityEngine;
using System.Collections;

public class PitcherSpawner : MonoBehaviour {

    /*
        Programmer(s): Daniel Boisselle
        Handles timing and spawning of pitchers
    */

    public GameObject Pitcher;    

    public Transform[,] spawns; //This is acquired by PitcherDestinationManager class, once it is generated it calls a function to pass it here

    //timer variables
    float spawnTimer;
    public float spawnMax = 5;

    public int numEnemies = 0;
    public int maxEnemies = 4;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //Timer
        if (numEnemies < maxEnemies)
        {
            spawnTimer += Time.deltaTime;

            if (spawnTimer >= spawnMax)
            {
                int x = Random.Range(0, spawns.GetLength(0));  //As the spawn locations are a 2d array, we randomly choose one of them, we need need 2 random ints
                int y = Random.Range(0, spawns.GetLength(1));

                GameObject myPitcher = Instantiate(Pitcher, spawns[x, y].position, transform.rotation) as GameObject;

                myPitcher.GetComponent<PitcherController>().spawnPoint = spawns[x, y]; //Each pitcher remembers where it was spawned (why?)
                spawnTimer = 0;
                numEnemies++;
            }
        }

	
	}
}
