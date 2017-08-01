using UnityEngine;
using System.Collections;

public class PitcherController : MonoBehaviour {

    /*
        Programmer(s): Daniel Boisselle
        Handles pitcher movement, attacking, and animations
    */

    //New Destination Stuff
    bool pathFind = false; //Prevents pathfinding if attacking or destination array is still being generated
    PitcherDestinationManager destManager;
    Transform currentDestination;
    Transform lastDestination;

    public Transform spawnPoint; //Spawnpoint is saved because the pitcher needs an initial destination

    Transform lookTarget; //Looktarget  is bandaid fix for bug, read on trello

	NavMeshAgent agent;
	
	
	//Transform player;
	int choice;

    public Animator anim;
    public Animator throwAnim;
	
	//bool attacked = false;

    //NewAttackAI
    public GameObject Projectile;
    bool attacking = false;    
    public int attackMax = 50;
    public int threshold = 45;
    public int threshDefault = 45;

    //float attackTimer = 0f;
   
	
	// Use this for initialization
	void Start () {

        StartCoroutine("Pathfind");
        destManager = GameObject.FindGameObjectWithTag("PitcherSpawner").GetComponent<PitcherDestinationManager>();
        lookTarget = GameObject.FindGameObjectWithTag("PitcherTarget").transform;

		
		agent = GetComponent<NavMeshAgent>();

        currentDestination = spawnPoint;		
	}

    
	
	void Update () {
      

        if (pathFind)
        {
            if (!attacking)
            {
                //Pathfinder
                if (!agent.pathPending) //If a path is being calculated then disregard
                {
                    if (agent.remainingDistance <= agent.stoppingDistance)  //If we are coming to a stop
                    {

                        if (agent.velocity.sqrMagnitude == 0 || !agent.hasPath) //If the agent has arrived at destination
                        {

                            if (Random.Range(0, attackMax) >= threshold) //This is where the pitcher decides to attack or not upon arrival of node
                            {
                                attacking = true; //Prevents pathfinding
                                anim.SetTrigger("attack"); //Model animator
                                throwAnim.SetTrigger("attack"); //Timing of ball being thrown
                            }
                            else
                            {
                                threshold -= Random.Range(0, 4); //If the pitcher didnt attack, it will be more likely to attack again on the next node
                                //Get Destination
                                GetNewDestination();
                            }

                        }
                    }


                }//end pathfinding
                
            } //End attacking if
            else
            {
                AttackUpdate();
            }
        }//end pathfind if
			
	    if(agent.hasPath)
        {
           
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);

        }
       
    }
    //Prevents pathfinding until new node is found
    IEnumerator Pathfind()
    {
        yield return new WaitForSeconds(.5f);
        pathFind = true;
    }

    //Targets the current node to get a new destination
    void GetNewDestination()
    {
        Transform temp = currentDestination;
        currentDestination = destManager.GetNewDestination(currentDestination, lastDestination);
       

        agent.SetDestination(currentDestination.position);
        lastDestination = temp;
    }
	
    //If attacking, we always look at the player
	void AttackUpdate()
    {        
		transform.LookAt(lookTarget.position, Vector3.up);
       
	}


    //Public Animator Functions
    public void ThrowBall()
    {
        Instantiate(Projectile, transform.position, transform.rotation);
    }

    public void MoveAgain()
    {
        attacking = false;
    }

    public void Blank()
    {
        //Exists to throw off the animator. 
        //( ͡° ͜ʖ ͡°) ( ͡° ͜ʖ ͡°) ( ͡° ͜ʖ ͡°) ( ͡° ͜ʖ ͡°) ( ͡° ͜ʖ ͡°)
    }

}

