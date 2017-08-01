using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeMusicVolume : MonoBehaviour {

    Slider s;
    AudioSource music;
	// Use this for initialization
	void Start () {

        s = GetComponent<Slider>();
        music = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
	
	}
	
    public void ChangeVolume()
    {
        music.volume = s.value / 10;
    }
	
}
