using UnityEngine;
using System.Collections;

public class PowerUpController : MonoBehaviour {

	public float timer = 0;

	// Use this for initialization
	void Start () {

        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
	


	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		timer += Time.deltaTime;
		/*if(timer > 6 && this.GetComponent<MeshRenderer>().material.color.a > 0.01f){
			Color color = this.GetComponent<MeshRenderer>().material.color;
			this.GetComponent<MeshRenderer>().material.color = new Color(color.r, color.g, color.b, color.a - Time.deltaTime * 0.2f);
		}*/
    
		if(timer >= 10){
			Destroy (gameObject);
		}

	}
}
