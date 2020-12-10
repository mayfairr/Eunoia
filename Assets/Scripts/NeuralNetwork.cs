using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class NeuralNetwork : IComparable<NeuralNetwork>
{
    private int[] layers; //Overall structure of network
    private float[][] nodes; //value at each node in each layer
    private float[][][] weights; // value of weight connecting two layers
    private float fitness; //fitness of network

    //<summary> Construct Neural Network </summary>
    public NeuralNetwork(int[] structure)
    {
        this.layers = new int[structure.Length];
        //Populate with structure
        for(int i = 0; i < structure.Length; i++)
        {
            this.layers[i] = structure[i];
        }
        createNodes();
        createWeights();
    }

    public NeuralNetwork (NeuralNetwork copyNetwork)
    {
        this.layers = new int[copyNetwork.layers.Length];
        for (int i = 0; i < copyNetwork.layers.Length; i++)
        {
            this.layers[i] = copyNetwork.layers[i];
        }

        createNodes();
        createWeights();
        CopyWeights(copyNetwork.weights);
    }
    private void CopyWeights(float[][][] copyWeights)
    {
        for (int i = 0; i < weights.Length; i++)
        {
            for (int j = 0; j < weights[i].Length; j++)
            {
                for (int k = 0; k < weights[i][j].Length; k++)
                {
                    weights[i][j][k] = copyWeights[i][j][k];
                }
            }
        }
    }
    //<summary> Create Nodes </summary>
    public void createNodes()
    {
        List<float[]> nodes = new List<float[]>();
        for(int i = 0; i < layers.Length; i++)
        {
            nodes.Add(new float[layers[i]]);
        }

        this.nodes = nodes.ToArray();
    }

    //<summary> Create Weights </summary>
    public void createWeights()
    {
        List<float[][]> weights = new List<float[][]>();
        //Loop each layer
        for(int i = 1; i < layers.Length; i++)
        {
            List<float[]> layerWeight = new List<float[]>();
            int previousNodeCount = layers[i - 1];
            //Loop each node in said layer
            for (int j = 0; j < nodes[i].Length; j++)
            {
                float[] weight = new float[previousNodeCount];
                //Loop each weight connecting node in previous layer and current node
                for (int k = 0; k < previousNodeCount; k++)
                {
                    //randomise weights
                    weight[k] = UnityEngine.Random.Range(-0.5f, 0.5f);
                }
                layerWeight.Add(weight);
            }
            weights.Add(layerWeight.ToArray());
        }
        this.weights = weights.ToArray();
    }

    public float[] feedForward(float[] input)
    {
        //Dump input to first layer;
        for(int i = 0; i < input.Length; i++)
        {
            this.nodes[0][i] = input[i];
        }

        //Iterate through the network
        for(int i = 1; i < this.layers.Length; i++)
        {
            for(int j = 0; j < this.nodes[i].Length; j++)
            {
                float bias = .2f;
                float sum = bias;

                for(int k = 0; k < this.nodes[i - 1].Length; k++)
                {
                    sum += nodes[i - 1][k] * weights[i - 1][j][k]; 
                }

                // Range [-1, 1] hyperbolic tanget activation
                nodes[i][j] = (float)Math.Tanh(sum);

            }
        }
        return nodes[nodes.Length - 1];
    }

    //Mutate Gene
    public void mutate()
    {
        for(int i = 0; i <  weights.Length; i++)
        {
            for(int j = 0; j < weights[i].Length; j++)
            {
                for(int k = 0; k < weights[i][j].Length; k++)
                {
                float weight = weights[i][j][k];

                //Mutate this weight by a probability set it to weight;

                float probability = UnityEngine.Random.Range(0f, 1.0f);

                if (probability < 0.01f)
                {
                    weight *= -1;
                }

                if (probability >= 0.2 && probability < 0.04f)
                {
                    weight = UnityEngine.Random.Range(-0.5f, 0.5f);
                }

                if (probability >= 0.4 && probability < 0.07f)
                {
                    float factor = UnityEngine.Random.Range(0f, 1f) + 1f;
                    weight *= factor;
                }

                if (probability >= 0.7 && probability <= 0.01f)
                {
                    float factor = UnityEngine.Random.Range(0f, 1f);
                    weight *= factor;
                }
                        
                weights[i][j][k] = weight;


                }
            }
        }
    }


    public void addFitness(float _fitness)
    {
        this.fitness += _fitness;
    }

    public void setFitness(float _fitness)
    {
        this.fitness = _fitness;
    }

    public float getFitness()
    {
        return this.fitness;
    }

    public int CompareTo(NeuralNetwork other)
    {
        if (other == null) return 1;

        if (fitness > other.fitness)
            return 1;
        else if (fitness < other.fitness)
            return -1;
        else
            return 0;
    }
}
