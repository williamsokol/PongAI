using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    NeuralNetwork nn;
    public XorTileGrid g;

    
    TrainData[] trainingData = new TrainData[]
    {
        new TrainData(new float[]{0,1},new float[]{1}),
        new TrainData(new float[]{1,0},new float[]{1}),
        new TrainData(new float[]{1,1},new float[]{0}),
        new TrainData(new float[]{0,0},new float[]{0}) 
    };
    
    void Start()
    {
        // quickly put together 2D array for shape of NeralNet
        float[][] neuralNet = new float[3][];
        for(int i=0; i< neuralNet.Length; i++)
        {
            neuralNet[i] = new float[2];
        }
        //neuralNet[1] = new float[3];

        neuralNet[neuralNet.Length-1] = new float[1];

        nn = new NeuralNetwork(neuralNet);


        

        TrainData data = trainingData[0];
        nn.Train(data.inputs,data.outputs);

        print("thing: "+ data.outputs[0]);
        //print(nn.FeedForward(new float[]{0,1})[0]);
        g.FeedForwardUpdate(nn);
    }

    // Update is called once per frame
    void Update()
    {
        Play();
    }
    void Play()
    {
        for(int i=0;i<1000; i++)
        {
            TrainData data = trainingData[Random.Range(0,4)];
            nn.Train(data.inputs,data.outputs);
        }
        
        g.FeedForwardUpdate(nn);
        print(nn.FeedForward(new float[]{0,0})[0]);
    }
}
