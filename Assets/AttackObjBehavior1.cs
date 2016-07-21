// Attack to tetris 
using UnityEngine;
using System.Collections;

public class AttackObjBehavior1 : MonoBehaviour {

	void Start () {
		Grid.increaseRowsAbove ();
		transform.position = new Vector3 (0, 15, 0);
		foreach (Transform child in transform)
		{
			Vector2 v = Grid.roundVec2(child.position);
			Grid.grid[(int)v.x, (int)v.y] = child;
		}
		int i = Random.Range(0, 14);
		Destroy (Grid.grid [i, 15].gameObject);
		Grid.grid [i, 15] = null;
	}

}