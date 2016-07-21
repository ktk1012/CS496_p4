using UnityEngine;
using System.Collections;

public class PressGrid : MonoBehaviour {

	// Use this for initialization
	void Start () {
		foreach (Transform child in transform)
		{
			Vector2 v = NewGrid.roundVec2(child.position);
			NewGrid.grid[(int)v.x, (int)v.y] = child;
		}
	}
}
