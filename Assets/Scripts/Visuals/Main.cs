using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    NeuralNetwork nn;
    public XorTileGrid g;
    
    void Start()
    {
        // quickly put together 2D array for shape of NeralNet
        float[][] neuralNet = new float[3][];
        for(int i=0; i< neuralNet.Length; i++)
        {
            neuralNet[i] = new float[2];
        }
  
        nn = new NeuralNetwork(neuralNet);
        
        print(nn.weights[1].data[1][1]);
        g.FeedForwardUpdate(nn);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            print(nn);
        }
    }
}
