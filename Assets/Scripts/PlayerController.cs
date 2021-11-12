using UnityEngine;
using System.Collections;
using UnityEngine.UI;
 
public class PlayerController : MonoBehaviour
{
    public float speed = 7;
    private Transform transform;
    private Rigidbody rb;
    private Quaternion my_q;
    public int Blood;
    private GameObject obs;
    private float lastz;
    public Text my_text;
    public float force=100;
    private int collid_state;
 
    // Use this for initialization
    void Start()
    {
        transform = this.GetComponent<Transform>();
        rb = this.GetComponent<Rigidbody>();
        my_q = transform.rotation;
        Blood = 5;
        lastz = transform.position.z;
        collid_state=0;
    }
 
    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        Vector3 location;
        location = transform.position;
        //x edge detector 
        if (lastz<-133)
        {
            Debug.Log("Game Win!");
            my_text.text="You Win!";
            return;
        }
        transform.Translate(new Vector3(h,0, 1) * speed * Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.Space)&& transform.position.y<0.3f)
        {
            rb.velocity +=Vector3.up*force;
        }
        lastz = transform.position.z;


        if (transform.rotation != my_q)
        {
            transform.rotation = my_q;
            //Debug.Log("Change angle to 180!");
        }
        if(location.y<-3 || Blood<=0)
        {
            Reborn();
           return;
        }
        location = transform.position;
        //x edge detection here
        if (location.x<=-1.5f)
        {
            Debug.Log("Out of left edge!");
            transform.position = new Vector3(-1.5f,location.y,location.z);
        }
        if (location.x>=1.5f)
        {
            Debug.Log("Out of right edge!");
            transform.position = new Vector3(1.5f,location.y,location.z);
        }
        
    }

    void OnCollisionEnter(Collision collision) {
        string name = collision.collider.name;
        //collid_state = 1;
        Debug.Log(name);
        if (name =="ob1(Clone)" ||name =="ob2(Clone)"||name=="ob3(Clone)"||name=="ob4(Clone)"||name=="ob5(Clone)")
        {
            Blood--;
            my_text.text="Blood Left:"+Blood.ToString();
            Debug.Log(collision.collider.name);
            Debug.Log("Crush!Blood to "+Blood.ToString());
        }
     }

     void Reborn()
     {
        Blood = 5;
        my_text.text="Blood Left:"+Blood.ToString();
        transform.position=new Vector3(0,0,0);
        obs = GameObject.Find("Obs");
        Destroy(obs);
        obs = new GameObject("Obs");
        Debug.Log("Restart the game!");
     }
}