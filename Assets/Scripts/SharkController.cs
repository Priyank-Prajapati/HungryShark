using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SharkController : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;

    public float speed;
    public float minX, maxX, minY, maxY;

    private Rigidbody2D rbody;

    public GameObject[] heart = new GameObject[3];
    private int heartCount = 0;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        
    }
    void FixedUpdate()
    {
        float horizon = Input.GetAxis("Horizontal");
        float verti = Input.GetAxis("Vertical");

        rbody.velocity = new Vector2(horizon, verti) * speed;

        rbody.position = new Vector2(
            Mathf.Clamp(rbody.position.x, minX, maxX),
            Mathf.Clamp(rbody.position.y, minY, maxY));
    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            score += 10;
            scoreText.text = "SCORE : " + score;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(heart[heartCount]);
            heartCount++;

            if(heartCount >= 3)
            {
                Destroy(this.gameObject);
                SceneManager.LoadScene(1);
            }
        }
    }
}
