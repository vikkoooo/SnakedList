using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private Vector2 direction;
	//private List<Transform> segments;
	private LinkedListVikko<Transform> segments2;
	public Transform segmentPrefab;
	public static int score;

	private void Start()
	{
		direction = Vector2.right;
		//segments = new List<Transform>();
		//segments.Add(this.transform);
		segments2 = new LinkedListVikko<Transform>();
		segments2.InsertAtFront(this.transform);


	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.W))
		{
			direction = Vector2.up;
		}
		else if (Input.GetKeyDown(KeyCode.S))
		{
			direction = Vector2.down;
		}
		else if (Input.GetKeyDown(KeyCode.A))
		{
			direction = Vector2.left;
		}
		else if (Input.GetKeyDown(KeyCode.D))
		{
			direction = Vector2.right;
		}
	}

	private void FixedUpdate()
	{
		// for (int i = segments.Count - 1; i > 0; i--)
		// {
		// 	segments[i].position = segments[i - 1].position;
		// }
		// for (int i = segments2.length - 1; i > 0; i--)
		// {
		// 	segments2[i].position = 
		// }
		Debug.Log(segments2.length);
		
		// Set movement, but we also need to round the x and y values to whole numbers to get that grid feeling.
		// Speed is adjusted from project settings under the Time tab, "Fixed timestep"
		this.transform.position = new Vector3(
			Mathf.Round(this.transform.position.x) + direction.x,
			Mathf.Round(this.transform.position.y) + direction.y,
			0);
	}

	private void Grow()
	{
		Transform segment = Instantiate(segmentPrefab);
		//segment.position = segments[segments.Count - 1].position;
		
		//segments.Add(segment);
		segments2.InsertAtFront(segment);
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag.Equals("Food"))
		{
			Grow();
		}

		if (other.tag.Equals("Obstacle"))
		{
			GameOver();
		}
	}


	private void GameOver()
	{
		GetComponent<MenuManager>().Menu();
	}
}