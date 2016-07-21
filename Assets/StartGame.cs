using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {
	public static int player = 0;

	public void LoadGame() {
		SceneManager.LoadScene ("Tetris");
	}
}
