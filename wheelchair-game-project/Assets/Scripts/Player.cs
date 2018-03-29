using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	
	public float vel;
	public float stamina;
	public Rigidbody2D rb;
	public SpriteRenderer sprite;
	
	public Scrollbar barraStamina;
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		sprite = GetComponent<SpriteRenderer>();
		vel = 4;
		stamina = 100;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(stamina > 0){
			Vector2 temp = rb.velocity;
			temp.x = vel * Input.GetAxis("Horizontal");
			rb.velocity = temp;	
		}
		
		
		if(Input.GetButtonDown("Horizontal") && stamina > 0){
			stamina -= 1f;
		}
		else{
			if(stamina < 100){
				stamina += 0.05f;
			}
		}
		
		//barraStamina.value = stamina;
		barraStamina.size = stamina/100;
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
