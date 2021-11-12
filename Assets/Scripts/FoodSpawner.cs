using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
	public GameObject foodPrefab;
	private GameObject food;
	
	void Start()
	{
		Instantiate(foodPrefab);
	}
	
	
	
}
