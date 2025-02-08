using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour {
    private GameObject ball;
    private const float BALL_SPEED = 100f, MAX_ANGLE = 60;
    private Rigidbody2D rb;
    private Vector2 force;
    private float width;

    private void Start() {
        ball = gameObject;
        rb = ball.GetComponent<Rigidbody2D>();
        force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;
        rb.AddForce(force * BALL_SPEED);
        width = ball.GetComponent<CircleCollider2D>().bounds.size.x / 2;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Paddle") {
            float offset = collision.transform.position.x - ball.transform.position.x;
            float curr_angle = Vector2.SignedAngle(Vector2.up, rb.velocity);
            float bounce_angle = (offset / width) * MAX_ANGLE;
            float new_angle = Mathf.Clamp(curr_angle * bounce_angle, -MAX_ANGLE, MAX_ANGLE);
            Quaternion rotation = Quaternion.AngleAxis(new_angle, Vector3.forward);
            rb.velocity = rotation * Vector2.up * rb.velocity.magnitude;
        }
    }
}
