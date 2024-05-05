using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerAttributesController : MonoBehaviour
{
    public GameObject ShieldEffect;
    public HealthBar healthBar;
    public bool isShiftPressed = false;
    public static int currentHealth;
    public int MaxHealth = 5;

    // Start is called before the first frame update
    void Start()
    {
        ShieldEffect.SetActive(false);
        healthBar.SetMaxHealth(MaxHealth);
        currentHealth = MaxHealth;
        healthBar.SetHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            isShiftPressed = true;
        else if (Input.GetKeyUp(KeyCode.LeftShift))
            isShiftPressed = false;

        PlayerController.speedforward = isShiftPressed ? 15 : 10;
    }

    private void LateUpdate()
    {
        if (EnemyScript.shouldApplyDamage && ShieldEffect.activeSelf)
        {
            PLayerAttributesController.currentHealth += 1;
            ShieldEffect.SetActive(false);
        }
        else if (EnemyScript.shouldApplyDamage && !ShieldEffect.activeSelf && currentHealth > 0)
            healthBar.SetHealth(currentHealth); // reduces the healthbar
        else if (EnemyScript.shouldApplyDamage && !ShieldEffect.activeSelf && currentHealth == 0)
        {
            healthBar.SetHealth(currentHealth);
            Debug.Log("GameOver");
            Time.timeScale = 0; //stops the game
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ShieldPotion"))
        {
            other.gameObject.SetActive(false);
            ShieldEffect.SetActive(true);
            StartCoroutine(ShieldEffTime());
        }
        else if (other.CompareTag("Mead"))
        {
            if (currentHealth != MaxHealth)
            {
                other.gameObject.SetActive(false); 
                healthBar.SetHealth(currentHealth += 1);
                Debug.Log("player drank mead and regenerated health");
            }
        }
    }//if player picks up potion , this activates the "effect"

    IEnumerator ShieldEffTime()
    {
        Debug.Log("Shield effect is wearing off in 7");
        yield return new WaitForSeconds(7.5f);
        Debug.Log("Shield effect is gone");
        ShieldEffect.SetActive(false);
    }//removes the "effect" after 7.5 seconds
}
