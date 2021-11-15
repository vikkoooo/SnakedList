using UnityEngine;

public class FoodInitializer : MonoBehaviour
{
	public GameObject foodPrefab;
	
	void Start()
	{
		Instantiate(foodPrefab);
	}
}
