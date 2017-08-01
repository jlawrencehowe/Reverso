using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurretSpawner : MonoBehaviour {

    /* Programmer(s): Daniel Boisselle
        Handles the spawning of turrets in-game
    */

    List<Transform> spawns = new List<Transform>(); //List to keep track of available spawns

    //Floats to keep track of turret spawn timing
    float turretTimer;
    public float turretMax = 10f;

    //Turret Object to Spawn
    public GameObject Turret;

    //Ints keep track of the number of spawned turrets
    public int numTurrets = 0;
    public int maxNumTurrets = 4;


	
	void Start () {

        //Get all the spawn points at start
        for(int i = 0; i < transform.childCount; i++)
        {
            spawns.Add(transform.GetChild(i));
        }
        

    }
	

	void Update () {

        //If there isnt the max number of turrets, spawn a new one
        if (numTurrets < maxNumTurrets)
        {
           //Spawner 
            turretTimer += Time.deltaTime;  
            if (turretTimer >= turretMax)  
            {
                turretTimer = 0;
                int random = Random.Range(0, spawns.Count);

                GameObject tempTurret = Instantiate(Turret, spawns[random].position, Quaternion.identity) as GameObject;
                numTurrets++;
                
                tempTurret.GetComponent<TurretHealth>().spawnLocation = spawns[random];

                spawns.RemoveAt(random);   //This removes the spawner from the list of spawns available
                                            //Turrets themselves contain class TurretController that add it back when destroyed

            }
        }
	
	}

    //Called on death of turret to add their spawn point back to the spawn list
    public void AddSpawn(Transform trans)
    {
        spawns.Add(trans);
    }
}
