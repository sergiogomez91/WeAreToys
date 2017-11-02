using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float maxSpeed = 10f;
	public float speed = 2f;
	public bool grounded;
	public float jumpPower = 6.5f;

	private Rigidbody2D rb2d;
	private Animator anim;
	private bool jump;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
		anim.SetBool("Grounded", grounded);

		if (Input.GetKeyDown(KeyCode.UpArrow) && grounded) {
			jump = true;
		}
		
	}

	void FixedUpdate(){

		//fixedVelocity es para arreglar el problema de que con el deslizante el personaje nunca se esté quieto
		Vector3 fixedVelocity = rb2d.velocity;
		fixedVelocity.x *= 0.75f;
		if (grounded) {
			rb2d.velocity = fixedVelocity;
		}

		//Añadimos fuerza y velocidad a nuestro personaje para que se mueva izqd y dcha	
		float direction = Input.GetAxis("Horizontal");

		rb2d.AddForce(Vector2.right*speed*direction);

		float limitedSpeed = Mathf.Clamp(rb2d.velocity.x,-maxSpeed, maxSpeed);
		rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);


		//Cambiar posición personaje según si va a izq o dcha
		if (direction > 0.1f) {
			transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
		}

		if (direction < -0.1f) {
			transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
		}

		if (jump) {
			rb2d.velocity = new Vector2 (rb2d.velocity.x, 0);
			rb2d.AddForce (Vector2.up * jumpPower, ForceMode2D.Impulse);
			jump = false;
		}
	}	
	//Reaparición del personaje cuando desaparece de la escena
	void OnBecameInvisible(){
		transform.position = new Vector3 (-5, -1, 0); 	
		}
}
