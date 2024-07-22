using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public GameObject gumPrefab; // Gum projectile prefab
    public Transform firePoint;  // Point from where gum is spit
    public Vector2 spitVelocity = new Vector2(2f, 5f); // Initial velocity for projectile motion
    public float firecooldown = 0.5f;
    private float lastfiretime = 0f;
    private bool facingRight = true; // Track which way the player is facing
   
    void Update()
    {
        // Check for player input to flip the player
        if (Input.GetKeyDown(KeyCode.A))
        {
            Flip(false); // Flip player to face left
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Flip(true); // Flip player to face right
        }

        // Check for player input to spit gum
        if (Input.GetMouseButton(0) && Time.time >= lastfiretime + firecooldown)
        {


            SpitGum();
            lastfiretime = Time.time;
        }
    }

    // Flip the player horizontally
    void Flip(bool faceRight)
    {
        if (facingRight != faceRight)
        {
            facingRight = faceRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1; // Invert the x scale to flip the player
            transform.localScale = scale;
        }
    }

    // Spit gum with a projectile motion
    void SpitGum()
    {
        // Instantiate the gum projectile
        GameObject gum = Instantiate(gumPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = gum.GetComponent<Rigidbody2D>();

        // Apply initial velocity for the gum projectile
        Vector2 velocity = spitVelocity;
        velocity.x *= (facingRight ? 1 : -1); // Adjust direction based on player's facing direction
        rb.velocity = velocity;
    }

}
