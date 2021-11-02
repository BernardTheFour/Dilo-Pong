using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KontrolBola : MonoBehaviour
{
    // Rigidbody
    private Rigidbody2D rigidbody2D;

    // Initial force
    public Vector2 InitialForce;

    // Titik asal lintasan bola saat ini
    private Vector2 trajectoryOrigin;
    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }

    // Start is called before the first frame update
    void Start()
    {
        trajectoryOrigin = transform.position;
        rigidbody2D = GetComponent<Rigidbody2D>();

        RestartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResetBall()
    {
        transform.position = Vector2.zero;
        rigidbody2D.velocity = Vector2.zero;
    }

    void PushBall()
    {
        // Y direction
        float yRandomForce = Random.Range(-InitialForce.y, InitialForce.y);

        // X direction
        float xRandomDirection = Random.Range(0, 2);
        float xForce = xRandomDirection < 1 ? -InitialForce.x : InitialForce.x;

        Vector2 appliedForce = new Vector2(xForce, yRandomForce);
        rigidbody2D.AddForce(appliedForce);
    }

    void RestartGame()
    {
        ResetBall();
        Invoke("PushBall", 2);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;
    }
}
