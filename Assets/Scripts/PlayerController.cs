using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables
    public float speed;
    public float minX, maxX, minY, maxY;
    public GameObject laser;
    public Transform laserSpawn;
    public float fireRateDelay = 0.25f;

    private Rigidbody2D rBody;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        rBody.velocity = new Vector2(horiz, vert) * speed;

        rBody.position = new Vector2(
            Mathf.Clamp(rBody.position.x, minX, maxX),
            Mathf.Clamp(rBody.position.y, minY, maxY));
    }

    void Update()
    {
        // 1. Check for user input
        if(Input.GetAxis("Fire1") > 0 && timer > fireRateDelay)
        {
            // 2. Create the object (instantiate)
            GameObject gObj = Instantiate(laser, laserSpawn.transform.position, laserSpawn.transform.rotation);
            gObj.transform.Rotate(0, 0, -90);

            // Reset timer
            timer = 0;
        }

        timer += Time.deltaTime;
    }
}
