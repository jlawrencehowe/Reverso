using UnityEngine;
using System.Collections;

public class PitcherDestinationManager : MonoBehaviour {
    /*
        Programmer Daniel Boisselle
        *********  Destination Manager  *************

        The destination manager works as a 2d array of vertices each containing 2-4 edges. 
        Enemies will be randomly spawned onto a vertex in the array. Enemies will call this function and ask for a new destination.
        Enemies will receive a new destination and begin their move. Enemies will never be given the destination they arrived from.

    */
    public int columns;
     Transform[,] destinations;

    public PitcherSpawner pitcherSpawner;
   

	void Start () {

        GenerateArray();
        GenerateEdges();
        GiveSpawner(); //Once the 2d array is generated, each
       

    }

    //Called by pitchers to ask for a new destination
    //This acquires the pitcher's current node and gets a random neighboring node
    public Transform GetNewDestination(Transform currentDestination, Transform lastDestination)
    {
     
        return currentDestination.GetComponent<DestinationNode>().GetNewDestination(lastDestination);
    }
	

    void GenerateArray()
    {
        destinations = new Transform[transform.childCount, columns];

        Transform temp;

        //Loop for getting destinations programmatically 
        for (int i = 0; i < transform.childCount; i++)
        {
            temp = transform.GetChild(i);

            for (int j = 0; j < temp.childCount; j++)
            {
                destinations[i, j] = temp.GetChild(j);
            }

        }
    }


    //GenerateEdges() gives each destination node its neighboring nodes.
    void GenerateEdges()
    {
        for (int i = 0; i < destinations.GetLength(0); i++)
        {

            for (int j = 0; j < destinations.GetLength(1); j++)
            {
                if (destinations[i, j] == null)
                    break;
                DestinationNode temp = destinations[i, j].GetComponent<DestinationNode>();

                //Left
                if(j != 0)
                {
                    temp.leftNode = destinations[i , j - 1];
                }

                //Right
                if (j != destinations.GetLength(0) - 1)
                {
                    temp.rightNode = destinations[i , j + 1];
                }

                //Up
                if (i != 0)
                {
                    temp.upNode = destinations[i - 1, j];
                }

                //Down
                if (i != destinations.GetLength(1) - 1)
                {
                    temp.downNode = destinations[i + 1, j ];
                }
            }

        }

    }

    void GiveSpawner()
    {
        pitcherSpawner.spawns = destinations;
    }


    void DebugArray()
    {
        for (int i = 0; i < destinations.GetLength(0); i++)
        {

            for (int j = 0; j < destinations.GetLength(1); j++)
            {
                if (destinations[i, j] == null)
                    break;

                Debug.Log(destinations[i, j].name);
            }

        }
    }
	
	
}
