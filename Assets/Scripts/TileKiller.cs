using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileKiller : MonoBehaviour
{

	public GameObject deadTilePrefab;
	public static List<Vector3> myList;
	private GameObject spawnArea;
	private Bounds bounds;
	private int tilesToKill = 25;
	
	private void Awake()
	{
		spawnArea = GameObject.Find("SpawnArea");
		myList = new List<Vector3>();
	}

	void Start()
	{
		bounds = spawnArea.GetComponent<BoxCollider2D>().bounds;
	}
	
	private Vector3 GetRandomPosition()
	{
		float x = Random.Range(bounds.min.x, bounds.max.x);
		float y = Random.Range(bounds.min.y, bounds.max.y);

		return new Vector3(Mathf.Round(x), Mathf.Round(y), 0);
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag.Equals("Food"))
		{
			KillTiles(tilesToKill);
		}
	}

	private void KillTiles(int n)
	{
		if (n == 0)
		{
			return;
		}

		Vector3 randPos = GetRandomPosition();
		while (myList.Contains(randPos))
		{
			randPos = GetRandomPosition();
		}
		
		// Create object and store used vector in list
		GameObject killedTile = Instantiate(deadTilePrefab);
		killedTile.transform.position = randPos;
		myList.Add(randPos);

		KillTiles(n - 1);
	}
}
