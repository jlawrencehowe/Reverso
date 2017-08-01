using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

    /// <summary>
    /// Programmer: Jacob Howe
    /// </summary>

    public AudioSource musicPlayer;

    public AudioClip mainMenu, gamePlay;
	
	//private PersistingGameData persistingGameData;
	
	public static MusicManager musicPlayerObject;

	public float musicVolume;

    public static float sfxVolume = 1;

	// Use this for initialization
	void Start () {
		
		if(musicPlayerObject == null){
			musicPlayerObject = this;
			DontDestroyOnLoad(gameObject);
		}
		else if (musicPlayerObject != this){
			
			Destroy(gameObject);
			
		}
		//if we want to save options
		//persistingGameData = GameObject.Find("PersistingGameData").GetComponent<PersistingGameData>();

        //CHANGE THIS FOR MAIN MENU
		musicPlayer.clip = gamePlay;
		musicPlayer.Play();
		
	}
	
	// Update is called once per frame
	void Update () {

        
		
	}
	

	
	public void UpdateMusicVolume(float musicVolume){
		
		musicPlayer.volume = (musicVolume/100);
		
	}

	/*public void UpdateSFXVolume(float sfxVolume){

		this.sfxVolume = sfxVolume;

	}*/
	
	public void updateMusicClip(int musicClip){
		
		if(musicClip == 1){
			
			musicPlayer.clip = mainMenu;
			musicPlayer.Play();
			
		}
		else if (musicClip == 2){
			
			musicPlayer.clip = gamePlay;
			musicPlayer.Play();
			
		}

		
		
		
	}
}
