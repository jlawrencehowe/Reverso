using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public ScoreController score;

	// Use this for initialization
	protected virtual void Start () {

        score = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreController>();
	}
	
	// Update is called once per frame
	protected virtual void Update () {
	
	}

    public virtual void TakeDamage()
    {
        
    }
}
