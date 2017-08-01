using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeVoiceVol : MonoBehaviour {

    AudioSource aud;
    AudioSource thisAud;
    Slider s;

    void Start()
    {
        aud = GameObject.FindGameObjectWithTag("Shoutcaster").GetComponent<AudioSource>();
        thisAud = GetComponent<AudioSource>();
        s = GetComponent<Slider>();
    }

	public void ChangeVoice()
    {
        aud.volume = s.value/10;
        thisAud.volume = s.value / 10;
        thisAud.Play();

        
    }
}
