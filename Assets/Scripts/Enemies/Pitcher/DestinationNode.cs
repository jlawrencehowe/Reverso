using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DestinationNode : MonoBehaviour {
    /*
        Programmer: Daniel Boisselle

        Each node keeps track of its own neighbors. 
        Each pitcher will call this node's behavior and ask for a new destination to go
    */
    public Transform upNode;
    public Transform downNode;
    public Transform leftNode;
    public Transform rightNode;

    List<Transform> edges = new List<Transform>(); //A node might not have 4 neighbors, this list keeps track of how many neighbors there are

	
    void Start()
    {
        StartCoroutine("GenerateDestinations");
    }

    //Called by PitcherDestinationManager upon pitcher's arriving at new node
    public Transform GetNewDestination(Transform lastDestination)
    {
        int choice = Random.Range(0, edges.Count-1);
        if (!edges[choice].Equals(lastDestination))
        {
            return edges[choice];
        }
        else
        {
            if (choice == edges.Count - 1)
            {
                return edges[0];
            }
            else
            {
                return edges[choice + 1];
            }
        }
    }

    //This coroutine ensures that the nodes are generated after the 2d array of nodes is complete
    IEnumerator GenerateDestinations()
    {
        yield return new WaitForSeconds(1f);

        if (upNode != null) edges.Add(upNode);
        if (downNode != null) edges.Add(downNode);
        if (leftNode != null) edges.Add(leftNode);
        if (rightNode != null) edges.Add(rightNode);
    }
}
