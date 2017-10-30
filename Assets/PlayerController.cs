using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float maxSpeed = 10f;
	public float speed = 2f;
	public bool grounded;

	private Rigidbody2D rb2d;
	private Animator anim;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
	
		float direction = Input.GetAxis("Horizontal");

		rb2d.AddForce(Vector2.right*speed*direction);

		float limitedSpeed = Mathf.Clamp(rb2d.velocity.x,-maxSpeed, maxSpeed);
		rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

		anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
		anim.SetBool("Grounded", grounded);

		//Cambiar posición personaje según si va a izq o dcha
		if (direction > 0.1f) {
			transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
		}

		if (direction < -0.1f) {
			transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
		}
		}	
	}
