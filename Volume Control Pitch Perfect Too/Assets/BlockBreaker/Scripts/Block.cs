using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour {
    private int hp;
    private const int MAXHP = 5;
    private Color[] hp_colors = new Color[MAXHP];
    private GameObject block;
    private SpriteRenderer blockrend;

    public static Action<bool> Block_Destroyed_Event;

    private void Start() {
        hp_colors[0] = Color.green;
        hp_colors[1] = Color.yellow;
        hp_colors[2] = Color.red;
        hp_colors[3] = Color.blue;
        hp_colors[4] = new Color(114, 0, 214);
        blockrend = GetComponentInChildren<SpriteRenderer>();
        block = gameObject;
        hp = UnityEngine.Random.Range(1, MAXHP + 1);
        blockrend.color = hp_colors[hp - 1];
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        hp--;
        if(hp > 0) {
            blockrend.color = hp_colors[hp - 1];
        }
        else {
            Block_Destroyed_Event?.Invoke(true);
            Destroy(block);
        }
    }

}
