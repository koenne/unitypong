using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ballMovingExplosions : MonoBehaviour
{
    public float xPosition = 0;
    public float yPosition = 0;
    public float zPosition = 0;
    public bool hitTop = false;
    public bool hitBottom = false;
    public bool hitLeft = false;
    public bool hitRight = false;
    public float speed = 12;
    public int leftRandom;
    public int rightRandom;
    public int topRandom;
    public int BottomRandom;
    public KeyCode keySpace = KeyCode.Space;
    public bool isfinished = true;
    public string playerWon;
    public int score1;
    public int score2;
    public string scorePlayers;
    public TMP_Text mytext;
    GameObject textobj;
    bool gameEnd = false;
    AudioSource audioData;
    public ParticleSystem confetti;
    public ParticleSystem explosion;
    bool firstHit = true;
    public class ScoreController : MonoBehaviour
    {
        public string scorePlayers;
    }
    public GameObject scoreGameObj;

    public GameObject restartButton;


    // Start is called before the first frame update
    void Start()
    {
        leftRandom = UnityEngine.Random.Range(5, 15);
        rightRandom = UnityEngine.Random.Range(5, 15);
        topRandom = UnityEngine.Random.Range(5,15);
        BottomRandom = UnityEngine.Random.Range(5,15);
        audioData = GetComponent<AudioSource>();
        confetti = GameObject.Find("confetti").GetComponent<ParticleSystem>();
        explosion = GameObject.Find("explosion").GetComponent<ParticleSystem>();
        scoreGameObj = GameObject.Find("Score");
        restartButton = GameObject.Find("restartBtn");
        restartButton.SetActive(false); // false to hide, true to show
    }
    // Update is called once per frame
    void Update()
    {
        if (!gameEnd)
        {
            if (hitTop == true)
            {
                yPosition = yPosition - Time.deltaTime * (speed + BottomRandom);
                transform.position = new Vector3(yPosition, yPosition, 0f);
            }
            if (hitBottom == true)
            {
                yPosition = yPosition + Time.deltaTime * (speed + topRandom);
                transform.position = new Vector3(yPosition, yPosition, 0f);
            }
            if (hitLeft == true)
            {
                xPosition = xPosition + Time.deltaTime * (speed + rightRandom);
                transform.position = new Vector3(xPosition, yPosition, 0f);
            }
            if (hitRight == true)
            {
                xPosition = xPosition - Time.deltaTime * (speed + leftRandom);
                transform.position = new Vector3(xPosition, yPosition, 0f);
            }
            if (Input.GetKey(keySpace))
            {
                if (isfinished)
                {

                    if (playerWon == "Player 1")
                    {
                        hitTop = false; hitBottom = false;
                        hitLeft = false; hitRight = true;
                    }
                    else
                    {
                        hitTop = false; hitBottom = false;
                        hitLeft = true; hitRight = false;
                    }
                }
                isfinished = false;

            }
            if (isfinished)
            {
                hitTop = false; hitBottom = false;
                hitLeft = false; hitRight = false;
                xPosition = 0; yPosition = 0; zPosition = 0;
                transform.position = new Vector3(0f, 0f, 0f);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        explosion.Play();
        audioData = GetComponent<AudioSource>();
        if (collision.gameObject.name == "boundryTop")
        {
            audioData.Play(0);
            hitBottom = false;
            hitTop = true;
            topRandom = UnityEngine.Random.Range(5, 15);
        }
        if (collision.gameObject.name == "boundryBottom")
        {
            audioData.Play(0);
            hitTop = false;
            hitBottom = true;
            BottomRandom = UnityEngine.Random.Range(5, 15);
        }
        if (collision.gameObject.name == "player1")
        {
            if(firstHit)
            {
                hitBottom = true;
                firstHit = false;
            }
            audioData.Play(0);
            hitRight = false;
            hitLeft = true;
            rightRandom = UnityEngine.Random.Range(5, 15);
        }
        if (collision.gameObject.name == "player2")
        {
            if(firstHit)
            {
                hitBottom = true;
                firstHit = false;
            }
            audioData.Play(0);
            hitLeft = false;
            hitRight = true;
            leftRandom = UnityEngine.Random.Range(5, 15);
        }
        if (collision.gameObject.name == "endPlayer1")
        {
            score2 = score2 + 1;
            firstHit = true;
            end("Player 2");
        }
        if (collision.gameObject.name == "endPlayer2")
        {
            score1 = score1 + 1;
            firstHit = true;
            end("Player 1");
        }
    }
    void end(string winner)
    {
        playerWon = winner;
        hitTop = false; hitBottom = false;
        hitLeft = false; hitRight = false;
        xPosition = 0; yPosition = 0; zPosition = 0;
        transform.position = new Vector3(0f, 0f, 0f);
        isfinished = true;
        scorePlayers = score1 + " | " + score2;
        if (score1 == 7)
        {
            gameEnd = true;
            scorePlayers = "Player 1 has won!";
            confetti.Play();
            confetti.enableEmission = true;
            restartButton.SetActive(true); // false to hide, true to show
        }
        if (score2 == 7)
        {
            gameEnd = true;
            scorePlayers = "Player 2 has won!";
            confetti.Play();
            confetti.enableEmission = true;
            restartButton.SetActive(true); // false to hide, true to show
        }
        scoreGameObj.GetComponent<TextMeshProUGUI>().text = scorePlayers;    
    }
    public void restart()
    {
        score1 = 0;
        score2 = 0;
        scorePlayers = "0 | 0";
        scoreGameObj.GetComponent<TextMeshProUGUI>().text = scorePlayers;    
        gameEnd = false;
        hitTop = false; hitBottom = false;
        hitLeft = false; hitRight = true;
        confetti.enableEmission = false;
        restartButton.SetActive(false); // false to hide, true to show
    }
}
