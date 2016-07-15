using UnityEngine;
using System.Collections;
[System.Serializable]
 public class Boundary
{
    public float xmin, xmax, zmin, zmax;
}
public class PlayerController : MonoBehaviour
{

    public float speed;
    public float tilt;  
     public Boundary boundary;
     public GameObject shot;
     public Transform shotspawn;
     private float nextfire;
     public float firerate;
     void Update()
     {
         if (Input.GetButton("Fire1") && Time.time > nextfire)
         {

             nextfire = Time.time + firerate;
             Instantiate(shot, shotspawn.position, shotspawn.rotation);
             GetComponent<AudioSource>().Play();

         }

     }


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().velocity = movement*speed;
        GetComponent<Rigidbody>().position = new Vector3(Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xmin, boundary.xmax), 0.0f, Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zmin, boundary.zmax));

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);


    }
}