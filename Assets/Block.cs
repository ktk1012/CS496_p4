using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "ball") {
			Destroy (transform.gameObject);
			Vector3 v = transform.position;
			Grid.grid [(int)Mathf.Round (v.x), (int)Mathf.Round (v.y)] = null;
		}

	}
		
}
