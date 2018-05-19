using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Movement : MonoBehaviour 
{
	//used as reference
	private Rigidbody2D rb2d;

	public Vector2 jumpHeight;
	public float speed;

	public Text clock;

	public Text highscore;

	public int score = 0;
	private int getCoin = 0;

	public float timer = 999f;
	bool finished = false;

	bool Grounded = false;

	public Transform botGroundCheck;

	float groundRadius = 1.0f;
	public LayerMask whatIsGround;

	public Image coin1;
	public Image coin2;
	public Image coin3;
	public Image coin4;
	public Image coin5;

	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
		coin1.enabled = false;
		coin2.enabled = false;
		coin3.enabled = false;
		coin4.enabled = false;
		coin5.enabled = false;
		setTimer ();
	}

	// Update is called once per frame
	void FixedUpdate ()
	{

		Grounded = Physics2D.OverlapCircle (botGroundCheck.position, groundRadius, whatIsGround);


		//moves the player according to the inputs given by the player
		float moveHorizontal = Input.GetAxis ("Horizontal");
		rb2d.velocity = new Vector2 (moveHorizontal * speed,rb2d.velocity.y);

	}

	void Update()
	{
		if (!finished) 
		{
			timer -= Time.deltaTime;
			setTimer ();
		}

		if (Input.GetButtonDown ("Jump") && (Grounded)) 
		{
			if (Grounded) 
			{
				rb2d.AddForce(jumpHeight,ForceMode2D.Impulse);
			}
		}

	}
		
	void setTimer()
	{
		clock.text = "Time: " + timer.ToString ("F0");
	}
		
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Coin1") || other.gameObject.CompareTag ("Coin2") || other.gameObject.CompareTag ("Coin3")
		    || other.gameObject.CompareTag ("Coin4") || other.gameObject.CompareTag ("Coin5")) {
			other.gameObject.SetActive (false);
			if (other.tag.Contains ("Coin1")) {
				coin1.enabled = true;
				getCoin++;
			} else if (other.tag.Contains ("Coin2")) {
				coin2.enabled = true;
				getCoin++;
			} else if (other.tag.Contains ("Coin3")) {
				coin3.enabled = true;
				getCoin++;
			} else if (other.tag.Contains ("Coin4")) {
				coin4.enabled = true;
				getCoin++;
			} else if (other.tag.Contains ("Coin5")) {
				coin5.enabled = true;
				getCoin++;
			}
			
		} else if (other.gameObject.CompareTag ("FinishLine")) {
			score += (int)timer * 5;
			score += getCoin * 50;
			if (!finished) 
			{
				highscore.text = "Score: " + score.ToString ();
			}
			finished = true;
			setTimer ();
		}
	}



}