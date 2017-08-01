using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	
	NavMeshAgent agent;
	
	Transform destParent;
	Transform[] destinations;
	Transform player;
	int choice;
	
	//Attack thought
	float thoughtTimer = 0f;
	public float thoughtTick =  1f;
	int attackMin;
	
	//AttackUpdate variables
	public GameObject Projectile;
	public Transform spawnPoint;
	bool attackPlayer = false;
	float attackTimer;
	//float rotateLerp;
	
	
	bool attacked = false;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		agent = GetComponent<NavMeshAgent>();
		destParent = GameObject.FindGameObjectWithTag("Destination").transform;
		destinations = new Transform[4];
		attackMin = Random.Range(0, 10);
		
		
		//Populate destination array
		for (int i = 0; i < destParent.childCount; i++)
		{
			destinations[i] = destParent.GetChild(i);
		}
		
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (attackPlayer)
		{
			AttackUpdate();
		}
		else
		{
			
			//Pathfinder
			if (!agent.pathPending) //If a path is being calculated then disregard
			{
				if (agent.remainingDistance <= agent.stoppingDistance)  //If we are coming to a stop
				{
					if (agent.velocity.sqrMagnitude == 0 || !agent.hasPath) //If the agent has no velocity and does not have a current path
					{
						choice = Random.Range(0, 4);
						agent.SetDestination(destinations[choice].position);
					}
				}
				
				
			}
			
			//Think about attacking
			thoughtTimer += Time.deltaTime;
			
			if (thoughtTimer >= thoughtTick)
			{
				thoughtTimer = 0f;
				
				int r = Random.Range(0, 41);
				
				if (r >= attackMin)
				{
					attackMin += Random.Range(0, 3);
				}
				else
				{
					agent.Stop();
					//rotateLerp = 0f;
					attackTimer = 0f;
					attackPlayer = true;
				}
			}
		}//End of else
		
		
		
	}
	
	void AttackUpdate()
	{
		
		transform.LookAt(player.position);
		
		attackTimer += Time.deltaTime;
		
		if(attackTimer >= 2f && !attacked)
		{
			Instantiate(Projectile, spawnPoint.position, transform.rotation);
			attacked = true;
			
		}
		if(attackTimer >= 3f)
		{
			
			agent.Resume();
			attackMin = Random.Range(0, 10);
			attackPlayer = false;
		}
	}
}

