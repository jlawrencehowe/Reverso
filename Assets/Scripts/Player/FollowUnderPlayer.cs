using UnityEngine;
using System.Collections;

public class FollowUnderPlayer : MonoBehaviour {

   public  Transform player;
	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame

    public float subtract = .7f;
	void Update () {

        transform.position = new Vector3(player.position.x, player.position.y - subtract, player.position.z);
	
	}
}
