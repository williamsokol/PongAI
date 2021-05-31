using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
    public struct TrainData
{
    public float[] inputs;
    public float[] outputs;
    
    public TrainData(float[] _input, float[] _output)
    {
        this.inputs = _input;
        this.outputs = _output;
    }
}
public class GameData 
{
    

   public List<TrainData> trainData = new List<TrainData>();

   
   
}
