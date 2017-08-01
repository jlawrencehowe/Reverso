using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ExitButton : ButtonParent {

    /*
        Programmer: Daniel Boisselle
        Appears on main menu by default, brings up exit confirmation
   */

    public GameObject exitCanvas; //Exit menu to appear
    public GameObject mainMenuCanvas; //Disable main menu
    public Button noButton; //Default button to select, the no button

    protected override void Start()
    {
        base.Start();
    }

    //Called OnSubmit()
    public void GoToExit()
    {
        exitCanvas.SetActive(true);
        noButton.Select();
        mainMenuCanvas.SetActive(false);

    }
}
