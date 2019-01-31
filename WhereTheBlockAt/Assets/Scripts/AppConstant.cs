using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppScenes {

	public static readonly string Menu_Scene = "Menu";
	public static readonly string Loading_Scene = "Loading";
	public static readonly string Game_Scene = "Game";

}

public class AppPlayerPrefsValues
{
	public static readonly string Music_Volume = "MusicVolume";
	public static readonly string Sfx_Volume = "SfxVolume";
}

public class AppPaths
{
	public static readonly string Persistant_Data = Application.persistentDataPath;
	public static readonly string Path_Sounds_Menu = "Audio/Menu/Sounds/";
	public static readonly string Path_Music_Menu = "Audio/Menu/Music/";
}

public class AppMusic
{
	public static readonly string MainMenu_Music = "MainMenuSong";
}

public class AppSounds
{
	public static readonly string Button_Sound = "ButtonSound";
}
