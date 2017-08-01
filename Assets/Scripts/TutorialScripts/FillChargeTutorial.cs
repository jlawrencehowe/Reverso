using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FillChargeTutorial : MonoBehaviour {

    PlayerControllerTutorial pc;
    Slider slider;

    

	// Use this for initialization
	void Start () {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerTutorial>();
        slider = GetComponent<Slider>();

        slider.maxValue = pc.chargeMax;
	}
	
	// Update is called once per frame
	void Update () {
        slider.value = pc.chargeTime;
	}
}
