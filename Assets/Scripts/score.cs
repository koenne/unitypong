using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static ballMoving;
using Unity.VisualScripting;

public class score : MonoBehaviour
{
    public string currentScore = "0 | 0";
    public TMP_Text messageText;
    public GameObject go;
    public ballMoving ballMoving;
    // Start is called before the first frame update
    void Start()
    {
        go = GameObject.Find("Ball");
        ballMoving = go.GetComponent<ballMoving>();
    }

    // Update is called once per frame
    void Update()
    {

        currentScore = ballMoving.scorePlayers;
        gameObject.GetComponent<TextMeshProUGUI>().text = currentScore;

        
    }
}
