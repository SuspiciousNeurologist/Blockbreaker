using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //config parameters
    [SerializeField] float minX = 1f ;
    [SerializeField] float maxX = 15f;
    [SerializeField] float screenWidthInUnits = 16f;

    //cached references
    GameStatus gameStatus;
    Ball ball;
    
    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();
    }
     

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x,transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(),minX,maxX);
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if(gameStatus.IsAutoplayEnabled())
        {
            return ball.transform.position.x;
        }else{
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }

    }
}
