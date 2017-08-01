using UnityEngine;
using System.Collections;

public class TempBallScript : MonoBehaviour {

	PlayerController player;
	//Transform playerTran;
	
	
	Rigidbody rb;
	
	Vector3 hitDir;
	Vector3 moveDir;
	
	ParticleSystem ps;
	public float speed = 10f;
	
	bool isBlue = true;
	//bool changeColor = false;
	bool hitFirstWall = false;
	public bool playerBall = false;
	private PowerUpSpawner powerUpSpawner;
	public GameObject tempBalls;

	public AudioSource ballAudio;
	public AudioSource enemyHitAudioSource;

	//bool isCharge = false;
	
	
	//Score variables
	private ScoreController scoreController;
	
	int wallCounter;

	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		//playerTran = GameObject.FindGameObjectWithTag("Player").transform;
		rb = GetComponent<Rigidbody>();
		ps = GetComponent<ParticleSystem>(); 

		wallCounter = 10;
		scoreController = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreController>();
		//changeColor = true;
		ps.startColor = new Color(0, 255, 0,255);
		powerUpSpawner = GameObject.FindGameObjectWithTag("PowerUpManager").GetComponent<PowerUpSpawner>();

	}
	
	

	public void AddForce(Vector3 force){

		rb.AddRelativeForce(force * speed);

	}
	
	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Wall")
		{
			ballAudio.Play();

            if(!hitFirstWall)
			    hitFirstWall = true;
			wallCounter--;

			if(wallCounter <= 0){
				/*rb.velocity = new Vector3(0, 0, 0);
				rb.AddRelativeForce(hitDir.normalized * speed);
				//isCharge = false;
				ps.startSize = 0.5f;
				ps.startColor = new Color(0, 255, 255,255);
				this.GetComponent<SphereCollider>().radius = 0.75f;*/

                Destroy(gameObject);
            }
			
		
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Racket" && hitFirstWall)
		{
			ballAudio.Play();
			rb.velocity = Vector3.zero;
			this.transform.rotation = new Quaternion(0, 0, 0, 0);
			hitDir = player.rot;
			rb.AddForce(hitDir.normalized * speed);
			

			if(player.isCharged){
				rb.velocity = Vector3.zero;
				rb.AddForce(hitDir.normalized * speed * 1.25f);
				//isCharge = true;
				ps.startSize = 1.25f;
				ps.startColor = new Color(0, 122, 255,255);
				this.GetComponent<SphereCollider>().radius = 1.25f;
			}

            //Another triple ball script
			if(player.tripleShot){
                //Instantiate Ball One
                GameObject temp = Instantiate(tempBalls, this.transform.position, this.transform.rotation) as GameObject;
                temp.transform.rotation = Quaternion.LookRotation(player.rot, Vector3.up); //Face Forward
                temp.transform.eulerAngles = new Vector3(0, temp.transform.eulerAngles.y + 45, 0); //Rotate clockwise
                temp.GetComponent<TempBallScript>().AddForce(Vector3.forward); //Force it forward

                //Instantiate Ball Two
                temp = Instantiate(tempBalls, this.transform.position, this.transform.rotation) as GameObject;
                temp.transform.rotation = Quaternion.LookRotation(player.rot, Vector3.up);   //Face forward
                temp.transform.eulerAngles = new Vector3(0, temp.transform.eulerAngles.y - 45, 0); //Rotate counter clockwise
                temp.GetComponent<TempBallScript>().AddForce(Vector3.forward); //Force it forward

                player.tripleShot = false;
            }
			
			
			
		}
		
		if(other.tag == "Enemy" && isBlue)
		{
			scoreController.UpdatePlayerScore(50);
			powerUpSpawner.enemyDeath(other.gameObject.transform.position);
			Destroy(other.gameObject);
			enemyHitAudioSource.Play();
		}
	}
	

}
