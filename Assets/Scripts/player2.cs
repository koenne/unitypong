using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;
using static System.Net.WebRequestMethods;

public class player2 : MonoBehaviour
{
    public float yPosition = 0;
    public bool hitTop = false;
    public bool hitBottom = false;
    public Vector3 posBall;
    public Vector3 posPlayer;
    public GameObject ball;
    public GameObject player;
    float ballyPosition = 0;
    float playeryPosition = 0;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("Ball");
        player = GameObject.Find("player2");
    }

    // Update is called once per frame
    void Update()
    {
        posBall = ball.transform.position;
        posPlayer = player.transform.position;
        ballyPosition = posBall.y;
        playeryPosition = posPlayer.y;
        if (playeryPosition > ballyPosition)
        {
            if (hitBottom != true)
            {
                yPosition = yPosition - Time.deltaTime * 12;
                transform.position = new Vector3(8, yPosition, 0f);
            }

        }
        else
        {
            if (hitTop != true)
            {
                yPosition = yPosition + Time.deltaTime * 8;
                transform.position = new Vector3(8, yPosition, 0f);
            }

        }
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
