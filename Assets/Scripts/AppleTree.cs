using UnityEngine;

public class AppleTree : MonoBehaviour {
	[Header("Set in Inspector")]
	public GameObject applePrefab;
	public float speed = 1f;
	public float leftAndRightEdge = 2f;
	public float upAndDownEdge = 1f;
	public float secondsToChangeDirections = 2f;
	public float secondsBetweenAppleDrops = 1f;
	public float treeHeightOffsetForApple = 3F;
	private Vector3 direction;

	// Start is called before the first frame update
	void Start() {
		SetNewRandonDirection();

		InvokeRepeating(nameof(CreateApple), secondsBetweenAppleDrops, secondsBetweenAppleDrops);
		InvokeRepeating(nameof(SetNewRandonDirection), secondsToChangeDirections, secondsToChangeDirections);
	}

	// Update is called once per frame
	void Update() {
		Vector3 pos = transform.position;
		pos += direction * Time.deltaTime;
		transform.position = pos;
	}

	private void CreateApple() {
		var position = transform.position;

		position.y += treeHeightOffsetForApple + Random.Range(-upAndDownEdge, upAndDownEdge);
		position.x += Random.Range(-leftAndRightEdge, leftAndRightEdge);
		position.z += Random.Range(-leftAndRightEdge, leftAndRightEdge);

		Instantiate(applePrefab, position, transform.rotation);
	}

	Vector3 GetRandomHorizontalDirection() {
		float x = Random.Range(-1f, 1f);
		float z = Random.Range(-1f, 1f);

		Vector3 direction = new Vector3(x, 0f, z);

		direction.Normalize();

		return direction;
	}

	private void SetNewRandonDirection() {
		direction = GetRandomHorizontalDirection();
	}
}
