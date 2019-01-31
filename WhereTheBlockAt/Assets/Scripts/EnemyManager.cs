using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : TemporalSingleton<EnemyManager> {

	#region Variables

	public GameObject enemy;

	public int numberEnems = 15;

	private List<GameObject> enemyVector = new List<GameObject>();

	#endregion

	#region Unity Methods

	private void Start()
	{
		CreateEnemies(numberEnems);
	}

	public void CreateEnemies(int numberOfEnemies)
	{

		for(int i = 0; i < numberOfEnemies; i++)
		{
			GameObject enemyAux = Instantiate(enemy, Vector3.zero, Quaternion.identity);
			enemyAux.SetActive(false);
			enemyVector.Add(enemyAux);
			SpawnEnemy();
		}
		SetVillains();
	}

	void SpawnEnemy()
	{
		for (int i = 0; i < enemyVector.Count; i++)
		{
			if (!enemyVector[i].activeSelf)
			{
				enemyVector[i].transform.position = new Vector3(Random.Range(enemyVector[i].GetComponentInChildren<VillagerAI>().minPosWorld.position.x, enemyVector[i].GetComponentInChildren<VillagerAI>().maxPosWorld.position.x),0, Random.Range(enemyVector[i].GetComponentInChildren<VillagerAI>().minPosWorld.position.z, enemyVector[i].GetComponentInChildren<VillagerAI>().maxPosWorld.position.z));
				enemyVector[i].SetActive(true);
				break;
			}
		}
	}

	void SetVillains()
	{
		for (int i = 0; i < 5; i++)
		{
			enemyVector[i].GetComponentInChildren<VillagerAI>().isTargetToKill = true;
		}
	}

	#endregion
}
