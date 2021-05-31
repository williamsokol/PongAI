using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
    public struct Data
    {
        public float paddlePos;
        public float ballX;
        public float ballY;
        public float ballSpeed;
        public float playerResponse;
        public Data(float _paddlePos,float _ballX,float _ballY,float _ballSpeed, float _playerResponse)
        {
            paddlePos = _paddlePos;
            ballX = _ballX;
            ballY = _ballY;
            ballSpeed = _ballSpeed;
            playerResponse = _playerResponse;
        }
    }
public class GameData 
{
    

   public List<Data> trainData = new List<Data>();
   
}
