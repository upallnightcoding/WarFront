using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBulletCntrl : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void AddForce(float shootForce)
    {
          rb.AddForce(gameObject.transform.forward * shootForce, ForceMode.Impulse);
    }
}