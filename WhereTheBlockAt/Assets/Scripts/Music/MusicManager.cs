using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : PersistentSingleton<MusicManager> {

	#region Variables

	private float musicVol = 0.5f;

	private float sfxVol = 0.5f;

	private Dictionary<string, AudioClip> soundsDictionary = null;
	private Dictionary<string, AudioClip> musicDictionary = null;

	private AudioSource backgroundMusic;
	private AudioSource soundsFx;

	#endregion


	#region Get & Set Volume
	public float MusicVolume
	{
		get
		{
			return musicVol;
		}

		set
		{
			value = Mathf.Clamp(value, 0, 1);
			backgroundMusic.volume = musicVol;
			musicVol = value;
		}
	}

	public float MusicVolumeSave
	{
		get
		{
			return musicVol;
		}

		set
		{
			value = Mathf.Clamp(value, 0, 1);
			backgroundMusic.volume = musicVol;
			musicVol = value;
		}
	}

	public float SfxVolume
	{
		get
		{
			return sfxVol;
		}

		set
		{
			value = Mathf.Clamp(value, 0, 1);
			soundsFx.volume = sfxVol;
			sfxVol = value;
		}
	}

	public float SoundVolumeSave
	{
		get
		{
			return sfxVol;
		}

		set
		{
			value = Mathf.Clamp(value, 0, 1);
			soundsFx.volume = sfxVol;
			sfxVol = value;
		}
	}

	#endregion


	#region Unity Methods

	public void PlayBackgroundMusic(string songName)
	{
		if (musicDictionary.ContainsKey(songName))
		{
			backgroundMusic.clip = musicDictionary[songName];
			backgroundMusic.volume = musicVol;
			backgroundMusic.Play();
		}
	}

	public void PlaySound(string audioName)
	{
		if (soundsDictionary.ContainsKey(audioName))
		{
			soundsFx.clip = soundsDictionary[audioName];
			soundsFx.volume = sfxVol;
			soundsFx.Play();
		}
	}

	public void StopBackgroundMusic()
	{
		if (backgroundMusic != null)
		{
			backgroundMusic.Stop();
		}
	}

	public void PauseBackgroundMusic()
	{
		if (backgroundMusic != null)
		{
			backgroundMusic.Pause();
		}
	}

	public AudioSource CreateAudioSource(string name, bool isLoop)
	{
		GameObject temporaryAudioHost = new GameObject(name);
		AudioSource audioSource = temporaryAudioHost.AddComponent<AudioSource>() as AudioSource;
		audioSource.playOnAwake = false;
		audioSource.loop = isLoop;
		audioSource.spatialBlend = 0.0f;
		temporaryAudioHost.transform.SetParent(this.transform);
		return audioSource;
	}

	public override void Awake()
	{
		base.Awake();
		Debug.Log("Hola");
		backgroundMusic = CreateAudioSource("MusicSource", true);
		soundsFx = CreateAudioSource("AudioSource", false);

		soundsDictionary = new Dictionary<string, AudioClip>();
		musicDictionary = new Dictionary<string, AudioClip>();

		MusicVolume = PlayerPrefs.GetFloat(AppPlayerPrefsValues.Music_Volume,0.5f);
		SfxVolume = PlayerPrefs.GetFloat(AppPlayerPrefsValues.Sfx_Volume, 0.5f);

		AudioClip[] musicSoundVector = Resources.LoadAll<AudioClip>(AppPaths.Path_Sounds);

		for (int i = 0; i < musicSoundVector.Length; i++)
		{
			soundsDictionary.Add(musicSoundVector[i].name, musicSoundVector[i]);
		}

		musicSoundVector = Resources.LoadAll<AudioClip>(AppPaths.Path_Music);

		for (int i = 0; i < musicSoundVector.Length; i++)
		{
			musicDictionary.Add(musicSoundVector[i].name, musicSoundVector[i]);
		}

	}
	#endregion

}
