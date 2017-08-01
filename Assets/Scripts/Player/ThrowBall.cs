using UnityEngine;
using System.Collections;

public class ThrowBall : MonoBehaviour {

    public Transform parent;
    PitcherController ec;
    
    void Start()
    {
        ec = parent.GetComponent<PitcherController>();
    }

	void InstantiateBall()
    {
        ec.ThrowBall();
    }

    void StartMoving()
    {
        ec.MoveAgain();
    }
}
