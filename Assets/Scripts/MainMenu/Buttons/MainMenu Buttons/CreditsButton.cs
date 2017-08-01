using UnityEngine;
using System.Collections;

public class CreditsButton : ButtonParent {

    /*
        Programmer: Daniel Boisselle
        Appears by default on main menu, goes to credits section
   */
    // Use this for initialization
    protected override void Start()
    {
        base.Start();
    }

    //Called OnSubmit()
    public void GoToCredits()
    {
        es.enabled = false; //Prevent player from taking any action while going to credits. Is reenabled in MenuController class
        menuAnim.SetTrigger("goCredits"); //Camera goes to credits area
    }
}
