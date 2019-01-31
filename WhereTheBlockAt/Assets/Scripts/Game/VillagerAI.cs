using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VillagerAI : MonoBehaviour {

	#region Variables

	public Transform[] points;
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
		nextPoint = new Vector3(Random.Range(minPosWorld.position.x, maxPosWorld.position.x), 0, Random.Range(minPosWorld.position.z, maxPosWorld.position.z));
		agent.destination = nextPoint;
	}

	private void GotoNextClosePosition()
	{
		nextPoint = new Vector3((Random.insideUnitCircle * 5).x, 0, (Random.insideUnitCircle * 5).y);
		agent.destination = nextPoint;
	}

	void Update () 
	{
		if (!agent.pathPending && agent.remainingDistance < 0.5f)
		{
			GotoNextPosition();
		}

		if (lensShoot.justShot)
		{
			agent.speed = 8f;
		}
		else if (Vector3.Distance(lensShoot.hitpoint, transform.position) < 2 && isTargetToKill)
		{
			agent.speed = 2f;
		}
		else
		{
			agent.speed = 1;
			
		}
	}

	#endregion
}
