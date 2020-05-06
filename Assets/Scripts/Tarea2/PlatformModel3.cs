using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformModel3 : MonoBehaviour
{
    MeshRenderer platformModel3MeshRenderer;
    Rigidbody rbd;

    private float t = 0f;
    public float lerpDuration = 2f;
    public bool touchPlatform = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rbd = this.GetComponent<Rigidbody>();
        platformModel3MeshRenderer = this.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (touchPlatform) 
        { 
            platformModel3MeshRenderer.material.color = Color.Lerp(platformModel3MeshRenderer.material.color, Color.red, t);
            if(t < 1f)
            {
                t += Time.deltaTime / lerpDuration;
            }
            else { t = 1f; }

            if (t == 1f)
            {
                StartCoroutine(Delay());
            }
        }
    }

    IEnumerator Delay()
    {
        rbd.isKinematic = false;
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            touchPlatform = true;           
        }
    }
}
