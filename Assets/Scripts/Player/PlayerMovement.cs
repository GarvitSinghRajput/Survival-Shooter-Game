using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
 
	public float speed = 6f;

	public static Vector3 playerPosition = Vector3.zero; // Added for saving/loading position

	Vector3 movement;
	Animator animator;
	Rigidbody playerRigidbody;
	int floorMask;
	float camRayLength = 100f;

	void Awake()
	{
		floorMask = LayerMask.GetMask ("Floor");
		animator = GetComponent<Animator> ();
		playerRigidbody = GetComponent<Rigidbody> ();
	}

	private void Start() {
		// Load player position if it exists
		if (playerPosition != Vector3.zero) {
			transform.position = playerPosition;
		}
	}

	public void ResetPosition()
	{
		transform.position = Vector3.zero;
		playerPosition = Vector3.zero;
	}

	void FixedUpdate()
	{
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		Move(h, v);
		Turning();
		Animating(h, v);
	}

	void Move(float h, float v)
	{
		movement.Set (h, 0, v);
		movement = movement.normalized * speed * Time.deltaTime;

		playerRigidbody.MovePosition (transform.position + movement);
		playerPosition = transform.position; // Update player position for saving
	}

	void Turning()
	{
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit floorHit;
		if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) 
		{
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0;

			var rotation = Quaternion.LookRotation(playerToMouse);
			playerRigidbody.MoveRotation(rotation);
		}
	}

	void Animating(float h, float v)
	{
		bool walking = h != 0f || v != 0f;
		animator.SetBool("IsWalking", walking);
	}

}