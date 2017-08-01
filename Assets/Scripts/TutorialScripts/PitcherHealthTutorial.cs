using UnityEngine;
using System.Collections;

public class PitcherHealthTutorial : EnemyHealth {

    /*
        Programmer(s): Daniel Boisselle
        handles health of pitchers and updates score
    */

	//audio source for pitcher health damage
	public AudioSource PitcherDamage;

    public GameObject deathParticles;

	public TutorialController tutorialController;

    PitcherSpawner ps; //Class that handles how many pitchers exist in the game

    protected override void Start()
    {
        //base.Start();
		tutorialController = GameObject.Find("TutorialController").GetComponent<TutorialController>();
        //ps = GameObject.FindGameObjectWithTag("PitcherSpawner").GetComponent<PitcherSpawner>();
    }

    //Called by the ball the collided with this pitcher
    public override void TakeDamage()
    {
		//implement sound
		
		//PitcherDamage.Play ();
		if(tutorialController.inGameBall != null)
			tutorialController.inGameBall.GetComponent<BallControllerTutorial>().Revert();
        base.TakeDamage();
        //score.UpdatePlayerScore(750);
        //ps.numEnemies--;
		if(tutorialController.hitEnemy){
			tutorialController.hitEnemy = false;
			tutorialController.StartDodge();
		}
		if(tutorialController.reflectEnemyAttack){
			tutorialController.reflectEnemyAttack = false;
			tutorialController.StartChargeHitEnemy();
		}
        Instantiate(deathParticles, transform.position, Quaternion.Euler(-90, 0, 0)); //This is the explosion
        Destroy(gameObject);
    }
}
