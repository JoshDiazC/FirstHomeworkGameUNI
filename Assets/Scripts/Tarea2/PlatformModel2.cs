using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformModel2 : MonoBehaviour
{
    public GameObject inf, sup;
    public float speed = 10f;
    public float moveLimitx = 1f;
    public float moveLimity = 10f;
    public float n;

    bool moveDirection = true;

    void Start()
    {
        n = Random.Range(0f, 1f);
        if (n <= 0.25f) inf.transform.localPosition = -moveLimitx * transform.right - moveLimity * transform.up;
        if (n > 0.25f && n <= 0.50f) inf.transform.localPosition = -moveLimitx * transform.right;
        if (n > 0.50f && n <= 0.75f) inf.transform.localPosition = -moveLimitx * transform.right + moveLimity * transform.up;
        if (n > 0.75f && n <= 1.00f) inf.transform.localPosition = -moveLimity * transform.up;
        sup.transform.localPosition = -inf.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (!moveDirection) transform.position = (Vector3.MoveTowards(transform.position, inf.transform.position, speed * Time.fixedDeltaTime));


        if (moveDirection) transform.position = (Vector3.MoveTowards(transform.position, sup.transform.position, speed * Time.fixedDeltaTime));


        if (transform.position == sup.transform.position)
        {
            moveDirection = !moveDirection;
        }
        else if (transform.position == inf.transform.position) moveDirection = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.parent = transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = null;
        }
    }
}
