using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private Vector2 direction;
	private List<Transform> segments;
	public Transform segmentPrefab;

	private void Start()
	{
		direction = Vector2.right;
		segments = new List<Transform>();
		segments.Add(this.transform);
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
		for (int i = segments.Count - 1; i > 0; i--)
		{
			segments[i].position = segments[i - 1].position;
		}
		
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
		segment.position = segments[segments.Count - 1].position;
		
		segments.Add(segment);
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("trigger collision");
		if (other.tag.Equals("Food"))
		{
			Grow();
		}
	}
}