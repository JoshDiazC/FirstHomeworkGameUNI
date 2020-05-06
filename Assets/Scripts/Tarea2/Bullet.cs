using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            SceneManager.LoadScene("SampleScene");
        }

        if (other.transform.CompareTag("RyukEnemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
