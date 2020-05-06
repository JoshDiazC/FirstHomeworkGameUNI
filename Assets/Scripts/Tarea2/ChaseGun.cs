using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseGun : MonoBehaviour
{
    public GameObject player, bullet, cannon;
    public float bulletSpeed = 40f;
    public float limit = 20f;
    Vector3 direction;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InstantiateBullet", 2, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {

        direction = (player.transform.position - transform.position);
        if (direction.magnitude <= limit)
        {
            transform.right = direction.normalized;
        }


    }

    void InstantiateBullet()
    {
        if (direction.magnitude <= limit)
        {
            GameObject auxBullet = Instantiate(bullet, cannon.transform.position, Quaternion.identity);


            auxBullet.transform.up = direction.normalized;
            auxBullet.GetComponent<Rigidbody>().velocity = direction.normalized * bulletSpeed;
        }

    }
}
