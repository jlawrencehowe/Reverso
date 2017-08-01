using UnityEngine;
using System.Collections;

public class OptionsButton : ButtonParent {

    /*
         Programmer: Daniel Boisselle
         
        Options appears by default
    */

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
    }
    
    //Called OnSubmit()
    public void GoToOptions()
    {
        es.enabled = false; //Prevent any actions
        menuAnim.SetTrigger("goOptions"); //Camera goes to options menu
    }

   
}
