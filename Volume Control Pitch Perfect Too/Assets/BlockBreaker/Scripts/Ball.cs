using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour {
    private GameObject ball;
    private float BALL_SPEED = 2f, MAX_ANGLE = 60;
    private Rigidbody2D rb;
    private Vector2 force;
    private float width;
    private Vector2 last_vel;

    private void Start() {
        ball = gameObject;
        rb = ball.GetComponent<Rigidbody2D>();
        force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;
        rb.AddForce(force * BALL_SPEED * 10);
        width = ball.GetComponent<CircleCollider2D>().bounds.size.x / 2;
    }

    private void Update() {
        last_vel = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        float speed = last_vel.magnitude;
        Vector3 direction = Vector3.Reflect(last_vel.normalized, collision.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(BALL_SPEED, 0f);
        if(BALL_SPEED < 4)
        {
            BALL_SPEED += .1f;
        }
    }
}
