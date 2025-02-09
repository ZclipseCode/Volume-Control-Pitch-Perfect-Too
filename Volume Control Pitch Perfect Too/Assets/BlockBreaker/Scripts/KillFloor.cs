using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFloor : MonoBehaviour {
    [SerializeField] GameObject spawn, ball;

    public static Action<bool> Ball_Die_Event;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.name.Contains("Ball")) {
            Destroy(collision.gameObject);
            Ball_Die_Event?.Invoke(true);
            GameObject new_ball = Instantiate(ball);
            new_ball.transform.position = spawn.transform.position;
        }
    }
}
