using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	#region Variables
	
	public float speed = 0.2f;

	public bool isMoving = false;

	#endregion

	#region Unity Methods

	void Start()
	{

	}

	void Update () 
	{
		transform.Translate(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed);
		Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
		pos.x = Mathf.Clamp(pos.x, 0.055f, 0.945f);
		pos.y = Mathf.Clamp01(pos.y);
		transform.position = Camera.main.ViewportToWorldPoint(pos);
	}

	#endregion
}
