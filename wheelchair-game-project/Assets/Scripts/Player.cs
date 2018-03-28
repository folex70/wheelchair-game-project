using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	
	public float vel;
	public Rigidbody2D rb;
	public SpriteRenderer sprite;
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		sprite = GetComponent<SpriteRenderer>();
		vel = 4;
	}
	
	// Update is called once per frame
	void Update () {
	
		Vector2 temp = rb.velocity;
		temp.x = vel * Input.GetAxis("Horizontal");
		rb.velocity = temp;

		//virar 
		if(Input.GetAxis("Horizontal") != 0){
			
			if(Input.GetAxis("Horizontal") > 0){
				sprite.flipX = false;
			}
			else{

				sprite.flipX = true;
			}
		}
	}
	
}
