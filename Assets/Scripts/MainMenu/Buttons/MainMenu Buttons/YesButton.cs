using UnityEngine;
using System.Collections;

public class YesButton : ButtonParent {

    /*
         Programmer: Daniel Boisselle
         Appears when player selects exit, if yes is selected close application
    */
    // Use this for initialization
    protected override void Start()
    {
        base.Start();
    }

    //Called OnSubmit()
    public void ExitApplication()
    {
        Debug.Log("Quitting!");
        Application.Quit();
    }

}
