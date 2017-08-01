using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NoButton : ButtonParent {

    /*
        Programmer: Daniel Boisselle
        Returns to the main menu
    */
    public GameObject exitCanvas; //Disable the exit canvas
    public GameObject mainMenuCanvas; //Enable the menu canvas
    public Button exitButton; //Select exit again

    protected override void Start()
    {
        base.Start();
    }

    public void ReturnToMenu()
    {
        mainMenuCanvas.SetActive(true);
        exitButton.Select();
        exitCanvas.SetActive(false);
        

    }

}
