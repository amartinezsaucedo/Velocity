using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour {
	public GameObject torpedoPrefab;
	private float xDirection;
	private float speed = 20.0f;
	private AudioSource explosionSound;

	void Start ()
	{
		Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 5));
		transform.position = worldPoint;
		explosionSound = GetComponent<AudioSource>();
	}
	
	void Update () 
	{
		xDirection = Input.acceleration.x * speed;
		Vector3 minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
    Vector3 maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, minScreenBounds.x + 1, maxScreenBounds.x - 1),Mathf.Clamp(transform.position.y, minScreenBounds.y + 1, maxScreenBounds.y - 1), transform.position.z);
		Shoot();
	}

	void FixedUpdate() 
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2 (xDirection, 0f);
	}

	void Shoot()
	{
			if(Input.GetButtonDown("Fire1"))
			{
				explosionSound.Play();
				GameObject gameObject = ObjectPooler.SharedInstance.GetPooledObject("bullet"); 
				if (gameObject != null) 
				{
					gameObject.transform.position = transform.position;
					gameObject.SetActive(true);
					gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,1) * speed;						
				}
			}
	}

}