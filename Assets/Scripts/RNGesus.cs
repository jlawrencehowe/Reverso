using UnityEngine;
using System.Collections;

public class RNGesus : MonoBehaviour {

    //Welcome to Daniels silly script

    int choice;
	
	
	// Update is called once per frame
	void Update () {
        choice = Random.Range(0, 4);

        Debug.Log(choice);
	
	}
}
