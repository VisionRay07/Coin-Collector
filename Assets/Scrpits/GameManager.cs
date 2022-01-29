using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;
    public static GameManager inst;
    public Text scoree;
    public double energy;
    public Text eng;
    public float nextact = 0.0f;
    public float period = 0.5f;
    PlayerMovemnt playerMoment;

    public float timer;

    private void Awake()
    {
        inst = this;
    }
    void Start()
    {
        energy = 100;
        playerMoment = GameObject.FindObjectOfType<PlayerMovemnt>();
    }
    public void incr()
    {
        score++;
        scoree.text = "Score:" + score;
    }
    public void engincr()
    {
        energy++;
      //  eng.text = "Energy: " + energy;
    }

    // Update is called once per frame
    void Update()
    {
        nextact -= Time.deltaTime;
        if (nextact<=0)
        {
            nextact = period;
            energy = energy - 2;
           
        }
        if (energy == 0)
        {
            playerMoment.Die();
            

        }



        eng.text = "Energy:" + energy;
    }
    

}
