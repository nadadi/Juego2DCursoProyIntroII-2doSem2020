using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauseDamage : MonoBehaviour
{
    public float damage = 1f;

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();

            playerHealth.ReceiveDamage(damage);
        }
    }

    private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();

            playerHealth.ReceiveDamage(damage);
        }
    }
}
