using UnityEngine;
using System.Collections;

public class inactive : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(18, 25, 0);
	}

    void Update()
    {
        if (active1.call)
        {
            Destroy(transform.gameObject);
            active1.call = false;
        }
    }
}
