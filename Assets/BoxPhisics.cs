﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPhisics : MonoBehaviour {

	public float maxSpeed = 10f;
	public float speed = 2f;

	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate(){

		//fixedVelocity es para arreglar el problema de que con el deslizante el personaje nunca se esté quieto
		Vector3 fixedVelocity = rb2d.velocity;
		fixedVelocity.x *= 0.75f;
		rb2d.velocity = fixedVelocity;

		float limitedSpeed = Mathf.Clamp(rb2d.velocity.x,-maxSpeed, maxSpeed);
		rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

	}
}
