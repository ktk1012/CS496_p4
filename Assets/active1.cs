using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Collections;

public class active1 : NetworkBehaviour
{
    private int tmp;
    float lastFall = 0;
    private bool fst = true;
	private static bool press = false;
    private static bool holdfst = true;
    public static bool call = true;
    public static bool del = false;
	public static Vector3 pos = new Vector3(7, 27, 0);
	[SyncVar]
	public int x;
	[SyncVar]
	public int y;
	[SyncVar]
	public Vector3 ang;


    void Start()
    {
        if (fst)
        {
			transform.position = pos;
            fst = false;
			pos = new Vector3(7, 27, 0);
			x = Mathf.RoundToInt(pos.x);
			y = Mathf.RoundToInt(pos.y);
			ang = transform.eulerAngles;
		}
	
		if (!isValidGridPos ()) {

			Debug.Log ("GAME OVER");
			//Destroy (gameObject);
		}
    }

    bool isValidGridPos()
    {
        foreach (Transform child in transform)
        {
            Vector2 v = Grid.roundVec2(child.position);
            // Not inside Border?
            if (!Grid.insideBorder(v))
                return false;
            // Block in grid cell (and not part of same group)?
            if (Grid.grid[(int)v.x, (int)v.y] != null &&
                Grid.grid[(int)v.x, (int)v.y].parent != transform)
                return false;
        }
        return true;
    }

    void updateGrid()
    {
        // Remove old children from grid
        for (int y = 0; y < Grid.h; ++y)
            for (int x = 0; x < Grid.w; ++x)
                if (Grid.grid[x, y] != null)
                    if (Grid.grid[x, y].parent == transform)
                        Grid.grid[x, y] = null;

        // Add new children to grid
        foreach (Transform child in transform)
        {
            Vector2 v = Grid.roundVec2(child.position);
	        Grid.grid[(int)v.x, (int)v.y] = child;
        }
    }

    // Update is called once per frame
    void Update()
	{
		if (!isServer) {
			transform.position = new Vector3 (x, y, 0);
			transform.eulerAngles = ang;
		}

		else {
			if (Input.GetKeyDown (KeyCode.S)) {  // left
				lastFall = Time.time;
				transform.position += new Vector3 (-1, 0, 0);

				if (!isValidGridPos ())
					transform.position += new Vector3 (1, 0, 0);

				x = Mathf.RoundToInt (transform.position.x);

			} else if (Input.GetKeyDown (KeyCode.E)) { // rotate 
				Debug.Log("rotate");
				transform.Rotate (0, 0, -90);

				if (!isValidGridPos ()) {
					Debug.Log ("revert");
					transform.Rotate (0, 0, 90);
				}
				ang = transform.eulerAngles;



			} else if (Input.GetKeyDown (KeyCode.F)) { // right
				transform.position += new Vector3 (1, 0, 0);

				if (!isValidGridPos ())
					transform.position += new Vector3 (-1, 0, 0);

				x = Mathf.RoundToInt (transform.position.x);
			
			} else if (Input.GetKeyDown (KeyCode.LeftShift)) { // hold 
			
				pos = transform.position;
				Destroy (transform.gameObject);

				if (holdfst) {
					holdfst = false;
					next.holdblk = next.curblk;
					next.curblk = next.nextblk;
					// create the next 
					next.nextblk = FindObjectOfType<next> ().inactive ();
					// destroy inactive item
					call = true;
				} else {
					int tmp = next.holdblk;
					next.holdblk = next.curblk;
					next.curblk = tmp;
					// destroy hold item
					del = true;
				}
		
				FindObjectOfType<next> ().hold (next.holdblk);
				FindObjectOfType<next> ().active (next.curblk);

			} else if (Input.GetKeyDown (KeyCode.LeftControl)) { // fast fall  
				while (true) {
					transform.position += new Vector3 (0, -1, 0);

					if (!isValidGridPos ()) {
						transform.position += new Vector3 (0, 1, 0);
						updateGrid ();
						break;
					}

				}
				y = Mathf.RoundToInt (transform.position.y);
				press = true;

			} 

			if (Input.GetKeyDown (KeyCode.D) || Time.time - lastFall >= 1 || press) {
				if (press)
					press = false;
			
				transform.position += new Vector3 (0, -1, 0);

				if (!isValidGridPos ()) {
					transform.position += new Vector3 (0, 1, 0);
					updateGrid ();

					Grid.deleteFullRows ();

					call = true;


					// activate
					next.curblk = next.nextblk;
					FindObjectOfType<next> ().active (next.curblk);
					// create the next 
					next.nextblk = FindObjectOfType<next> ().inactive ();


					enabled = false;
				}
				y = Mathf.RoundToInt (transform.position.y);

				lastFall = Time.time;
			}
		}
	}


}
    




   
       
