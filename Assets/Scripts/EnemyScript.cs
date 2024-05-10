using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyScript : MonoBehaviour
{
    static public bool shouldApplyDamage = false;

    private GameObject Player;
    private Rigidbody EnemyRb;


    public bool TouchingPlayer = false;
    public float speed = 3f;

    void Start()
    {
        Player = GameObject.Find("Player");
        EnemyRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!TouchingPlayer && (Vector3.Distance(Player.transform.position, transform.position) < 20f))
        {
            Vector3 MoveDirection = (Player.transform.position - transform.position);
            EnemyRb.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            transform.LookAt(Player.transform);
        }
    }//moves enemies in the direction of the the player stops if they are too far

    //PLAYER COLLISION-------------------------------------------------------------------------------------------------------------
    private IEnumerator OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TouchingPlayer = true;
            yield return StartCoroutine(HitPlayer());
        }
    }//when the enemy collides with the Player the boolean (touching player) are set to true and we start the coroutine

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TouchingPlayer = false;
            shouldApplyDamage = false;
        }
    } //On collision exit put booleans to false

    IEnumerator HitPlayer()
    {
        while (TouchingPlayer == true)
        {
            yield return new WaitForSeconds(0.75f);
            if (!TouchingPlayer)
                break;
            Debug.Log("Apply damage to Player");
            shouldApplyDamage = true;
            PLayerAttributesController.currentHealth -= 1;
        }
    }//wait .75 seconds then check if the enemy and the player are still collided or not then sends message to deal damage

}
