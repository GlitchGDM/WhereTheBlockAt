using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	#region Variables

	public Sprite[] LifesSprites;

	public Image LifesUI;

	public GameManager gm;

	#endregion

	#region Unity Methods

	void Start () 
	{

	}
	
	void Update () 
	{
		LifesUI.sprite = LifesSprites[gm.lives];
	}

	#endregion
}
