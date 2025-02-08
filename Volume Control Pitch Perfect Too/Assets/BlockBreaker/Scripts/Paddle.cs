using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    public AudioDetection detector;
    private const float LOUDNESS_SENSIBILITY = 5, THRESHOLD = 0.1f;
    [SerializeField] GameObject left, right;
    private GameObject bumper;

    private void Start() {
        bumper = gameObject;
    }

    private void FixedUpdate() {
        float loudness = detector.GetLoudnessFromMicrophone() * LOUDNESS_SENSIBILITY;

        if (loudness < THRESHOLD) {
            loudness = 0;
            Mathf.Lerp(bumper.transform.position.x, left.transform.position.x, Time.deltaTime * loudness);
        }
        else {
            Mathf.Lerp(bumper.transform.position.x, right.transform.position.x, Time.deltaTime * loudness);
        }
    }
    
}
