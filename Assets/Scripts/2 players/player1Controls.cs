using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static System.Net.WebRequestMethods;

public class player1Controls : MonoBehaviour
{
    public bool hitTop = false;
    public bool hitBottom = false;
    public KeyCode keyW = KeyCode.W;
    public KeyCode keyS = KeyCode.S;
    public float yPosition = 0;
    public float speed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        // Check if the specified key is being held down
        if (Input.GetKey(keyW))
        {
            if (!hitTop)
            {
                yPosition = yPosition + Time.deltaTime * speed;
                transform.position = new Vector3(-8, yPosition, 0f);
            }


        }
        else if (Input.GetKey(keyS))
        {
            if (!hitBottom)
            {
                yPosition = yPosition - Time.deltaTime * speed;
                transform.position = new Vector3(-8, yPosition, 0f);
            }

        }
        //float z = Input.GetAxis("Vertical");
        //Vector3 movement = new Vector3(0, z, 0);
        //transform.Translate(movement * 30 * Time.deltaTime);
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "boundryTop")
        {
            hitTop = true;
        }
        if (collision.gameObject.name == "boundryBottom")
        {
            hitBottom = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        hitTop = false;
        hitBottom = false;
    }
}
