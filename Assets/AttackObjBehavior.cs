// Attack to arkanoid
using UnityEngine;
using System.Collections;

public class AttackObjBehavior : MonoBehaviour {
	
	void Start () {
		NewGrid.decreaseRowsBelow ();
		transform.position = new Vector3 (0, 13, 0);
		foreach (Transform child in transform)
		{
			Vector2 v = NewGrid.roundVec2(child.position);
			NewGrid.grid[(int)v.x, (int)v.y] = child;
		}
	}
		
}
