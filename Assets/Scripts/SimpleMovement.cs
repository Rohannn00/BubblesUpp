using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Windows.Speech;


public class SimpleMovement : MonoBehaviour
{
   
    public Rigidbody2D rb;
    public float  Speed;
    private float Move;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move = Input.GetAxis("Horizontal");
        rb.velocity= new Vector2(Move*Speed, rb.velocity.y);

       
    }

   

  

}
