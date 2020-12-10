using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public int populationCount;
    public int generation;

    public GameObject target;
    public GameObject origin;

    private List<NeuralNetwork> neuralNetworks;
    private List<GameObject> agents;

    public float repeatRate;
    public float timeScale;

    public int layers;
    public int[] structure;
    public void Start()
    {
        structure = new int[]{ 4,10,15,1};
        createNeuralNetworks();
        InvokeRepeating("createAgents", .1f, repeatRate);
    }
    public void createNeuralNetworks()
    {
        neuralNetworks = new List<NeuralNetwork>();
        for(int i = 0; i < populationCount; i++)
        {
            NeuralNetwork nn = new NeuralNetwork(structure);
            neuralNetworks.Add(nn);
        }
  
    }
    public void createAgents()
    {
        Time.timeScale = timeScale;
        if(agents != null)
        {
            for(int i = 0; i < populationCount; i++)
            {
                Destroy(agents[i]);
            }
            sortNetwork();
            
        }
        agents = new List<GameObject>();
        for (int i = 0; i < populationCount; i++){
            GameObject agent = GameObject.CreatePrimitive(PrimitiveType.Cube);
            agent.AddComponent<Agent>();
            agent.GetComponent<Agent>().neuralNetwork = neuralNetworks[i];
            agent.GetComponent<Agent>().target = target;
            agent.GetComponent<Agent>().constVelocity = 3.0f;
            agent.GetComponent<Agent>().Origin = origin.transform.position;
            agent.layer = LayerMask.NameToLayer("Agent");
            agent.transform.tag = "Agent";
            agents.Add(agent);
            
        }
    }

    public void sortNetwork()
    {
        //sorts the neural network list in ascending order in terms of fitness, 0 being really bad.
        this.neuralNetworks.Sort();

        //Make bottom a copied version of top half with some mutations. 
        for(int i = 0; i < populationCount/2; i++)
        {
            neuralNetworks[i] = new NeuralNetwork(neuralNetworks[populationCount / 2 + i]);
            neuralNetworks[i].mutate();
        }
    }
}
