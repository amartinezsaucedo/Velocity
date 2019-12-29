using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2.0f;
    public string enemyName;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -screenBounds.y )
        {
            gameObject.SetActive(false);
        }
    }

    void OnEnable()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0,-speed);
    }
}
