using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public GameObject target;
    public float constVelocity;
    public Vector3 Origin;


    private NeuralNetwork neuralNetwork;
    private float[] input = new float[4];

    public void Start()
    { 
        //Physics
        this.gameObject.AddComponent<Rigidbody>();
        this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

        //origin
        this.gameObject.transform.position = Origin;

        //Information
        this.gameObject.layer = LayerMask.NameToLayer("Agent");
        this.gameObject.transform.name = "Agent";
        this.gameObject.transform.tag = "Agent";

        //Neural Network
        int[] structure = new int[4] { 4, 4, 4, 1 };
        this.neuralNetwork = new NeuralNetwork(structure);

    }

    private void Update()
    {
        this.terminalVelocity();
        this.rotate(Random.Range(-1f, 1f));
        this.computate();
    }
        
    private void terminalVelocity()
    {
        this.gameObject.GetComponent<Rigidbody>().velocity = this.constVelocity * this.gameObject.transform.TransformDirection(Vector3.forward);
    }

    private void computate()
    {
        //RaycastDirections
        Vector3[] directionList = new Vector3[4];
        directionList[0] = Vector3.forward;
        directionList[1] = Vector3.left;
        directionList[2] = Vector3.right;
        directionList[3] = Vector3.back;

        for(int i = 0; i < 4; i++)
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, gameObject.transform.TransformDirection(directionList[i]));
            Debug.DrawLine(this.gameObject.transform.position, this.gameObject.transform.position + 7.5f * gameObject.transform.TransformDirection(directionList[i]), Color.magenta);
            if (Physics.Raycast(ray, out hit, 7.5f, ~(1 << 8)))
            {
                input[i] = 7.5f - (this.gameObject.transform.position - hit.point).magnitude/10;
            }
            else { input[i] = 0f; }
        }

        float[] output = neuralNetwork.feedForward(input);
        print(output[0]);
    }
    private void rotate(float _rotation)
    {
        float deltaRot = 360.0f * _rotation * Time.deltaTime;
        Quaternion deltaQuaternion = Quaternion.Euler(0, deltaRot, 0);
        this.gameObject.GetComponent<Rigidbody>().MoveRotation(this.gameObject.transform.rotation * deltaQuaternion);
    }
<<<<<<< HEAD
<<<<<<< HEAD
    public void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            hasCollided = true;
        }
    }

    public void calcFitness()
    {
        neuralNetwork.setFitness(1000/(this.gameObject.transform.position - target.transform.position).magnitude);
    }
=======
>>>>>>> parent of 63ef37a (Genetic Algorithm)
=======
>>>>>>> parent of 63ef37a (Genetic Algorithm)
}
