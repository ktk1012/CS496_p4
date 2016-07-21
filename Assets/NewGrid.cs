using UnityEngine;
using System.Collections;

public class NewGrid : MonoBehaviour {

	public static int w = 15;
	public static int h = 15;
	public static Transform[,] grid = new Transform[w, h];

	/* round the vector */
	public static Vector2 roundVec2(Vector2 v)
	{
		return new Vector2(Mathf.Round(v.x), Mathf.Round(v.y));
	}


	public static void decreaseRowsBelow()
	{
		for (int y = 2; y < 14; y++)
			for (int x = 0; x < w; x++)
			{
				if (grid[x, y] != null)
				{   /* move one towards bottom */
					grid[x, y - 1] = grid[x, y];
					grid[x, y] = null;

					/* update block position */
					grid[x, y - 1].position += new Vector3(0, -1, 0);
				}
			}
	}
}
