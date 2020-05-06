using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody rbd;
    MeshRenderer playerMeshRenderer;
    Color auxColor;
    public float x, z, rotSpeed = 90f, speed = 15f;
    public float jumpForce = 10f;
    public int jumpNumber = 1;
    public int Points = 0;

    private bool canJump = false;
    private int i = 0;
    private float t = 0f;
    private float auxSpeed, auxJump;

    private void Start()
    {
        rbd = GetComponent<Rigidbody>();
        auxSpeed = speed;
        auxJump = jumpForce;
        playerMeshRenderer = this.GetComponent<MeshRenderer>();
        auxColor = playerMeshRenderer.material.color;
    }

    private void Update()
    {
        // Aumentar velocidad.
       
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerMeshRenderer.material.color = Color.grey;
            speed *= 1.5f;
            jumpForce *= 0.7f;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            t += Time.deltaTime;
            if(t >= 3f)
            {
                speed = auxSpeed;
                jumpForce = auxJump;
                playerMeshRenderer.material.color = auxColor;

            }
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            playerMeshRenderer.material.color = auxColor;
            t = 0f;
            speed = auxSpeed;
            jumpForce = auxJump;
        }

        // Saltar cuando toca el piso
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            if (i >= jumpNumber) { canJump = false; }
            else
            {
                if(i >= 1) { jumpForce *= 0.5f; } else { jumpForce = auxJump; }
                rbd.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                i++;
            }
        }

        // Movimineto del jugador
        x = Input.GetAxis("Horizontal") * speed;
        z = Input.GetAxis("Vertical") * speed;
      
        // Rotar alrededor del eje Y
        if (Input.GetKey(KeyCode.E)) 
        {
            transform.RotateAround(transform.position, Vector3.up, rotSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.RotateAround(transform.position, Vector3.up, -rotSpeed * Time.deltaTime);
        }
    }
    

    private void FixedUpdate()
    {
        // Movimiento del jugador
        rbd.velocity = transform.right * x + transform.forward * z + transform.up * rbd.velocity.y;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Saltar cuando toca el piso
        if (collision.transform.CompareTag("Floor") || collision.transform.CompareTag("Platform") || collision.transform.CompareTag("MovilPlatform"))
        {
            i = 0;
            jumpNumber = 1;
            canJump = true;
        }

        if (collision.transform.CompareTag("FallingPlatform"))
        {
            i = 0;
            jumpNumber = 2;
            canJump = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Apple"))
        {
            Destroy(other.gameObject);
            Points++;
        }

        if (other.transform.CompareTag("DeathLimit"))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
