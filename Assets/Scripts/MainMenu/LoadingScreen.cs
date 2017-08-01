using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadingScreen : MonoBehaviour {

    /*
        Programmer: Daniel Boisselle

        Handles the loading of the game
    */
    public Slider loadingSlider; //Loading bar
    public GameObject loadImage; //Xbox image
    public GameObject inputText; //Appears when level is fully loaded
	public int levelToLoad = 0; //decided to load either tutorial or time attack mode

    AsyncOperation async; //Scene container

    bool ready = false;
	
	//Called by the start button
	public void StartLoading()
    {
       
        loadImage.SetActive(true);
		levelToLoad = 1;
        StartCoroutine("LoadAsync");

    }

	public void LoadTutorial()
	{
		
		loadImage.SetActive(true);
		levelToLoad = 2;
		StartCoroutine("LoadAsync");
		
	}
	
	void Update()
	{
        //The player hits A to start the game
        if(ready && Input.GetButtonDown("Submit"))
            {
            async.allowSceneActivation = true; //Alows the load to get to 1f and complete, loading the game
            
        }
    }

    IEnumerator LoadAsync()
    {
        //1 is game
        async = Application.LoadLevelAsync(levelToLoad);
        
        async.allowSceneActivation = false; //Prevents the scene from auto-loading
        while(async.progress <  .9f) //.9f is the max if the scene cannot auto-load
        {
            
            loadingSlider.value = async.progress;
            
            yield return null;
        }
        loadingSlider.value = .9f;
        ready = true;
        inputText.SetActive(true);
    }

    
}
