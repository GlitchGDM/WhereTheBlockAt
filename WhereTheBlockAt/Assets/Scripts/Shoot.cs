using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	#region Variables

	public RaycastHit hit;

	public Vector3 hitpoint;

	public GameManager gameMan;

	private float timerJustShot = 0;
	private float timerCanShoot = 0;

	public bool justShot = false;
	private bool canShoot = true;

	private Animator anim;

	#endregion

	#region Unity Methods

	void Start () 
	{
		anim = GetComponentInParent<Animator>();
		timerJustShot = 3;
		timerCanShoot = 0.8f;
	}
	
	void Update () 
	{
		Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity);
		Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.red);
		hitpoint = hit.point;
		if (Input.GetMouseButtonDown(0) && canShoot)
		{
			canShoot = false;
			anim.SetTrigger("shotTrigger");
			justShot = true;
			MusicManager.Instance.PlaySound(AppSounds.Shoot_Sound);
			if(hit.transform.gameObject.tag == "Villager")
			{
				if (hit.transform.gameObject.GetComponentInChildren<VillagerAI>().isTargetToKill)
				{
					Destroy(hit.transform.parent.gameObject);
				}
				else if (!hit.transform.gameObject.GetComponentInChildren<VillagerAI>().isTargetToKill)
				{
					gameMan.lives -= 1;
				}
			}	
		}

		if (justShot)
		{
			timerJustShot -= Time.deltaTime;

			if (timerJustShot <= 0)
			{
				justShot = false;
				timerJustShot = 3;
			}
		}

		if (!canShoot)
		{
			timerCanShoot -= Time.deltaTime;

			if (timerCanShoot <= 0)
			{
				canShoot = true;
				timerCanShoot = 0.8f;
			}
		}
	}

	#endregion
}
