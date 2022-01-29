using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerMovemnt playerMoment;
    void Start()
    {
        playerMoment = GameObject.FindObjectOfType<PlayerMovemnt>();
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            playerMoment.Die();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
