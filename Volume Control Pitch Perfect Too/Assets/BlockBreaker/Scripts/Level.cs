using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Level : MonoBehaviour {
    private int blocks;
    private int lives;
    [SerializeField] GameObject win_lose_screen;

    private void Start() {
        lives = 3;
        Block.Block_Destroyed_Event += BlockBroken;
        KillFloor.Ball_Die_Event += BallLost;
        foreach (Transform child in gameObject.transform) {
            if(child.name == "Block") {
                blocks++;
            }
        }
    }

    private void BlockBroken(bool b) {
        blocks--;
        if(blocks == 0) {
            //show win screen
        }
    }

    private void BallLost(bool b) {
        lives--;
        if (lives == 0) {
            //show lose screen
        }
    }




}
