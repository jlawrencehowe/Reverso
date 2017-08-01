using UnityEngine;
using System.Collections;

public class LookAtPlayer : MonoBehaviour {

    Transform player;
    Quaternion neededRotation;
    Quaternion interpolatedRotation;

    public  int reduction = 6;

    public float rotationSpeed = 1f;

    // Use this for initialization
    void Start () {

        player = GameObject.FindGameObjectWithTag("Player").transform;
	
	}
	
	// Update is called once per frame
	void Update () {

        //transform.LookAt(player.transform);
        //calculate the rotation needed
        neededRotation = Quaternion.LookRotation((player.position/ reduction) - transform.position);

        //use spherical interpollation over time 
         transform.rotation = Quaternion.Slerp(transform.rotation, neededRotation, Time.deltaTime );

       // transform.LookAt(player.transform.position / reduction );

    }
}
