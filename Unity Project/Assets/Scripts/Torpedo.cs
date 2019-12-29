using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torpedo : MonoBehaviour
{
    public float speed = 20.0f;
    private Vector2 screenBounds;
    public ParticleSystem explosion;
    public AudioSource explosionSound;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        explosionSound = GetComponent<AudioSource>();
        Debug.Log(explosionSound);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y> screenBounds.y )
        {
            gameObject.SetActive(false);
        } 
    }   

    void OnEnable()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0,1) * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "enemy")
        {
            GameController.SharedInstance.IncrementScore(1);
            explosionSound.Play();
            Instantiate(explosion,transform.position,Quaternion.identity);
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
