using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    public int newscore;
    private GameController ob;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        
        if (gameControllerObject!= null)
        {
            ob=gameControllerObject.GetComponent<GameController>();
        }
    

        if (ob == null)
        {
            Debug.Log("Cannot find 'GameController script");
        }

    }
    
   
    
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);
        if (other.tag == "Boundary")
        {

            return;
        }




        Instantiate(explosion, transform.position, transform.rotation);

        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            ob.Add(-10);
            ob.gameOver();
        }
       
        ob.Add(newscore);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
