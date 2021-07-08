using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balls : MonoBehaviour
{
    private bool jump;
    //private Rigidbody rgball;
    Renderer prendererball;
    
    //spawns at -12.71, 0, -0.76 : level 1
    //spawns at -11.43, 0/-2.080, 3.1 : level 2

    // Start is called before the first frame update
    void Start()
    {
        //rgball = GetComponent<Rigidbody>();
        prendererball = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.forward, ForceMode.VelocityChange);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.back, ForceMode.VelocityChange);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.left, ForceMode.VelocityChange);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.right, ForceMode.VelocityChange);
        }
        if (Input.GetKeyDown(KeyCode.Space) && jump == true)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 4.5f, ForceMode.VelocityChange);
            jump = false;
        }
    }

    void OnCollisionEnter(Collision collision)
     {
            jump = true;
        //gameManager.Instance.Score += 10;
     }

    private void FixedUpdate()
    {
        if (!prendererball.isVisible)
        {
            Destroy(gameObject);
            //update lives in game manager
            gameManager.Instance.Lives--;
        }
    }

    /*
    private void FixedUpdate()
    {
        if(jump == true)
        {
            print("fucking BULLSIT");
            GetComponent<Rigidbody>().AddForce(Vector3.up * 5, ForceMode.VelocityChange);
            jump = false;
        }
    }*/
}
