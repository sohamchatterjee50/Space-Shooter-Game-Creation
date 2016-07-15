using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameController : MonoBehaviour {
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait; 
    public float waveWait;
    public Text text;
    private int score;
    public Text gameover;
    private bool go;
    public Text restart;
    private bool res;
    void Start()
    {
        gameover.text = "";
        restart.text = "";
        go = false;
        res = false;
        score = 0;
        UpdateScore();
    StartCoroutine(spawnWaves());

    }

    void Update()
    {

        if (res)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }

        }

    }



    IEnumerator spawnWaves()
    {
        while (true)
        {
            yield return new WaitForSeconds(startWait);
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawn = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion q = Quaternion.identity;
                Instantiate(hazard, spawn, q);
               yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if (go)
            {
                restart.text="Press R to restart";
                res=true;
                break;
            }
        
        
        }
    }

   public void Add(int newscore)
    {
        score += newscore;
        UpdateScore();

    }

    
     void UpdateScore()
    {

        text.text = "Score: " + score;


    }

   public  void gameOver()
     {
         gameover.text ="GAME  OVER";
         go = true;

     }



}
