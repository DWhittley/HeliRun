using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScroll : MonoBehaviour
{
    public int speed = 120;
    public float minZPos = -2.0f;
    public float incrementRate = 10.0f; // speed increase increment

    private Rigidbody rb;
    private float IncrementTimer;
    private float incrementInterval = 5.0f; // speed increase interval (seconds)

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.forward * -speed;
    }

    void Update()
    {
        IncrementTimer += Time.deltaTime;
        if (IncrementTimer >= incrementInterval) // check if interval exceeded
        {
            speed += (int)incrementRate; // increase speed by increment
            rb.velocity = Vector3.forward * -speed; // Asjust velocity to new speed
            IncrementTimer = 0.0f; // Reset timer
        }

        if (transform.position.z < minZPos)
        {
            Destroy(gameObject);
        }
    }
}