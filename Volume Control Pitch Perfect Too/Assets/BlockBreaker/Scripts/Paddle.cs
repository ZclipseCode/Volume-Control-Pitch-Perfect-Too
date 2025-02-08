using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Paddle : MonoBehaviour {
    public AudioDetection detector;
    private const float LOUDNESS_SENSIBILITY = 50, THRESHOLD = 0.1f;
    [SerializeField] GameObject left, right;
    private GameObject bumper;
    private float paddlex, paddley, paddlez, leftx, rightx;
    private void Start() {
        bumper = gameObject;
        leftx = left.transform.position.x;
        rightx = right.transform.position.x;
        paddlex = bumper.transform.position.x;
        paddley = bumper.transform.position.y;
        paddlez = bumper.transform.position.z;
    }

    private void FixedUpdate() {
        float loudness = detector.GetLoudnessFromMicrophone() * LOUDNESS_SENSIBILITY;

        if(loudness > THRESHOLD)
        {
            print(loudness);
        }

        if (loudness < THRESHOLD) {
            loudness = 0;
            bumper.transform.position = Vector2.Lerp(bumper.transform.position, left.transform.position, Time.deltaTime);
        }
        else {
            bumper.transform.position = Vector2.Lerp(bumper.transform.position, right.transform.position, Time.deltaTime * loudness);
        }
    }
    
}
