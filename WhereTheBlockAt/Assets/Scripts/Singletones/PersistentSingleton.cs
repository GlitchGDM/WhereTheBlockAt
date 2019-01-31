using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentSingleton<T> : MonoBehaviour where T: Component {

	#region Variables

	private static T instance;

	#endregion

	#region Unity Methods

	public static T Instance
	{
		get
		{
			if (instance == null)
			{
				instance = FindObjectOfType<T>();
				if (instance == null)
				{

					GameObject obj = new GameObject();
					instance = obj.AddComponent<T>();

				}
			}
			return instance;
		}
	}

	public virtual void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
		if (instance == null)
		{
			instance = this as T;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	#endregion
}
