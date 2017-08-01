using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeModeManager : GameModeManager {
    /// <summary>
    /// Programmer: Jacob Howe, Daniel Boisselle
    /// 
    /// Handles timer and intercepts game over signal from HealthController
    /// </summary>

	public bool gameStart = false;
	public bool gameOver = false;
	public float gameTimer = 300;
	public Text timerSeconds;
    public Text timerMilli;
	public HealthController playerHealth;
	public PlayerController playerController;
	
	
	

	public MusicManager musicManager;

    public Animator cameraAnim;

    

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        musicManager = GameObject.FindGameObjectWithTag("Music").GetComponent<MusicManager>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthController>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        musicManager.updateMusicClip(3);
    }

    // Update is called once per frame
    protected override void Update () {
			

		if(!gameOver){
			gameTimer -= Time.deltaTime;
			if(gameTimer <= 0){
				
                GameOver();
			}

            //This converts the gametimer float to an int so we can seperate the seconds and the milliseconds
            int cast = (int) (gameTimer * 100f);
           // timerMilli.text = (cast % 100).ToString(); //Gets the milli

            cast /= 100;
            timerSeconds.text = cast.ToString(); //Gets the seconds  
			
		}


	
	
	}

    public override void GameOver()
    {
        Debug.Log("GameOver");
        base.GameOver();
        gameOver = true;
        playerController.gameOver = true;
        gameTimer = 0;
        cameraAnim.SetTrigger("Zoom");

    }
        
    
}
