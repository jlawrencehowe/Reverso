using UnityEngine;
using System.Collections;

public class TurretHealth : EnemyHealth {


    /* Programmer(s): Daniel Boisselle
       Keeps track of turret health
       Also adds back the turret's spawn location back to the spawner list
   */

    public int health = 2;
	public AudioSource TurretDamage;
    public GameObject deathParticles;


    //Each turret keeps track of where it spawned so on death it can be reupdated
    public Transform spawnLocation;

    //TurretSpawner class contains the list of spawn points
    TurretSpawner turretSpawner;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        turretSpawner = GameObject.FindGameObjectWithTag("TurretSpawner").GetComponent<TurretSpawner>();
    }

    // Update is called once per frame
    
    //Called by the ball that collided with this turret
    override public void TakeDamage()
    {
		
		TurretDamage.Play ();
        health--;

        if (health == 0)
        {
            score.UpdatePlayerScore(2000);
            turretSpawner.AddSpawn(spawnLocation);
            turretSpawner.numTurrets--;
            Instantiate(deathParticles, transform.position, Quaternion.Euler(-90,0,0));
            Destroy(gameObject);
        }
        else
        {
            score.UpdatePlayerScore(750);
        }
    }
}
