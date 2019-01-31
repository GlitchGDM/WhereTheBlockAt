using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour {

	#region Variables
	#endregion

	#region Unity Methods

	private void OnEnable()
	{
		SceneManager.LoadSceneAsync(AppScenes.Game_Scene, LoadSceneMode.Additive);
		SceneManager.sceneLoaded += FinishLoading;
	}

	void FinishLoading(Scene scene, LoadSceneMode mode)
	{
		SceneManager.sceneLoaded -= FinishLoading;
		Destroy(this.gameObject);
	}

	#endregion
}
