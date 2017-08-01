using UnityEngine;
using System.Collections;

public class DisableThis : MonoBehaviour {

	public void Disable()
    {
        gameObject.SetActive(false);
    }
}
