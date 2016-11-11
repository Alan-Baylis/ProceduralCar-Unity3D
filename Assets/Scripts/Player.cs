using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	const float SPEED = 1.5f;
	Vector3 JUMP_FORCE = new Vector3(0, 5, 0);
	
	Rigidbody rigidbody;

	float speedX = 0;
	float speedZ = 0;

	void Start()
	{
		rigidbody = GetComponent<Rigidbody>();
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.A)) speedX = -SPEED;
		if (Input.GetKey(KeyCode.D)) speedX = SPEED;
		if (Input.GetKey(KeyCode.W)) speedZ = SPEED;
		if (Input.GetKey(KeyCode.S)) speedZ = -SPEED;

		if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) speedX *= 0.9f;
		if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) speedZ *= 0.9f;

		if (Input.GetKeyDown(KeyCode.Space)) rigidbody.AddForce(JUMP_FORCE, ForceMode.Impulse);


		transform.position += new Vector3(speedX * Time.deltaTime, 0, speedZ * Time.deltaTime);
	}
}
