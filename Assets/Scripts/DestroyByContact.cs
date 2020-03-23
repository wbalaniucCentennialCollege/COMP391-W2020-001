using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    [Header("Object Stats")]
    public int scoreValue = 10;
    [Header("Explosions")]
    public GameObject explosion;
    public GameObject explosionPlayer;

    // Private variables
    private GameController gameControllerComponent;

    private void Start()
    {
        // Find the object with the tag "GameController"
        GameObject gameControllerObj = GameObject.FindWithTag("GameController");

        if(gameControllerObj != null)
        {
            // Object exists! 
            // Find the GameController component on the GameController object
            gameControllerComponent = gameControllerObj.GetComponent<GameController>();
        }
        if(gameControllerComponent == null)
        {
            Debug.Log("Cannot find the game controller componnet");
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Create an explosion and position it properly
        Instantiate(explosion, transform.position, transform.rotation);

        if(other.gameObject.CompareTag("Player"))
        {
            Instantiate(explosionPlayer, other.transform.position, other.transform.rotation);
        }

        // Increment our score value
        gameControllerComponent.AddScore(scoreValue);

        // Destroy "this" object
        // Destroy the "other" object
        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }
}
