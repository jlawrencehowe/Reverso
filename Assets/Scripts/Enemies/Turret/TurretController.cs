using UnityEngine;
using System.Collections;

public class TurretController : MonoBehaviour {

    /* Programmer(s): Daniel Boisselle
       Handles turret behavior, including attacking and animating
   */

  
    public GameObject badBall;
    public Transform lookTarget;   //Initalized as findwithtag

    //Timer variables
    public float attackCD;
    float attackTime;

    //Prevent the timer from increasing if currently in the animation of attacking
    bool attacking = false;

    //Inserted in heirarchy
    public Animator modelAnim;
    public Animator attackAnim;

    //Ensures that turrets face the center when spawned
    Transform ArenaCenter;  //Initalized as findwithtag

    void Start () {

        lookTarget = GameObject.FindGameObjectWithTag("TurretTarget").transform;
        ArenaCenter = GameObject.FindGameObjectWithTag("ArenaCenter").transform;
       
        LookAtCenter();

        //Adjust turret position, else it spawns inside the arena
        transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
	
	}
	
	// Update is called once per frame
	void Update () {


        //Timer, determines when to attack
        if (!attacking)
        {
            attackTime += Time.deltaTime;

            if (attackTime >= attackCD)
            {
                attackTime = 0;

                attacking = true;

                modelAnim.SetTrigger("Attack"); 
                attackAnim.SetTrigger("Attack"); 
            }
        }
        else //If attacking, always face the player
        {
            transform.LookAt(lookTarget.position);
        }
	
	}

    //Animator Public Functions
    public void AttackPlayer()
    {
        Instantiate(badBall, transform.position, transform.rotation);
    }
    public void IdleReturn()
    {
        attacking = false;
    }

    public void Blank()
    {

    }
    public void LookAtCenter()
    {
        transform.LookAt(ArenaCenter.position);
    }
}
