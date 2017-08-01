using UnityEngine;
using System.Collections;

public class SetSFXAudio : MonoBehaviour {


	// Use this for initialization
	void Start () {
        GetComponent<AudioSource>().volume = MusicManager.sfxVolume;

       
	
	}

   
	
	
}
