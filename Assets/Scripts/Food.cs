using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Food : MonoBehaviour
{
	public BoxCollider2D area;
	private Bounds bounds;
	private GameObject spawnArea;
	public GameObject foodPrefab;

	
	private void Awake()
	{
		spawnArea = GameObject.Find("GridArea");
	}

	void Start()
	{
		area = spawnArea.GetComponent<BoxCollider2D>();
		bounds = area.bounds;
		RandomizePosition();
	}
	
	private void RandomizePosition()
	{
		float x = Random.Range(bounds.min.x, bounds.max.x);
		float y = Random.Range(bounds.min.y, bounds.max.y);

		this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0);
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
