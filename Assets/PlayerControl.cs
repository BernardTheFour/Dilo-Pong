using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Input
    public KeyCode upButton = KeyCode.W;
    public KeyCode downButton = KeyCode.S;

    // Rigidbody
    private Rigidbody2D rigidbody2D;
    public float rbSpeed = 10f;

    // Boundary
    public Transform yBoundary;

    // Titik tumbukan terakhir dengan bola, untuk menampilkan variabel-variabel fisika terkait tumbukan tersebut
    private ContactPoint2D lastContactPoint;

    public ContactPoint2D LastContactPoint
    {
        get { return lastContactPoint; }
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        Vector2 velocity = rigidbody2D.velocity;

        if (Input.GetKey(upButton))
        {
            velocity.y = rbSpeed;
        }
        else if (Input.GetKey(downButton))
        {
            velocity.y = -rbSpeed;
        }
        else
        {
            velocity.y = 0.0f;
        }

        rigidbody2D.velocity = velocity;

        // Boundary
        Vector2 currPosition = rigidbody2D.transform.position;

        currPosition.y = Mathf.Clamp(currPosition.y, -yBoundary.position.y, yBoundary.position.y);

        rigidbody2D.transform.position = currPosition;
    }

    public int Score { get; private set; }

    public void IncrementScore()
    {
        Score++;
    }

    public void ResetScore()
    {
        Score = 0;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Ball"))
        {
            lastContactPoint = collision.GetContact(0);
        }
    }
}
