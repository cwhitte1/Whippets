
using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour {

	public float walkSpeed = 3f;
	public float jumpPower = 300f;

	public LayerMask groundMask;

	private Rigidbody2D theRigidBody;
	private bool dead = false;
	//private Animator animationController;

	// Use this for initialization
	void Start () {
		theRigidBody = GetComponent<Rigidbody2D>();
		//animationController = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {

		//animationController.SetFloat("speed", Mathf.Abs(theRigidBody.velocity.x));

		if (dead)
		{
			theRigidBody.velocity = new Vector2(0, 0);
			transform.position = new Vector2(0, 4);
			dead = false;
		}
		else
		{
			float inputX = Input.GetAxis("Horizontal");
			theRigidBody.velocity = new Vector2(inputX * walkSpeed, theRigidBody.velocity.y);
            Debug.Log(inputX);
			bool jumping = Input.GetButtonDown("Jump");
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.layer == LayerMask.NameToLayer("Death"))
		{
			dead = true;
		}
	}
}