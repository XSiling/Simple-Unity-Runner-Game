using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    // Start is called before the first frame update
    private int direction;
    private Transform transform;
    void Start()
    {
        direction =0;//0 for left ,1 for right
        transform = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (direction==0)
        {
            transform.Translate(new Vector3(0.05f,0,0),Space.World);
            if (transform.position.x>1.5f)
            {
                direction=1;
            }
        }
        else
        {
            transform.Translate(new Vector3(-0.05f,0,0),Space.World);
            if (transform.position.x<-1.5f)
            {
                direction = 0 ;
            }
        }
    }
}
