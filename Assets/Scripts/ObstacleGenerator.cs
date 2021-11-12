using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject []ob = new GameObject[5];
    private int []front_distance = {8,10,12,14,16};
    private Transform transform;
    private GameObject obs_parent;
    private int Generating_time = 150;
    private int Generating_class =0;
    private int current_time = 0;
    //private int front_distance = 15;
    Random rand;
    // Start is called before the first frame update
    void Start()
    {
        rand = new Random();
        transform = this.GetComponent<Transform>();
        obs_parent = GameObject.Find("Obs");
        //front_distance=[10,10,15,8,15];
    }

    // Update is called once per frame
    void Update()
    {
        if (current_time==Generating_time)
        {
            obs_parent = GameObject.Find("Obs");
            //generate!
            Debug.Log("generate an obstacle!");
            Vector3 new_location;
            //the x & y is fixed , and z is set in front of the player by 20.
            double x_random;
            int f_random;
            x_random = rand.NextDouble()*3.0-1.5;
            f_random = rand.Next(100)%5;
            new_location = new Vector3((float)x_random,ob[Generating_class].transform.position.y,transform.position.z-(float)front_distance[f_random]);
            Instantiate(ob[Generating_class],new_location,ob[Generating_class].transform.rotation,obs_parent.transform);
            current_time=0;
            Generating_class =(Generating_class+1)%5;
        }
        current_time ++;   
    }
}
