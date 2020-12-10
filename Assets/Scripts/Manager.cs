using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public int populationCount = 100;
    public GameObject Origin;

    private void Start()
    {
        for(int i = 0; i < populationCount; i++)
        {
            //Create GameObject;
            GameObject agent = GameObject.CreatePrimitive(PrimitiveType.Cube);

            //Parent agent script
            agent.AddComponent<Agent>();
            agent.GetComponent<Agent>().constVelocity = 3f;
            agent.GetComponent<Agent>().target = null;
            agent.GetComponent<Agent>().Origin = Origin.transform.position; 
        }
    }
}
