using UnityEngine;

public class Player : MonoBehaviour
{
	// Snake tail
	private SnakedList<Transform> segments;
	public Transform segmentPrefab;
	
	// Score
	public static int score;
	
	// Sprite head
	private SpriteRenderer sprite;

	// Movement
	private Vector2Int gridPos;
	private Vector2Int gridDir;
	
	private void Start()
	{
		segments = new SnakedList<Transform>();
		segments.InsertAtEnd(this.transform);
		
		sprite = GetComponent<SpriteRenderer>();

		// Two options to set speed, either from this variable
		// Or project settings > Time > Fixed Timestep = 0.3 is good if not using this variable below
		//Time.fixedDeltaTime = 0.3f;
		gridPos = new Vector2Int(0, 0);
		gridDir = Vector2Int.right;
	}

	private void Update()
	{
		// Sets movement direction
		if (Input.GetKeyDown(KeyCode.W))
		{
			gridDir = Vector2Int.up;
		}
		else if (Input.GetKeyDown(KeyCode.S))
		{
			gridDir = Vector2Int.down;
		}
		else if (Input.GetKeyDown(KeyCode.A))
		{
			gridDir = Vector2Int.left;
			sprite.flipX = true;
		}
		else if (Input.GetKeyDown(KeyCode.D))
		{
			gridDir = Vector2Int.right;
			sprite.flipX = false;
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

		// Moves the snake
		gridPos += gridDir;
		transform.position = new Vector3(gridPos.x, gridPos.y);
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