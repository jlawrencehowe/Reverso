using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeSFXVol : MonoBehaviour
{
    public AudioSource clickAud;
    public AudioSource selectAud;
    
    Slider s;

    void Start()
    {
        
        s = GetComponent<Slider>();
    }

    public void ChangeSFX()
    {
        clickAud.volume = s.value / 10;
        selectAud.volume = s.value / 10;
        MusicManager.sfxVolume = s.value / 10;

        clickAud.Play();
        

    }
}
