using UnityEngine;

public class AppleTree : MonoBehaviour {
	[Header("Set in Inspector")]
	public GameObject applePrefab;
	public float speed = 1f;
	public float leftAndRightEdge = 10f;
	public float chanceToChangeDirections = 0.1f;
	public float secondsBetweenAppleDrops = 1f;

	// Start is called before the first frame update
	void Start() {
		InvokeRepeating(nameof(SpawnApple), secondsBetweenAppleDrops, secondsBetweenAppleDrops);
	}

	// Update is called once per frame
	void Update() {
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;
	}

	private void SpawnApple() {
		Instantiate(applePrefab, transform.position, transform.rotation);
	}
}
