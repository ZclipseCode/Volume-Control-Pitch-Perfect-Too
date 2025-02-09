using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invaderEnemy : MonoBehaviour
{
    private float timer = 0;
    private bool boolOne = false;
    private bool boolTwo = false;
    private bool boolThree = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 4)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - .25f, this.transform.position.z);
            boolOne = false;
            boolTwo = false;
            boolThree = false;
            timer = 0;
        }
        else if(timer > 3 && !boolThree)
        {
            this.transform.position = new Vector3(this.transform.position.x + .5f, this.transform.position.y, this.transform.position.z);
            boolThree = true;
        }
        else if(timer > 2 && !boolTwo)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - .25f, this.transform.position.z);
            boolTwo = true;
        }
        else if(timer > 1 && !boolOne)
        {
            this.transform.position = new Vector3(this.transform.position.x - .5f, this.transform.position.y, this.transform.position.z);
            boolOne = true;
        }
    }
}
