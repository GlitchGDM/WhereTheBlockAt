using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VillagerAI : MonoBehaviour {

	#region Variables

	public Transform[] points;
	private int destPoint = 0;
	private NavMeshAgent agent;

	[SerializeField]
	public bool isTargetToKill;

	public GameObject lens;
	private Shoot lensShoot;
	private Vector3 nextPoint;

	public Transform minPosWorld;
	public Transform maxPosWorld;

	#endregion

	#region Unity Methods

	void Start () 
	{
		lensShoot = lens.GetComponent<Shoot>();
		agent = GetComponent<NavMeshAgent>();
		agent.autoBraking = false;
		GotoNextPosition();
	}

	private void GotoNextPosition()
	{
		if(nextPoint == null)
		{
			return;
		}
		nextPoint = new Vector3(Random.Range(minPosWorld.position.x, maxPosWorld.position.x), 0, Random.Range(minPosWorld.position.z, maxPosWorld.position.z));
		agent.destination = nextPoint;
	}

	void Update () 
	{
		if (!agent.pathPending && agent.remainingDistance < 0.5f)
		{
			GotoNextPosition();
		}

		Debug.Log(Vector3.Distance(lensShoot.hit.point, transform.position));

		if (Vector3.Distance(lensShoot.hit.point, transform.position) < 100)
		{
			agent.speed = 0;
		}
		else
		{
			agent.speed = 0;
		}
	}

	#endregion
}
