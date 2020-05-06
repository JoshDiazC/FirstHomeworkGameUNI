using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseOnePlatform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Escoje un modelo de la plataforma.
        int randomIndex = Random.Range(0, transform.childCount);
        // (prueba) int randomIndex = 2;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == randomIndex);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
