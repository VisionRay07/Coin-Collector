//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovemnt : MonoBehaviour
{
    bool alive = true;
    public float speed = 5;
    public Rigidbody rb;
    float horizontalInput;
    public float horizontalMultiplier = 2;
    public float jumpaount = 5;
    public LayerMask groundMask;

    private void FixedUpdate()
    {
        if (!alive) return;
        Vector3 forwardMove = transform.forward * speed * Time.deltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
        speed = speed + 0.001f;

    }
    public Transform foot;
    public float raduis;
    void Update()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        isGrounded = Physics.CheckSphere(foot.position, raduis, groundMask);

        horizontalInput = Input.GetAxis("Horizontal");
        if (transform.position.y < -5)
        {
            Die();

        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jump();
        }

    }
    public void Die()
    {
        alive = false;
        SceneManager.LoadSceneAsync(0);
       //nvoke("Restart", 2);

    }
    public bool isGrounded;
    void Restart()
    {
        SceneManager.LoadSceneAsync(0);
    }
    void jump()
    {


        rb.AddForce(Vector3.up * jumpaount);


    }
}
