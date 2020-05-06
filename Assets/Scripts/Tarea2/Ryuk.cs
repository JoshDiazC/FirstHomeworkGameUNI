using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ryuk : MonoBehaviour
{
    public GameObject Player;
    public float Speed = 7f;
    public float Limit = 2000f;
    private float t = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t >= 3f)
        {
            Vector3 direction = Player.transform.position - this.transform.position;
            Vector3 aux = this.transform.position;
            if (direction.magnitude <= Limit)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, Player.transform.position, Speed * Time.deltaTime);
            }
            else { this.transform.position = aux; }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
