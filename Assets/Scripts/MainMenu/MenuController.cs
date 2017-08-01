using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class MenuController : MonoBehaviour {

    /*
        Programmer: Daniel Boisselle
        Handles menu enabling/disabling, camera movement triggers 

        Note that the majority, if not all, of the functions here are called in the animator
   */

    EventSystem es; //Disables event system when going to new menu, reenables upon arrival
    Animator anim; // camera animator
   

    
    

	// Use this for initialization
	void Start () {
        es = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<EventSystem>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Animations
    public void GoIdle()
    {
        anim.SetTrigger("goIdle");
    }

    //Menu Canvas Enable/Disable
    public GameObject menuCanvas;
    public Button startBtn; //default button selected 

    //Public Animator functions
    public void DisableMenu()
    {
        menuCanvas.SetActive(false);
    }
    public void EnableMenu()
    {
        es.enabled = true;
        menuCanvas.SetActive(true);
        startBtn.Select();


    }

    //Options Menu Enable/Disable
    public GameObject optionsCanvas; 
    public Slider optionsDefault; //Default button selected

    //Public animator functions
    public void EnableOptions()
    {
        es.enabled = true;
        optionsCanvas.SetActive(true);
        optionsDefault.Select();
    }
    public void DisableOptions()
    {
        optionsCanvas.SetActive(false);
    }

    //Options Menu Enable/Disable
    public GameObject creditsCanvas;
    public Button creditsDefault; //Default button selected

    //Public animator functions
    public void EnableCredits()
    {
        es.enabled = true;
        creditsCanvas.SetActive(true);
        creditsDefault.Select();
    }
    public void DisableCredits()
    {
        creditsCanvas.SetActive(false);
    }



}
