using UnityEngine;
using System.Collections;

public class OptionsBackButton : ButtonParent {

    
	// Use this for initialization
	protected override void Start () {
        base.Start();

    }

    

    public void GoToMenu()
    {
        es.enabled = false;
        menuAnim.SetTrigger("backOptions");
    }
}
