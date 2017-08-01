using UnityEngine;
using System.Collections;

public class BadBallTutorial : MonoBehaviour {
	
	Rigidbody rb;
	public ParticleSystem ps;
	PlayerControllerTutorial player;
	float speed = 1500f;
	bool isPlayers = false;
	public int wallCounter = 4;
	private PowerUpSpawner powerUpSpawner;
	public GameObject tempBalls;

	public AudioSource ballAudio;
	public AudioSource enemyHitAudioSource;

	//Score variables
	private ScoreController scoreController;
	
	public TutorialController tutorialController;
	public Vector3 startPos;
	public bool isCharged = false;

	public GameObject badBalls;
	
	//bool isCharge = false;

	// Use this for initialization
	void Start () {
		startPos = this.transform.position;
		rb = GetComponent<Rigidbody>();
		rb.AddRelativeForce(Vector3.forward * speed); 
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerTutorial>();
		//scoreController = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreController>();
		//powerUpSpawner = GameObject.Find("PowerUpManager").GetComponent<PowerUpSpawner>();
		tutorialController = GameObject.Find("TutorialController").GetComponent<TutorialController>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player" && !isPlayers)
		{
			//other.GetComponent<HealthController>().TakeDamage();
			this.transform.position = startPos;
			other.GetComponent<PlayerControllerTutorial>().StartPos();

			
		}

		if(other.tag == "Racket"){
			ballAudio.Play();
			ps.startSize = 0.5f;
            wallCounter = 3;
            this.transform.rotation = new Quaternion(0, 0, 0, 0);
			rb.velocity = new Vector3(0, 0, 0);
			rb.AddRelativeForce(player.rot * speed);
			if(!isPlayers){
				
				isPlayers = true;
				ps.startColor = new Color(0, 255, 0,255);
			}

			if(player.isCharged){
				rb.velocity = Vector3.zero;
				rb.AddRelativeForce(player.rot * speed * 1.25f);
				isCharged = true;
				ps.startSize = 1f;
				ps.startColor = new Color(0, 122, 255,255);
				this.GetComponent<SphereCollider>().radius = 1.25f;
			}

			if(player.tripleShot){
				GameObject temp = Instantiate(tempBalls, this.transform.position, this.transform.rotation) as GameObject;
				//Vector3 newDir = new Vector3(player.transform.rotation.x, player.transform.rotation.y , player.transform.rotation.z);
				temp.transform.rotation = Quaternion.LookRotation(player.rot, Vector3.up);
				temp.transform.eulerAngles = new Vector3(0, temp.transform.eulerAngles.y + 45, 0);
				temp.GetComponent<TempBallScript>().AddForce(Vector3.forward);
				
				temp = Instantiate(tempBalls, this.transform.position, this.transform.rotation) as GameObject;
				temp.transform.rotation = Quaternion.LookRotation(player.rot, Vector3.up);
				temp.transform.eulerAngles = new Vector3(0, temp.transform.eulerAngles.y - 45, 0);
				//newDir = new Vector3(player.transform.rotation.x, player.transform.rotation.y, player.transform.rotation.z);
				temp.GetComponent<TempBallScript>().AddForce(Vector3.forward);
			}
			player.tripleShot = false;

		}

		if(other.tag == "Enemy" && isPlayers)
		{
			//scoreController.UpdatePlayerScore(500);
			//powerUpSpawner.enemyDeath(other.gameObject.transform.position);
			if(tutorialController.chargeHitEnemy){
				if(isCharged){
					other.GetComponent<PitcherHealthTutorial>().TakeDamage();
					tutorialController.chargeHitEnemy = false;
					tutorialController.StartSpawnPowerUp();
					Destroy(gameObject);
				}
			}
			else
           		 other.GetComponent<PitcherHealthTutorial>().TakeDamage();
			//enemyHitAudioSource.Play();
		}
	}

	void OnCollisionEnter(Collision other)
	{
        
        if (other.gameObject.tag == "Wall" )
        {
			if(tutorialController.dodge){
				tutorialController.dodge = false;
				tutorialController.StartReflectEnemyAttack();
			}
			if(tutorialController.chargeHitEnemy || tutorialController.reflectEnemyAttack){
				isPlayers = false;
				ps.startColor = new Color(255, 0, 0,255);
				tutorialController.inGameEnemyBall = Instantiate(badBalls, startPos, Quaternion.Euler(0, -90, 0)) as GameObject;
				Destroy(gameObject);
				//GameObject.Find("Clementine").GetComponent<PlayerControllerTutorial>().StartPos();
			}
			else{
			Destroy(gameObject);
            wallCounter--;
            if(wallCounter != 0)
            {
                ballAudio.Play();
            }
            /*if(wallCounter <= 0){
                Debug.Log("huh?");
				rb.velocity = new Vector3(0, 0, 0);
				rb.AddRelativeForce(player.rot * speed);
				isCharge = false;
				ps.startSize = 0.5f;
				ps.startColor = new Color(0, 255, 255,255);
				this.GetComponent<SphereCollider>().radius = 0.75f;
			}*/
			}
        }
        if (wallCounter <= 0)
        {
            //Destroy(gameObject);
        }

    }
	
}

