using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Level : MonoBehaviour {
    private int blocks;
    [SerializeField] GameObject win_lose_screen;

    private void Start() {
        Block.Block_Destroyed_Event += BlockBroken;
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
        //show lose screen
    }




}
