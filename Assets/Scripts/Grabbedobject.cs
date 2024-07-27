using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Grabbedobject : MonoBehaviour
{
    [SerializeField] private Transform raypoint;
    [SerializeField] private Transform grabposition;

    private GameObject grabobject;
    [SerializeField] private float raydistance = 2f;
    private int layerindex;

    private void Start()
    {
        layerindex = LayerMask.NameToLayer("ObjectsToGrab");
    }
    //hitinfo.collider != null &&
    private void Update()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(raypoint.position, transform.right, raydistance);
        Debug.Log("hogyaaa");

        if ( hitinfo.collider.tag == "stone" && hitinfo.collider != null )
        {
            Debug.Log("hehehe");
            if (Keyboard.current.eKey.wasPressedThisFrame && grabobject == null)
            {
                grabobject = hitinfo.collider.gameObject; // we move game object intothe variable
                grabobject.GetComponent<Rigidbody2D>().isKinematic = true; // change setting to kinematic

                grabobject.transform.position = grabposition.position;
                grabobject.transform.SetParent(transform);

            }
            else if (Keyboard.current.eKey.wasPressedThisFrame)
            {

                grabobject.GetComponent<Rigidbody2D>().isKinematic = false;
                grabobject.transform.SetParent(null);
                grabobject = null;
            }
            Debug.DrawRay(raypoint.position, transform.right * raydistance);
        }
    }
}