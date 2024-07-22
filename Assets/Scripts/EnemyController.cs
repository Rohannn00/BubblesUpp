using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float normalSpeed = 5f; // Normal movement speed
    private float currentSpeed;
    private bool isSlowedDown = false;

    void Start()
    {
        currentSpeed = normalSpeed;
    }

    void Update()
    {
        // Move the enemy at the current speed
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
    }

    public void SlowDown(float factor)
    {
        if (!isSlowedDown)
        {
            currentSpeed *= factor; // Reduce the speed by the factor
            isSlowedDown = true;
        }
    }
    public void RestoreSpeed()
    {
        if (isSlowedDown)
        {
            currentSpeed = normalSpeed; // Restore the normal speed
            isSlowedDown = false;
        }
    }
}
