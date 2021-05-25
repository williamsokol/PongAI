using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeuralNetwork : MonoBehaviour
{
    
    public CustomMatrix[] weights;
    public CustomMatrix[] biases;
    public int layers;

    // _dataIn = list of the networks layers
    // _dataIn[layer] = list of that layers neurons
    // _dataIn[layer][neuron] = list of that neurons weights
    // _dataIn[layer][neron][weight] = that weights value.
    public NeuralNetwork(float [][] _dataIn)
    {
        weights = new CustomMatrix[_dataIn.Length]; //new matrix for each layer
        biases = new CustomMatrix[_dataIn.Length];
        layers = _dataIn.Length;

        for (int layer=1; layer< _dataIn.Length; layer++)
        {
        
            weights[layer] = new CustomMatrix(_dataIn[layer].Length,_dataIn[layer-1].Length); //assign neurons to matrix
            weights[layer].Randomize();

            biases[layer] = new CustomMatrix(_dataIn[layer].Length,1);
            biases[layer].Randomize(); 
        }

    }    

    float[] FeedForward(float[] _inputs)
    {
        CustomMatrix[] layer = new CustomMatrix[layers];

        layer[0] = CustomMatrix.FromArray(_inputs);

        for(int i=0; i<layer.Length; i++)
        {
            layer[i+1] = CustomMatrix.Multiply(weights[i],layer[i]);
            layer[i+1] = CustomMatrix.Add(layer[i+1],biases[i]);

            layer[i+1].map(CustomMatrix.sigmoid);
        }

        return CustomMatrix.ToArray(layer[layer.Length]);
    }
        
}
