using UnityEngine;
using System.Collections;

public class attack : MonoBehaviour {
	public GameObject attackobj;
	public GameObject attackobj1;
	public static bool mAttack = false;

	// Update is called once per frame
	public void NewAttack() {  // attack to arkanoid 
		Instantiate (attackobj, transform.position, Quaternion.identity);
	}

	public void NewAttack1() { // attack to tetris
		Instantiate (attackobj1, transform.position, Quaternion.identity);
	}
}
