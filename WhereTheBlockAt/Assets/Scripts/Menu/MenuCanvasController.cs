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

	public Dropdown resolutionDropdown;
	private Resolution[] resolutions;

	#endregion

	#region Unity Methods

	public void Start()
	{
		MusicManager.Instance.PlayBackgroundMusic(AppMusic.MainMenu_Music);

		resolutions = Screen.resolutions;
		resolutionDropdown.ClearOptions();

		List<string> options = new List<string>();

		int currentResolutionIndex = 0;

		for(int i = 0; i < resolutions.Length; i++)
		{
			string option = resolutions[i].width + " x " + resolutions[i].height;
			options.Add(option);

			if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
			{
				currentResolutionIndex = i;
			}

		}

		resolutionDropdown.AddOptions(options);
		resolutionDropdown.value = currentResolutionIndex;
		resolutionDropdown.RefreshShownValue();
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

	public void SetQuality(int qualityIndex)
	{
		QualitySettings.SetQualityLevel(qualityIndex);
	}

	public void SetFullscreen(bool isFullScreen)
	{
		Screen.fullScreen = isFullScreen;
	}

	public void SetResolution(int resolutionIndex)
	{
		Resolution resolution = resolutions[resolutionIndex];
		Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
	}

	#endregion
}
