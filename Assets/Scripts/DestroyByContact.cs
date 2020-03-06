using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;

    void OnCollisionEnter2D(Collision2D other)
    {
        // Create an explosion and position it properly
        Instantiate(explosion, transform.position, transform.rotation);
        // Destroy "this" object
        // Destroy the "other" object
        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }
}
