//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// I could not find any matrix library for unity that isn't only 4x4 float_float
public class CustomMatrix : MonoBehaviour
{
    //I will probably improve or replace all of this later

    public int rows, colums;
    public float[][] data;
    public CustomMatrix(int _rows,int _colums)
    {
        rows = _rows;
        colums = _colums;
        
        data = new float[rows][];
        for (int i=0; i<rows; i++)
        {
           data[i] = new float[_colums];
           
           for (int j=0; j<colums; j++)
            {
               data[i][j] = 0;
            } 
        }
    }

    public void Randomize()
    {
        for (int i=0; i<rows; i++)
        {   
           for (int j=0; j<colums; j++)
            {
               data[i][j] = Random.Range(-1f,1f);
            } 
        }
    }

    
    public static CustomMatrix Multiply(CustomMatrix a,CustomMatrix b)
    {
        if(a.colums != b.rows)
        {
            Debug.LogError("unequal number of colums on a to rows on b :"+a+","+b);
            return null;
        }

        // this is a standard matrix multiplcation loop 
        CustomMatrix result = new CustomMatrix(a.rows,b.colums);
        for (int i=0; i<result.rows; i++)
        {   
            for (int j=0; j<result.colums; j++)
            {
                float sum =0;
                for (int k=0; k<a.colums; k++)
                {
                    sum += a.data[i][k] * b.data[k][j];
                
                } 
                result.data[i][j] = sum;
            } 
        }
        return result;
    }

    public static CustomMatrix Add(CustomMatrix a,CustomMatrix b)
    {
        // this is a standard matrix add loop 
        CustomMatrix result = new CustomMatrix(a.rows,b.colums);
        for (int i=0; i<result.rows; i++)
        {   
            for (int j=0; j<result.colums; j++)
            {
                float sum =0;
                for (int k=0; k<a.colums; k++)
                {
                    a.data[i][k] += b.data[k][j];
                
                } 
                
            } 
        }
        return a;
    }

    public delegate float callBack(float num);
    public void map(callBack fn)
    {
        // this is used to make an interchangable activation fucntion
        
        for (int i=0; i<this.rows; i++)
        {   
            for (int j=0; j<this.colums; j++)
            {
               this.data[i][j] = fn(this.data[i][j]);
                
            } 
        }
        
    }

    public static float sigmoid(float num)
    {
        return 1/(1+Mathf.Exp(-num));
    }

    public static CustomMatrix FromArray(float[] arr)
    {
        // this converts arrays to matrix
        CustomMatrix result = new CustomMatrix(arr.Length,1);
        for (int i=0; i<result.rows; i++)
        {   
           result.data[i][0] = arr[i];    
        }
        return result;
        
    }
    public static float[] ToArray(CustomMatrix matrix)
    {
        // this converts arrays to matrix
        float[] result = new float[matrix.data.Length];
        for (int i=0; i<matrix.data.Length; i++)
        {   
           result[i] = matrix.data[i][0];    
        }
        return result;
        
    }

    public void display()
    {
        for (int i=0; i<rows; i++)
        {   
           for (int j=0; j<colums; j++)
            {
               print(data);
            } 
        }
    }


}
