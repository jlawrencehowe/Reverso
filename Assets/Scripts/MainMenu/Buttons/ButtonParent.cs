using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class ButtonParent : MonoBehaviour {

    /*
        Programmer: Daniel Boisselle
        Every button code inherits from this script. 
        Each button needs to have access to the event system and camera animator
    */

    protected EventSystem es;
    protected Animator menuAnim;


    
    // Use this for initialization
    protected virtual void Start()
    {
        
        
        es = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<EventSystem>();
        menuAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();

    }

   
}
