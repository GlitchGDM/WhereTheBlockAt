using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuCanvasController : MonoBehaviour {

	#region Variables

	public GameObject mainMenu;
	public GameObject optionsMenu;

	public Slider musicSlider;
	public Slider soundSlider;

	#endregion

	#region Unity Methods

	public void Start()
	{
		MusicManager.Instance.PlayBackgroundMusic(AppMusic.MainMenu_Music);
	}

	public void Play()
	{
		SceneManager.LoadScene(AppScenes.Loading_Scene);
		MusicManager.Instance.PlaySound(AppSounds.Button_Sound);
	}

	public void Options(bool isOptionsOn)
	{
		mainMenu.SetActive(!isOptionsOn);
		optionsMenu.SetActive(isOptionsOn);

		if (!isOptionsOn)
		{
			MusicManager.Instance.MusicVolumeSave = musicSlider.value;
			MusicManager.Instance.SoundVolumeSave = soundSlider.value;
		}

		MusicManager.Instance.PlaySound(AppSounds.Button_Sound);

	}

	public void Exit()
	{
		Application.Quit();
	}

	public void OnMusicValueChanged()
	{
		MusicManager.Instance.MusicVolume = musicSlider.value;
	}

	public void OnSoundValueChanged()
	{
		MusicManager.Instance.SfxVolume = soundSlider.value;
	}

	#endregion
}
