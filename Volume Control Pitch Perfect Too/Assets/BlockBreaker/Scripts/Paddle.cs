using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    public AudioDetection detector;
    private const float LOUDNESS_SENSIBILITY = 50, THRESHOLD = 0.1f;
    [SerializeField] GameObject left, right;
    private GameObject bumper;

    private void Start() {
        bumper = gameObject;
    }

    private void FixedUpdate() {
        float loudness = detector.GetLoudnessFromMicrophone() * LOUDNESS_SENSIBILITY;

        if(loudness > THRESHOLD)
        {
            print(loudness);
        }

        if (loudness < THRESHOLD) {
            loudness = 0;
            Vector3.Lerp(bumper.transform.position, left.transform.position, Time.deltaTime);
        }
        else {
            Vector3.Lerp(bumper.transform.position, right.transform.position, Time.deltaTime * loudness);
        }
    }
    
}
