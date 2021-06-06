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
    public void RotateData()
    {
        for(int i=0; i<inputs.Length; i++)
        {
            inputs[i] = -inputs[i];
        }
        for(int i=0; i<outputs.Length; i++)
        {
            //outputs[i] = -outputs[i];
        }
    }
}
public class GameData 
{
    

   public List<TrainData> trainData = new List<TrainData>();

   
   
}
