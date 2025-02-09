using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] Transform origin;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float bulletSpeed = 2;
    [SerializeField] float timeBetweenShots = 1.5f;

    [SerializeField] private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
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
    }
}
