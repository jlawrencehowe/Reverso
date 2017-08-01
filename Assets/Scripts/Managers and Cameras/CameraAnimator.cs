using UnityEngine;
using System.Collections;

public class CameraAnimator : MonoBehaviour {

    /// <summary>
    /// Programmer: Daniel Boisselle
    /// 
    /// Called when Game is Over, causes camera to zoom in on the score and timer
    /// Also disables clementines mesh and health render in case he is standing on it
    /// </summary>
    

    public GameObject continueText;
    public HealthController clemHealth;
    public SkinnedMeshRenderer ClementineMesh;
    public GameObject healthBar;

    //GameMode Variables set in inspector

    public GameModeManager gm;
    public PlayerController pc;
    public TurretSpawner ts;
    public PitcherSpawner ps;
    public BallController bc;
    public void EnableGame()
    {
        gm.enabled = true;
        pc.enabled = true;
        ts.enabled = true;
        ps.enabled = true;
        bc.enabled = true;
    }

    public void DisableGame()
    {
        gm.enabled = false;
        pc.enabled = false;
        ts.enabled = false;
        ps.enabled = false;
        bc.enabled = false;
    }

    public bool testGame = false;

    void Start()
    {
        if (testGame)
        {
            EnableGame();
        }
        else
            DisableGame();

    }

    public void Shoutcaster(string clip)
    {
        ShoutCaster.PlayStartSound(clip);
    }
    //Called on Zoom at Clem Clip
	public void ActivateGameMode()
    {

    }

    //Called on ZoomAtClem Clip
   public void DisableAnimator()
    {
        GetComponent<Animator>().enabled = false;
        GetComponent<LookAtPlayer>().enabled = true;
    }


    //Public Animator Functions
    public void ShowContinueText()
    {
        ClementineMesh.enabled = false;
        continueText.SetActive(true);
        healthBar.SetActive(false);

    }

    public void DisableDeath()
    {
        clemHealth.enabled = false;
    }
}
