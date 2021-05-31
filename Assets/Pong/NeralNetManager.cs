using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeralNetManager : MonoBehaviour
{
    public JsonManager jsonManager;
    NeuralNetwork nn;

    public static float[] outputs;
    private void Start() {
        float[][] nnSetUp = new float[3][];
        nnSetUp[0] = new float[5];//input
        nnSetUp[1] = new float[11];//hidden
        nnSetUp[2] = new float[1];//output

        nn  = new NeuralNetwork(nnSetUp);


        GameData trainingData = jsonManager.readTrainData();

        for(int i=0;i<100000; i++)
        {
            TrainData data = trainingData.trainData[Random.Range(0,trainingData.trainData.Count)];
            nn.Train(data.inputs,data.outputs);
        }
        
       
        print(nn.FeedForward(new float[]{0,0})[0]);
    }

    // Update is called once per frame
    void Update()
    {
        GameData trainingData = jsonManager.readTrainData();

        for(int i=0;i<1000; i++)
        {
            TrainData data = trainingData.trainData[Random.Range(0,trainingData.trainData.Count)];
            nn.Train(data.inputs,data.outputs);
        }

        outputs = nn.FeedForward(jsonManager.CollectData().inputs);
        print((outputs[0]*2-1) );
    }
}
