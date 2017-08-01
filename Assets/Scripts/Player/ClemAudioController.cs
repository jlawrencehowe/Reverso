using UnityEngine;
using System.Collections;

public class ClemAudioController : MonoBehaviour {

    public AudioSource swishAudio;

	public void PlaySwish()
    {
        swishAudio.Play();

    }
}
