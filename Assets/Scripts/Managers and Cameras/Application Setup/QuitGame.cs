using UnityEngine;
using System.Collections;

public class QuitGame : MonoBehaviour {

	/// <summary>
    /// Allows back button on controller to quit on every scene
    /// </summary>
    /// 
	void Update () {

        if(Input.GetButtonDown("Select"))
        {
            Application.Quit();
        }
	
	}
}
