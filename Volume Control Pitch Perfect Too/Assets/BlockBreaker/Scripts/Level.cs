using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Level : MonoBehaviour {
    private int blocks;
    private int lives;
    [SerializeField] GameObject win_screen, lose_screen;
    [SerializeField] TMP_Text lives_text;

    private void Start() {
        lives = 5;
        UpdateLives();
        Block.Block_Destroyed_Event += BlockBroken;
        KillFloor.Ball_Die_Event += BallLost;
        foreach (Transform child in gameObject.transform) {
            if(child.name.Contains("Block")) {
                blocks++;
            }
        }
    }

    private void BlockBroken(bool b) {
        blocks--;
        if(blocks == 0) {
            KillFloor.Ball_Die_Event -= BallLost;
            lives_text.text = "";
            win_screen.SetActive(true);
        }
    }

    private void BallLost(bool b) {
        lives--;
        UpdateLives();
        if (lives == 0) {
            Block.Block_Destroyed_Event -= BlockBroken;
            lives_text.text = "";
            lose_screen.SetActive(true);
        }
    }

    private void UpdateLives() {
        lives_text.text = lives + "x";
    }


}
