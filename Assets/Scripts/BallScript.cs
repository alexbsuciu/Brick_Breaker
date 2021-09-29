using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool inPlay;
    public Transform paddle;
    public float speed;
    public Transform Explosion;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.gameOver)
        {
            return;
        }
        //Muta mingea langa paleta
        if(!inPlay)
        {
            transform.position = paddle.position;
        }
        //Release ball
        if(Input.GetButtonDown("Jump")&& !inPlay)
        {
            inPlay = true;
            rb.AddForce(Vector2.up * speed);
        }
    }

    //Collision cu partea de jos
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Bottom"))
        {
            rb.velocity = Vector2.zero;
            inPlay = false;
            gm.UpdateLives(-1);
        }
    }

    //Collision cu caramizile
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.CompareTag("Brick"))
        {
            Transform newExplosion = Instantiate(Explosion, other.transform.position, other.transform.rotation);
            Destroy(newExplosion.gameObject, 2.5f);
            gm.UpdateScore(other.gameObject.GetComponent<BrickScript>().points);
            gm.UpdateNumberOfBricks();
            Destroy(other.gameObject);
        }
    }
}
