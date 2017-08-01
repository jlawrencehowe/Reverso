using UnityEngine;
using System.Collections;

public class PitcherHealth : EnemyHealth {

    /*
        Programmer(s): Daniel Boisselle
        handles health of pitchers and updates score
    */

	//audio source for pitcher health damage
	public AudioSource PitcherDamage;

    public GameObject deathParticles;

    PitcherSpawner ps; //Class that handles how many pitchers exist in the game

    protected override void Start()
    {
        base.Start();

        ps = GameObject.FindGameObjectWithTag("PitcherSpawner").GetComponent<PitcherSpawner>();
    }

    //Called by the ball the collided with this pitcher
    public override void TakeDamage()
    {
		//implement sound
		
		//PitcherDamage.Play ();
		
        base.TakeDamage();
        score.UpdatePlayerScore(750);
        ps.numEnemies--;
        Instantiate(deathParticles, transform.position, Quaternion.Euler(-90, 0, 0)); //This is the explosion
        Destroy(gameObject);
    }
}
