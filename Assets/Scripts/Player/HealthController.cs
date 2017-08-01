using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthController : MonoBehaviour
{

    /// <summary>
    /// Programmers: Daniel Boisselle, Jacob Howe
    /// 
    /// Handles Clem's health and signals to the GameModeManager class game over if health = 0
    /// </summary>
    /// 
    public Slider healthBar;


  
    public bool isInvulerable = false;
    public float invulnerableTimer;

	public AudioSource DamageSound;
	public AudioClip deathAudio;


    public Animator damageAnim;



    public GameObject deathParticles;
    public GameObject mesh;

    
    private GameModeManager gm; //Find which game mode we're using

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameModeManager>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {


        if (invulnerableTimer > 0)
            invulnerableTimer -= Time.deltaTime;
        else
        {
            isInvulerable = false;

        }
    }

    public void TakeDamage()
    {
        if (healthBar.value > 0)
        {
            if (!isInvulerable && healthBar.value > 0)
            {
                healthBar.value -= 20;
               
                if(healthBar.value > 0)
                 DamageSound.Play();
            }

            if (!isInvulerable)
            {
                healthBar.value -= 20;
                damageAnim.SetTrigger("takeDamage");

            }


            if (healthBar.value <= 0)
            {

                GameOver();
                Instantiate(deathParticles, transform.position, Quaternion.Euler(-90, 0, 0));
                mesh.SetActive(false);
            }
        }
    }

    void GameOver()
    {
        gm.GameOver();
    }
}
