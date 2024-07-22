using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gumprojectile : MonoBehaviour
{

    [SerializeField] private GameObject Puddleprefab; // to create puddle on collision
    [SerializeField] private float slowdownfactor = 1f; // slowing down enemy speed




    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collided with enemy: " + collision.gameObject.name);
            // Optionally destroy the gum projectile
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Collided with ground: " + collision.gameObject.name);
            // Create gum puddle at the collision point
            Instantiate(Puddleprefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }


    }
}


