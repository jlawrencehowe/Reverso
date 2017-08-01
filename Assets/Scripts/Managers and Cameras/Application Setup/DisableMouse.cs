using UnityEngine;
using System.Collections;

public class DisableMouse : MonoBehaviour {

    /// <summary>
    /// Programmer: Daniel Boisselle
    /// 
    /// Disables the cursor
    /// </summary>
	

	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
	
	}
	
	
}
