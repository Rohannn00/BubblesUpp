using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BalloonController : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public GameObject balloon;
    public Slider staminaBar;
    public float maxBlowForce = 15f;
    public float staminaDecreaseRate = 10f;
    public float staminaIncreaseRate = 5f;
    public float maxStamina = 100f;
    private float currentStamina;
    private bool isBlowingBalloon = false;
    private Vector3 originalBalloonScale;
    private Animator balloonAnimator;
    private Animator playerAnimator;
    private bool hasplayedanimation = false; 
    

    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = currentStamina;
        originalBalloonScale = balloon.transform.localScale;
        balloonAnimator = balloon.GetComponent<Animator>();
        playerAnimator = balloon.GetComponent<Animator>();
        balloon.SetActive(false);
    }

    void Update()
    {
        HandleBalloonBlowing();
        HandleStamina();
    }

    void HandleBalloonBlowing()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentStamina > 0)
        {
            isBlowingBalloon = true;
            balloon.SetActive(true);
            if (!hasplayedanimation)
            {
                balloonAnimator.SetTrigger("BlowBalloon");
                hasplayedanimation = true;
            }
            playerAnimator.SetBool("PlayerSwing",true);
            
        }

        if (Input.GetKey(KeyCode.Space) && isBlowingBalloon)
        {
            float blowStrength = Mathf.Clamp(currentStamina / maxStamina, 0, 1);
            balloon.transform.localScale = originalBalloonScale * blowStrength;
            playerRb.velocity = new Vector2(playerRb.velocity.x, maxBlowForce * blowStrength);
            playerRb.rotation = 0;
            currentStamina -= staminaDecreaseRate * Time.deltaTime;
            if (currentStamina < 0)
            {
                currentStamina = 0;
                StopBlowingBalloon();
            }
           
        }

        if (Input.GetKeyUp(KeyCode.Space) || currentStamina <= 0)
        {
            StopBlowingBalloon();
        }
    }

    void StopBlowingBalloon()
    {
        isBlowingBalloon = false;
        balloon.SetActive(false);
        balloon.transform.localScale = originalBalloonScale;
        hasplayedanimation= false;
       playerAnimator.SetBool("PlayerSwing",false);
    }

    void HandleStamina()
    {
        if (!isBlowingBalloon)
        {
            currentStamina += staminaIncreaseRate * Time.deltaTime;
            if (currentStamina > maxStamina)
            {
                currentStamina = maxStamina;
            }
        }
        staminaBar.value = currentStamina;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("StaminaBoost"))
        {
            currentStamina = Mathf.Min(currentStamina + 20f, maxStamina);
            Destroy(collision.gameObject);
        }


    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Platform"))
        {
            Debug.Log("Collided with Platform");
            StopBlowingBalloon();
            playerRb.velocity = new Vector2(playerRb.velocity.x, -maxBlowForce);
        }
    }
}
