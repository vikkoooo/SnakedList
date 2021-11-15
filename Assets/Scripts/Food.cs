using UnityEngine;
using Random = UnityEngine.Random;

public class Food : MonoBehaviour
{
	private GameObject spawnArea;
	private Bounds bounds;
	public GameObject foodPrefab;
	
	private void Awake()
	{
		spawnArea = GameObject.Find("SpawnArea");
	}

	void Start()
	{
		bounds = spawnArea.GetComponent<BoxCollider2D>().bounds;
		this.transform.position = GetRandomPosition();
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
