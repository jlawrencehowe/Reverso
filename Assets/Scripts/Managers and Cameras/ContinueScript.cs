using UnityEngine;
using System.Collections;

public class ContinueScript : MonoBehaviour {
    /// <summary>
    /// Programmer: Daniel Boisselle
    /// 
    /// This is enabled when the game is over, the player may hit A or Start to load the main menu
    /// </summary>
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        if (Input.GetButtonDown("Submit") || Input.GetButtonDown("Pause"))
        {
            Application.LoadLevel(0);
        }
	
	}
}
