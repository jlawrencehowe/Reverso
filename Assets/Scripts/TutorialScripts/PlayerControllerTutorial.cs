using UnityEngine;
using System.Collections;

public class PlayerControllerTutorial : MonoBehaviour
{
    /// <summary>
    /// Programmers: Daniel Boisselle, Jacob Howe
    /// </summary>

	//Public Variables
	public Vector3 rot;  
	public float speed = 15f;
	public float dashSpeed;
	private float baseSpeed = 15f;

    public Animator clemAnim;
    public Animator racketAnim;

    //Control Vars
    bool m_isAxisInUse = false;

    //Member Variables
    Rigidbody rb;
	Vector3 moveDir;
	Vector3 upRot;

	//Animator anim;
	public ParticleSystem racketChargedPS;
    
    //Dash variables
	private bool isDashing = false;
	Vector3 dashDir;
	private float dashTimer = 0.1f;
	private float dashCD = 1f;


	public GameObject playerBall;
	
    //Charge Variables
	public float chargeTime = 0;
    public float chargeMax = .5f;
	public bool isCharged = false;

    //PowerupVars
	public bool isInvulnerable = false;

	public bool superCharged = false;
	public float superChargedTimer = 0;

    private bool healthUpIsTrue = false;

    public bool tripleShot = false;
    public int amountOfBalls = 3;
    private float ballRecovery = 8;

    //GameOver
    public bool gameOver = false;

    //Audio Vars
    public AudioSource racketAudio;
	public AudioSource musicAudioSource;
	public AudioSource powerUps;
	public AudioClip healthPowerUp,tripleBall,powerShot,invulnerability;


	public ParticleSystem tripleShotParticles, invulnerabilityParticles, healthUpParticles, superShotParticles;

    Vector3 moveRotation;

	public TutorialController tutorialController;

	public GameObject startPos;

	// Use this for initialization
	void Start ()
	{
		musicAudioSource = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
		rb = GetComponent<Rigidbody> ();
		//anim = GetComponent<Animator> ();

		rot = new Vector3 (1, 0, 1);
	
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (!gameOver) {
            //Get Player's input on left stick
            
                moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                moveRotation = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
				if(!tutorialController.tutorialTextOn)
					tutorialController.movementTimer += Time.deltaTime;
				if(tutorialController.leftJoystick && tutorialController.movementTimer >= 1.5f){
					tutorialController.leftJoystick = false;
					tutorialController.rightJoyStick = true;
					tutorialController.movementTimer = 0;
					tutorialController.StartRightJoyStick();
				}
            }




            if (Input.GetAxisRaw ("Dash") != 0 && dashTimer <= 0 && !isDashing && dashCD <= 0 && !tutorialController.leftJoystick && !tutorialController.rightJoyStick) {
				isDashing = true;
				dashDir = moveDir;
				dashTimer = 0.1f;

			}

			//Right Stick input for rotation
			if (Input.GetAxis ("rHorizontal") != 0 || Input.GetAxis ("rVertical") != 0 && !isDashing) {
				rot = new Vector3 (Input.GetAxis ("rHorizontal"), 0, Input.GetAxis ("rVertical")).normalized;
				if(!tutorialController.tutorialTextOn)
					tutorialController.movementTimer += Time.deltaTime;
					if(tutorialController.rightJoyStick && tutorialController.movementTimer >= 1.5f){
						tutorialController.rightJoyStick = false;
						tutorialController.strikeBall = true;
						tutorialController.StartStrikeBall();
					}
			}
			if (rot != Vector3.zero) {
				transform.rotation = Quaternion.LookRotation (rot, Vector3.up);
			}
			


            //Animation code

            float angleDifference = Vector3.Angle(moveRotation, rot);
            if(moveDir.magnitude != 0)
            {
                clemAnim.SetBool("isMoving", true);
                    
            }
            else
            {
                clemAnim.SetBool("isMoving", false);
            }
            clemAnim.SetFloat("Angle", angleDifference);


			//Right Trigger Input
			if (Input.GetAxisRaw ("Fire1") != 0 && !isDashing && !tutorialController.welcomeText && 
			    !tutorialController.leftJoystick && !tutorialController.rightJoyStick && !tutorialController.dodge) {
				
                //Swing immediately, and if continued held down start charging
				if (m_isAxisInUse == false) {
                    chargeTime = 0; //Reset charge time
					Swing (); //Swing immediately
                    
					m_isAxisInUse = true; //This keeps this axis like a button
				}
                
			 //Increase time held down
                if(chargeTime >= chargeMax) //If button held down long enough it is charged
                {                    
                    chargeTime = chargeMax; //Prevent any slider issues
                    isCharged = true;           //We're charged          
                }
                else
                {                 
                    chargeTime += Time.deltaTime; //Increase charge timer
                }

				speed = baseSpeed / 2;
                

            }
            //Right trigger not held down
            else
            {
                if (m_isAxisInUse) //If we were still held down
                {
                    m_isAxisInUse = false;   //Not anymore
                                  
                    if(chargeTime >= chargeMax/2) //Don't bother swinging if we weren't held down long enough
                         Swing();

                    
                    speed = baseSpeed; //Return speed to normal 

                    chargeTime = 0; //Reset charge time
                }
			}



		/*	//throw ball input
			if (Input.GetAxisRaw ("Throw") != 0 && !isDashing && amountOfBalls > 0 && !leftTriggerDown) {
				leftTriggerDown = true;
				amountOfBalls--;
				GameObject ball = Instantiate (playerBall, this.transform.position, new Quaternion (0, 0, 0, 0)) as GameObject;
				ball.GetComponent<TempBallScript> ().playerBall = true;
				ball.GetComponent<TempBallScript> ().AddForce (rot.normalized);

			}

			//allows another ball to be thrown after releasing trigger
			if (Input.GetAxisRaw ("Throw") == 0) {
				leftTriggerDown = false;
			}*/


			//Pause Input
			if (Input.GetButtonDown ("Pause")) {
				if (Time.timeScale == 1 && !tutorialController.tutorialTextOn) {
					Time.timeScale = 0;
					musicAudioSource.Pause();
				} else if(!tutorialController.tutorialTextOn) {
					Time.timeScale = 1;
					musicAudioSource.UnPause();
				}

			}

			//super charged time
			if (superCharged) {
				isCharged = true;
				superChargedTimer -= Time.deltaTime;
				if (superChargedTimer < 0) {
					superCharged = false;
				}
			}
			else{
				superShotParticles.Stop();
			}

			if(superCharged){
				if(superShotParticles.isStopped){
					superShotParticles.Play();
					superShotParticles.startColor = new Color(255, 255, 0);
				}
			}
			else{
				superShotParticles.Stop();
			}
			if(tripleShot){
				if(tripleShotParticles.isStopped){
					tripleShotParticles.Play();
					tripleShotParticles.startColor = new Color(0, 255, 0);
				}
			}
			else{
				tripleShotParticles.Stop();
			}
			if(this.GetComponent<HealthControllerTutorial>().isInvulerable){
				if(invulnerabilityParticles.isStopped){
					invulnerabilityParticles.Play();
					invulnerabilityParticles.startColor = new Color(0, 0, 255);
				}
			}
			else{
				invulnerabilityParticles.Stop();
			}

			if(healthUpIsTrue){
				if(healthUpParticles.isStopped)
					healthUpParticles.Play();

				healthUpParticles.startSize += Time.deltaTime * 8;
				if(healthUpParticles.startSize >= 2){
					healthUpIsTrue = false;
				}

			}
			else if(healthUpParticles.startSize > 0){
				healthUpParticles.startSize -= Time.deltaTime * 8;
				if(healthUpParticles.startSize < 0){
					healthUpParticles.startSize = 0;
				}
			}
			else{
				healthUpParticles.Stop();
			}
		

		}

	
	}

	void FixedUpdate ()
	{
		if (!gameOver) {
			//Move the player. Movedir == 0 when left thumbstick is not in use
            
			if (!isDashing) {
				rb.velocity = moveDir * speed;
			} else {

				rb.velocity = dashDir * dashSpeed;

				if (dashTimer <= 0) {
					isDashing = false;
					dashCD = 1f;
					dashTimer = 0.2f;
				}
			}
			if (dashTimer >= -1)
				dashTimer -= Time.deltaTime;
			if(dashCD >= -1){
				dashCD -= Time.deltaTime;
			}

		}

		if(amountOfBalls < 3){
			ballRecovery -= Time.deltaTime;
			if(ballRecovery <= 0){
				amountOfBalls++;
				ballRecovery = 8;
			}
		}

	}

	//Called in Update() > Right Trigger
	void Swing ()
	{
      
		clemAnim.SetTrigger ("Swing");
        racketAnim.SetTrigger("Swing");
	}

    //Collide with powerups placed on ground
	public void OnTriggerEnter (Collider coll)
	{

		if (coll.gameObject.tag == "TripleShot") {
			tripleShot = true;
			Destroy (coll.gameObject);
			powerUps.PlayOneShot(tripleBall);

		} else if (coll.gameObject.tag == "HealthUp") {

			this.GetComponent<HealthController> ().healthBar.value += 40;
			if (this.GetComponent<HealthController> ().healthBar.value >= 100) {
				this.GetComponent<HealthController> ().healthBar.value = 100;
			}
			healthUpIsTrue = true;
			Destroy (coll.gameObject);
			powerUps.PlayOneShot(healthPowerUp);
		} else if (coll.gameObject.tag == "PowerSwing") {
			
			superCharged = true;
			superChargedTimer = 8;
			Destroy (coll.gameObject);
		} else if (coll.gameObject.tag == "Invulnerability") {
			tutorialController.spawnPowerUp = false;
			tutorialController.StartDisplayPowerUp();
			this.GetComponent<HealthControllerTutorial> ().isInvulerable = true;
			this.GetComponent<HealthControllerTutorial> ().invulnerableTimer = 8;
			Destroy (coll.gameObject);
			powerUps.PlayOneShot(invulnerability);
		} 

	}

    //Called in animator
	public void DisableCharge ()
	{
		isCharged = false;
        
	}

	public void StartPos(){
		this.transform.position = startPos.transform.position;
	}
}
