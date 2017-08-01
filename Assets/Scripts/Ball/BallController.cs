using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {
    /// <summary>
    /// Programmers: Daniel Boisselle, Jacob Howe
    /// 
    /// Handles ball collision behavior
    /// 
    /// Walls actually have bouncy material which only balls can collide with
    /// </summary>

    PlayerController player;
    //Transform playerTran;


    Rigidbody rb;

    Vector3 hitDir;
    Vector3 moveDir;

    ParticleSystem ps;
    public float speed = 10f;

    bool isBlue = false;
    bool changeColor = false;

	public GameObject tempBalls;
	bool isCharge = false;

	public AudioSource ballAudio;
	public AudioSource enemyHitAudioSource;

	
	//Score variables
	//private ScoreController scoreController;

    int wallCounter;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        //playerTran = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        ps = GetComponent<ParticleSystem>(); 
        rb.AddRelativeForce(Vector3.forward * speed);
        wallCounter = 5;
		//scoreController = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreController>();

    }
	
	// Update is called once per frame
	void Update () {

        if(isBlue && !changeColor)
        {
            changeColor = true;
            ps.startColor = new Color(0, 255, 255,255);
        }

        else if(!isBlue && changeColor)
        {
            changeColor = false;
            ps.startColor = Color.white;      
        }
	
	}

  

    void OnCollisionEnter(Collision other)
    {
		

        if(other.gameObject.tag == "Wall")
        {
            ballAudio.pitch = Random.Range(0.9f, 1.1f);
            //Play the wall hit audio
            ballAudio.Play();

            //if its the player's ball
            if(isBlue)
            {
                wallCounter--; //Reduce wall counter
                if(wallCounter <= 0) //If this is the last bounce, return to neutral
                {
                    //If the ball is charged...
                    if(isCharge)
                    {
                        ps.startSize = 0.25f; //reset particle size 
                        rb.velocity = Vector3.zero; //Reset speed to default speed
                        rb.AddRelativeForce(hitDir.normalized * speed);

                        isCharge = false;
                    }
                                       
                    //Turn the ball white and reset to default values
                    ps.startColor = new Color(0, 255, 255, 255);
                    isBlue = false;
                    wallCounter = 5;
                }
            }
      
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Racket")
        {
			//Redirect the balls velocity and rotation
			ps.startSize = 0.25f;
			ballAudio.Play();
           

            hitDir = player.rot;

            //Force the ball forward
            rb.velocity = Vector3.zero;
            rb.AddRelativeForce(hitDir.normalized * speed);

            if (!isBlue)
                isBlue = true;

            wallCounter = 5;


            if (player.isCharged)
            {
                rb.AddRelativeForce(hitDir.normalized * speed * 1.25f); //
              
                ps.startSize = 1f;
                ps.startColor = new Color(0, 122, 255, 255);

                isCharge = true;
      
            }

            //If the player has triple ball
            if (player.tripleShot){

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
			
            other.GetComponent<EnemyHealth>().TakeDamage();
			enemyHitAudioSource.Play();
        }
    }
  
}
