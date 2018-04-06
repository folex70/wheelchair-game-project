using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	
	public float vel;
	public float tempo;
	public Vector2 forca;
	public float stamina;
	public Rigidbody2D rb;
	public SpriteRenderer sprite;
	private Vector2 touchPos;
	public Scrollbar barraStamina;
	
	
	AudioSource audio;
	public AudioClip  floorSound;
	public AudioClip  obstacleSound;
	
	// Use this for initialization
	void Start () {		
		rb = GetComponent<Rigidbody2D>();
		sprite = GetComponent<SpriteRenderer>();
		vel = 150;
		stamina = 100;	
		audio = GetComponent<AudioSource>();		
	}
	
	// Update is called once per frame
	//@TODO exibir tempo na tela
	void Update () {
		
		tempo += Time.deltaTime;

		#if UNITY_ANDROID 
			inputMobile();
		#endif
			inputPC();
	}
	
	void inputPC(){
		if(Input.GetButtonDown("Horizontal") && stamina > 0){
			
			stamina -= 2f;
			forca = new Vector2(vel * (Input.GetAxis("Horizontal")>0?1:-1), 0);
			
			if(rb.velocity.x < 5 && rb.velocity.x > -5 ){
				rb.AddForce(forca);
			}	

		}
		else{
			if(stamina < 100){
				stamina += 0.03f;
			}
		}
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
	
	void inputMobile(){
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		{		
			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			touchPos = new Vector2(wp.x, wp.y);
			
			if(touchPos.x > transform.position.x)
			{
				stamina -= 2f;
				forca = new Vector2(vel * (1), 0);
				if(rb.velocity.x < 5 && rb.velocity.x > -5 ){
					rb.AddForce(forca);
				}	
			}
			else
			{
				stamina -= 2f;
				forca = new Vector2(vel * (-1), 0);
				if(rb.velocity.x < 5 && rb.velocity.x > -5 ){
					rb.AddForce(forca);
				}	
			}
		}
		else{
			if(stamina < 100){
				stamina += 0.03f;
			}
		}
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
	
	void OnCollisionEnter2D (Collision2D col){
		Debug.Log(col.gameObject.tag);
		switch(col.gameObject.tag){
			
			case "Goal":
				Goal();
			break;
			
			case "Obstacle":
				vel = 40;				
				audio.PlayOneShot(obstacleSound, 0.7F);
			break;
			
			case "Floor":
				vel = 150;
				audio.PlayOneShot(floorSound, 0.7F);
			break;
			
			default:
				
			break;			
			
		} 
    }
	
	void Goal(){
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);  
	}
	
}
