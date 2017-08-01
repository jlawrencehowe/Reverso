using UnityEngine;
using System.Collections;

public class TutorialStartButton : ButtonParent {

	/*
        Programmer: Daniel Boisselle

        Start appears by default, makes loading screen appear.
        Note that the loading screen contains a script that actually loads the game scene
   */
	public GameObject loadingScreen; //Need to get loading screen to get the LoadingScreen class
	public GameObject menuCanvas; //Disbales menu on select
	public Canvas loadingCanvas; 
	
	protected override void Start()
	{
		base.Start();
		loadingCanvas.enabled = false; //Ensures the loadingcanvas is not enabled on game start
	}
	
	//Called OnSubmit()
	public void StartTutorial()
	{
		loadingCanvas.enabled = true; 
		loadingScreen.SetActive(true);
		loadingScreen.GetComponent<LoadingScreen>().LoadTutorial(); //Starts loading the game
		menuCanvas.SetActive(false);
	}
}
