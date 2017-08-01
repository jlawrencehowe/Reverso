using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialController : MonoBehaviour {


	public bool welcomeText, leftJoystick, rightJoyStick, strikeBall, hitEnemy,
	dodge, reflectEnemyAttack, chargeHitEnemy, spawnPowerUp, 
	displayPowerUp, finish;
	public bool tutorialTextOn = true;

	public GameObject textBackground;
	public GameObject tutorialTextObject;
	public Text tutorialText;
	public GameObject powerUpBackground;
	public GameObject powerUpDescriptionText;

	public GameObject ball;
	public GameObject ballLocation;
	public GameObject enemy;
	public GameObject enemyLocation;
	public GameObject enemyBall;
	public GameObject inGameEnemyBall;
	public float movementTimer = 0;

	public GameObject temp;
	public GameObject inGameBall;

	public GameObject player;

	public GameObject inGameEnemy;

	public GameObject enemyBallLocation;

	public GameObject invulnerability;

	public MusicManager musicManager;

	// Use this for initialization
	void Start () {

		welcomeText = true;
		StartTutorial();
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetButtonDown("Submit") && tutorialTextOn){
			tutorialTextObject.SetActive(false);
			textBackground.SetActive(false);
			tutorialTextOn = false;
			if(welcomeText){
				welcomeText = false;
				StartLeftJoyStick();
			}
			if(finish){
				musicManager.updateMusicClip(1);
				Application.LoadLevel(0);
			}
			if(displayPowerUp){
				powerUpBackground.SetActive(false);
				powerUpDescriptionText.SetActive(false);
				StartFinish();
			}
			if(dodge && inGameEnemyBall == null){
				inGameEnemyBall = Instantiate(enemyBall, enemyBallLocation.transform.position, Quaternion.Euler(0, -90, 0)) as GameObject;
			}
			if(hitEnemy && inGameEnemy == null){
				inGameEnemy = Instantiate(enemy, enemyLocation.transform.position, this.transform.rotation) as GameObject;
			}
			if(reflectEnemyAttack ){
				if(inGameEnemy == null){
					inGameEnemy = Instantiate(enemy, enemyBallLocation.transform.position, Quaternion.Euler(0, -90, 0)) as GameObject;
				}
				if(inGameEnemyBall == null){
					inGameEnemyBall = Instantiate(enemyBall, enemyBallLocation.transform.position, Quaternion.Euler(0, -90, 0)) as GameObject;
				}
			}
			if(chargeHitEnemy){
				if(inGameEnemy == null){
					inGameEnemy = Instantiate(enemy, enemyBallLocation.transform.position, Quaternion.Euler(0, -90, 0)) as GameObject;
				}
				if(inGameEnemyBall == null){
					inGameEnemyBall = Instantiate(enemyBall, enemyBallLocation.transform.position, Quaternion.Euler(0, -90, 0)) as GameObject;
				}
			}
		}
	
	}

	public void StartTutorial(){
		tutorialText.text = "Welcome to Reverso. You will now be trained to participate in Reverso as our newest competitor.";
		tutorialTextObject.SetActive(true);
		textBackground.SetActive(true);
	}

	public void StartLeftJoyStick(){
		tutorialText.text = "To begin, use the left joystick to move around.";
		tutorialTextObject.SetActive(true);
		textBackground.SetActive(true);
		tutorialTextOn = true;
		leftJoystick = true;
	}

	public void StartRightJoyStick(){
		tutorialText.text = "Perfect. Now use the right joystick to rotate.";
		tutorialTextObject.SetActive(true);
		textBackground.SetActive(true);
		tutorialTextOn = true;
		rightJoyStick = true;
	}

	public void StartStrikeBall(){
		tutorialText.text = "Now projectiles will be launched. Try to strike them back using the right or left trigger to swing.";
		tutorialTextObject.SetActive(true);
		tutorialTextOn = true;
		textBackground.SetActive(true);
		inGameBall = Instantiate(ball, ballLocation.transform.position, this.transform.rotation) as GameObject;
		strikeBall = true;
	}

	public void StartHitEnemy(){
		tutorialText.text = "Try to hit another robot now with the projectile. A white projectile" +
			" will not hurt anyone. Blue and green will hurt enemy robots";
		tutorialTextObject.SetActive(true);
		tutorialTextOn = true;
		textBackground.SetActive(true);
		hitEnemy = true;
	}

	public void StartDodge(){
		Destroy(inGameBall);
		tutorialText.text = "Be careful. Try to dodge the red projectiles. They will hurt you if you touch them. Also you can use the left or" +
			" right bumpers to do a quick dash to dodge quickly.";
		tutorialTextObject.SetActive(true);
		tutorialTextOn = true;
		textBackground.SetActive(true);
		//temp = Instantiate(enemy, enemyLocation.transform.position, this.transform.rotation) as GameObject;
		dodge = true;
		player.GetComponent<PlayerControllerTutorial>().StartPos();
	}



	public void StartReflectEnemyAttack(){
		tutorialText.text = "Besides dodging the red projectiles, they can be hit back and turned into green projectiles which are safe to you" +
			" but dangerous to enemies";
		tutorialTextObject.SetActive(true);
		tutorialTextOn = true;
		textBackground.SetActive(true);
		reflectEnemyAttack = true;
		player.GetComponent<PlayerControllerTutorial>().StartPos();
	}

	public void StartChargeHitEnemy(){
		tutorialText.text = "Time to unleash a powerful attack. Hold either trigger to charge an attack. Once the charge is complete, indicated by" +
			"the bar in front, let go and strike a projectile to super charge it.";
		tutorialTextObject.SetActive(true);
		tutorialTextOn = true;
		textBackground.SetActive(true);;
		chargeHitEnemy = true;
	}

	public void StartSpawnPowerUp(){
		Instantiate(invulnerability, enemyBallLocation.transform.position, Quaternion.Euler(0,0,0));
		tutorialText.text = "Oh! A powerup spawned. They drop randomly off defeated robots. Go pick it up to gain a temporary powerup!";
		tutorialTextObject.SetActive(true);
		tutorialTextOn = true;
		textBackground.SetActive(true);
		spawnPowerUp = true;
	}

	public void StartDisplayPowerUp(){
		powerUpBackground.SetActive(true);
		tutorialTextOn = true;
		powerUpDescriptionText.SetActive(true);
		displayPowerUp = true;
	}

	public void StartFinish(){
		tutorialText.text = "You are ready to compete now. Just remember to protect your reversticles with our patented protector cup.";
		tutorialTextObject.SetActive(true);
		tutorialTextOn = true;
		textBackground.SetActive(true);
		finish = true;
	}
}
