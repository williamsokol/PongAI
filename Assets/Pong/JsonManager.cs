using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonManager : MonoBehaviour
{

    public Paddle paddle;
    public Ball ball;
    
    GameData gameData= new GameData();
    


    private void Update() {
        

        

       

    }
    void writeTrainData()
    {
        gameData.trainData.Add (new Data(paddle.transform.position.y,
                                ball.transform.position.x,
                                ball.transform.position.y,
                                Mathf.Abs(ball.vx),
                                paddle.movementX));

        string json = JsonUtility.ToJson(gameData);                             //class -> string
        print(Application.dataPath + "/thing.json");
        File.WriteAllText(Application.dataPath + "/thing.json",json);           //string -> json
    }

    public GameData readTrainData()
    {
        string json = File.ReadAllText(Application.dataPath + "/thing.json");   //json -> string
        GameData loadedGameData = JsonUtility.FromJson<GameData>(json);         //string -> class
        Debug.Log(loadedGameData.trainData[12].paddlePos);
        return loadedGameData;
    }
    
}
