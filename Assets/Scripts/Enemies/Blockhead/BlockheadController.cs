/*
 * Made by Taylor
 * 
 * 
 */
using UnityEngine;
using System.Collections;

public class BlockheadController : MonoBehaviour {
	//rigidbody so it can not fall through the floor and also so it can die
	Rigidbody blockheadBody;
	//navmesh agent
	NavMeshAgent myNav;
	//player location
	private Transform clemPos;
	//animator
	public Animator anim;


    //Color variables
    Material mat;
    Color startCol;
    Color endCol;
    float currentTime;
    public float maxTime = 4f;


    void Start () {
		//find the player
		clemPos = GameObject.FindGameObjectWithTag ("Player").transform;
		myNav = GetComponent<NavMeshAgent> ();

        //Color changing vars
        mat = GetComponentInChildren<SkinnedMeshRenderer>().material;
        startCol = mat.color;
    }

	void Update () {
		//make blocky's position clementine's.
		myNav.SetDestination(clemPos.position);
		anim.SetFloat("speed",myNav.speed);


        //Timer stuff
        currentTime += Time.deltaTime;

        mat.SetColor("_Color", Color.Lerp(startCol, Color.red, currentTime / maxTime));

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

}
