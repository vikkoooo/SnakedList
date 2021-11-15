using UnityEngine;

public class Player : MonoBehaviour
{
	private Vector2 direction;
	private SnakedList<Transform> segments;
	public Transform segmentPrefab;
	public static int score;
	
	private void Start()
	{
		direction = Vector2.right;
		segments = new SnakedList<Transform>();
		segments.InsertAtEnd(this.transform);
		
		// Two options to set speed, either from this variable
		// Or project settings > Time > Fixed Timestep = 0.3 is good if not using this variable below
		//Time.fixedDeltaTime = 0.3f;
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
		Vector2 lastPos = transform.position;
		
		foreach(Node<Transform> entry in segments)
		{
			Vector2 tempPos = lastPos;
			lastPos = entry.Data.position;
			entry.Data.position = tempPos;
		}
		
		this.transform.position = new Vector3(
			Mathf.Round(this.transform.position.x) + direction.x,
			Mathf.Round(this.transform.position.y) + direction.y,
			0);
	}
	
	private void Grow()
	{
		Transform segment = Instantiate(segmentPrefab);
		segment.position = segments.GetLastElement().Data.position;
		segments.InsertAtEnd(segment);
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