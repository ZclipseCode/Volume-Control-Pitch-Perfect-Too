using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] Transform origin;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float bulletSpeed = 2;
    [SerializeField] float timeBetweenShots = 1.5f;
    public static int points = 0;

    [SerializeField] private float timer = 0;

    [SerializeField] GameObject winText;
    public GameObject stupidLose;
    public GameObject stupidBack;
    public static GameObject loseText;
    public static GameObject backButton;

    // Start is called before the first frame update
    void Start()
    {
        loseText = stupidLose;
        backButton = stupidBack;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > timeBetweenShots)
        {
            GameObject newBullet = Instantiate(projectilePrefab, origin.position, Quaternion.identity) as GameObject;
            newBullet.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed);
            timer = 0;
        }

        if(points == 18)
        {
            winText.SetActive(true);
            backButton.SetActive(true);
            print("You won");
        }
    }

    public static void lose()
    {
        loseText.SetActive(true);
        backButton.SetActive(true);
        print("you lost");
    }
}
