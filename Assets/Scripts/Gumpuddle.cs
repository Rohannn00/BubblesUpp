using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gumpuddle : MonoBehaviour
{
    private float puddlelifetime = 5f;
    private float Slowdownfactor = 0.5f;

    void Start()
    {
        Destroy(gameObject, puddlelifetime);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyController enemy = other.GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.SlowDown(Slowdownfactor);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyController enemy = other.GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.RestoreSpeed();
            }
        }
    }
}