using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	#region Variables

	public int lives = 3;

	#endregion

	#region Unity Methods

	void Start () 
	{
		MusicManager.Instance.PlayBackgroundMusic(AppMusic.Game_Music);
		Cursor.visible = false;
	}
	
	void Update () 
	{
		if (lives <= 0)
		{
			Cursor.visible = true;
			SceneManager.LoadScene(AppScenes.Menu_Scene);
		}
	}

	#endregion
}
