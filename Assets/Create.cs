using UnityEngine;
using System.Collections;

public class Create : MonoBehaviour {
	public GameObject top;
	public GameObject bottom;

	// Use this for initialization
	void Start () {
		if (Server.topselect) {
			Instantiate (top, transform.position, Quaternion.identity);
		}
		if (Server.bottomselect) {
			Instantiate (bottom, transform.position, Quaternion.identity);
		}
	}

}
