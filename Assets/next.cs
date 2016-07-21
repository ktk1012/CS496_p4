using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;

public class next : NetworkBehaviour
{
	
    public GameObject[] act;
    public GameObject[] inact;
    public GameObject[] hd;
    public static int nextblk;
    public static int curblk;
    public static int holdblk;


    // Use this for initialization
    public void active(int i)
    {
		var obj = (GameObject) Instantiate(act[i], transform.position, Quaternion.identity);
		NetworkServer.Spawn (obj);
    }

    public void hold(int i)
    {
		var obj = (GameObject) Instantiate(hd[i], transform.position, Quaternion.identity);
		NetworkServer.Spawn (obj);
    }

    public int inactive()
    {
        int i = Random.Range(0, inact.Length);
		var obj = (GameObject) Instantiate(inact[i], transform.position, Quaternion.identity);
		NetworkServer.Spawn (obj);
        return i;
    }

	public override void OnStartClient() {
		foreach (GameObject obj in act) {
			ClientScene.RegisterPrefab (obj);
		}
		foreach (GameObject obj in inact) {
			ClientScene.RegisterPrefab (obj);
		}
		foreach (GameObject obj in hd) {
			ClientScene.RegisterPrefab (obj);
		}

		Debug.Log ("CONNN");
	}

    void Start()
	{
		if (isServer) {
			int i = inactive ();
			int j = inactive ();
			nextblk = j; 
			active (i);
			curblk = i;
		}
	}
}