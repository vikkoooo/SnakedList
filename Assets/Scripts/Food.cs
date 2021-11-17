using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Food : MonoBehaviour
{
	private GameObject spawnArea;
	private Bounds bounds;
	public GameObject foodPrefab;
	private List<Vector3> deadTiles;
	
	private void Awake()
	{
		spawnArea = GameObject.Find("SpawnArea");
		
		if (TileKiller.myList != null)
		{
			deadTiles = TileKiller.myList;
		}
	}

	void Start()
	{
		bounds = spawnArea.GetComponent<BoxCollider2D>().bounds;
		Vector3 newPosition = GetRandomPosition();
		
		// If space is occupied by dead tile, randomize new positions until a free one found
		while (deadTiles.Contains(newPosition))
		{
			newPosition = GetRandomPosition();
		}
		this.transform.position = newPosition;
	}
	
	private Vector3 GetRandomPosition()
	{
		float x = Random.Range(bounds.min.x, bounds.max.x);
		float y = Random.Range(bounds.min.y, bounds.max.y);

		return new Vector3(Mathf.Round(x), Mathf.Round(y), 0);
	}
	
    private void OnTriggerEnter2D(Collider2D other)
    {
	    if (other.tag.Equals("Player"))
	    {
		    Player.score++;
		    Instantiate(foodPrefab);
		    Destroy(gameObject);
	    }
    }
}
