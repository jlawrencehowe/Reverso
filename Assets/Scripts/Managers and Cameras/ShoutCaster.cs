using UnityEngine;
using System.Collections;

public class ShoutCaster : MonoBehaviour {

    /// <summary>
    /// Handles all audio for the shoutcaster.
    /// All functions called from outside sources.
    ///
    /// Programmer: Daniel Boisselle
    /// </summary>
    /// 

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    static AudioSource aud;


    //Conditions for audio to be played
    static bool canPlay = true;
    static float cdTime = 0;
    static public float cdMax = 5;

    //Random Chance vars
    static float enemyChance = 6;

    //ALL CLIPS EVER FUCK
    //PowerUps clips
    public AudioClip[] triplep;
    public AudioClip[] healthp;
    public AudioClip[] invincp;
    public AudioClip[] powerp;

    public AudioClip[] enemyp;

    public AudioClip[] clemp;

    public AudioClip[] startp;

    public AudioClip[] countdownp;
    public AudioClip[] reversop;

    //Static clips are received from the public inspector clips
    //PowerupClips
    static AudioClip[] triple;
    static AudioClip[] health;
    static AudioClip[] invinc;
    static AudioClip[] power;

    static AudioClip[] enemy;

    static AudioClip[] clem;

    static AudioClip[] start;
    static AudioClip[] countdown;
    static AudioClip[] reverso;

    void Start()
    {
        //These object references are required
        //Powerup
        triple = triplep;
        health = healthp;
        invinc = invincp;
        power = powerp;

        //Enemy
        enemy = enemyp;

        //Clem
        clem = clemp;

        //Intro animation clips
        start = startp;
        countdown = countdownp;
        reverso = reversop;
        
        aud = GetComponent<AudioSource>();
    }


    //Each sound function calls this to check if it can be played
    static bool CheckSound()
    {
        //Checks if theres currently something playing AND that we are not on cooldown
        return (!aud.isPlaying && canPlay);
    } 
    
    //Called by death particles on enemies
    public static void PlayEnemyDeath()
    {
        if (CheckSound())
        {
            if ((int)Random.Range(0, enemyChance) == 0)
            {
                PlaySound(enemy[(int)Random.Range(0, enemy.Length)]);
            }
        }
    }

    //Called on clem's death particles
    public static void PlayClemDeath()
    {
        PlaySound(clem[(int)Random.Range(0, clem.Length)]);
    }


    //Called from PlayerController().OnTriggerEnter()
    public static void PlayPowerUp(string p)
    {
        if (CheckSound()) //Returns true if not currently playing audio and the cooldown has passed
        {

            switch (p)
            {
                case "Triple":
                    {
                        PlaySound(triple[(int) Random.Range(0,triple.Length)]);
                        break;
                    }
                case "Power":
                    {
                        PlaySound(power[(int)Random.Range(0, power.Length)]);
                        break;
                    }
                case "Health":
                    {
                        PlaySound(health[(int)Random.Range(0, health.Length)]);
                        break;
                    }
                case "Invincibility":
                    {
                        PlaySound(invinc[(int)Random.Range(0, invinc.Length)]);
                        break;
                    }
            }
        }
    }

    //Called by main camera animator
    public static void PlayStartSound(string clip)
    {
        switch(clip)
        {
            case "start":
                aud.clip = start[(int) Random.Range(0, start.Length)];
                break;
            case "countdown":
                if (aud.isPlaying)
                    aud.Stop();
                aud.clip = countdown[(int)Random.Range(0, countdown.Length)];
                break;
            case "reverso":
                if (aud.isPlaying)
                    aud.Stop();
                aud.clip = reverso[(int)Random.Range(0, reverso.Length)];
                break;       
        }
        
        aud.Play();
    }

    //all clips play this
    static void PlaySound(AudioClip clip)
    {
        aud.clip = clip;
        aud.Play();
        canPlay = false;
    }

    void Update()
    {
        
        //If a sound was played, update the timer
        if(!canPlay && !aud.isPlaying)
        {
            cdTime += Time.deltaTime;
            if(cdTime >= cdMax)
            {
                canPlay = true;
                cdTime = 0;
            }
        }
    }

   

    public void ChangeVolume(int vol)
    {
        aud.volume = vol / 10;
    }
}
