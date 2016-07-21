using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Server : NetworkManager {
	
	public static bool topselect = false;
	public static bool bottomselect = false;
	public override void OnClientConnect(NetworkConnection conn) {
		Debug.Log ("Connect!!");
		ClientScene.AddPlayer (conn, 0, null);
	}

	void OnGUI() {
		topselect = GUI.Toggle(new Rect(20, 20, 50, 20), topselect, "Top");
		bottomselect = GUI.Toggle(new Rect(90, 20, 130, 20), bottomselect, "Bottom");
	
	}


}
