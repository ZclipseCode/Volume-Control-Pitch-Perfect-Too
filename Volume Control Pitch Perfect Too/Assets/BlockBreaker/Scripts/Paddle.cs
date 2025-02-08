using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    public AudioDetection detector;
    private const float LOUDNESS_SENSIBILITY = 5, THRESHOLD = 0.1f;

    private void FixedUpdate() {
        float loudness = detector.GetLoudnessFromMicrophone() * LOUDNESS_SENSIBILITY;

        if (loudness < THRESHOLD) {
            loudness = 0;
        }
        else {

        }
    }
    
}
