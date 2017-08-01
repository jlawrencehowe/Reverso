using UnityEngine;
using System.Collections;

public class BlockheadExplode : MonoBehaviour {

    Material mat;

    Color startCol;
    Color endCol;

    float currentTime;
    public float maxTime = 4f;
	// Use this for initialization
	void Start () {

        mat = GetComponentInChildren<SkinnedMeshRenderer>().material;
        startCol = mat.color;
	
	}
	
	// Update is called once per frame
	void Update () {
        
       // mat.SetColor("_Color",Color.red);
	
	}
}
