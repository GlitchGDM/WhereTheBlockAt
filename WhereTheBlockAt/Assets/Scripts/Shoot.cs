using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	#region Variables

	public RaycastHit hit;

	public Vector3 hitpoint;

	#endregion

	#region Unity Methods

	void Start () 
	{
		
	}
	
	void Update () 
	{
		Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity);
		Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.red);
		hitpoint = hit.point;
		if (Input.GetMouseButtonDown(0) && hit.transform.gameObject.tag == "Villager")
		{
			if (hit.transform.gameObject.GetComponentInChildren<VillagerAI>().isTargetToKill)
			{
				Destroy(hit.transform.parent.gameObject);
			}
		}
	}

	#endregion
}
