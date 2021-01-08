using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
public class PlayerAttack : MonoBehaviour
{
    #region CLASS_VARIABLES
    [SerializeField]
    private float damage;
    private PlayerHealth playerHealth;
    #endregion

    #region UNITY_METHODS
    private void Awake() {
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("EnemyHeadCollider"))
        {
            Debug.Log("TRATANDO DE DESTRUIR UN ENEMIGO");    
            Attackable enemy = other.gameObject.GetComponent<Attackable>();
            if(enemy != null)
                ToCauseDamage(enemy);
        }

        if(other.gameObject.CompareTag("EnemyBodyCollider"))
        {
            Debug.Log("PERSONAJE DEBERÍA SER DESTRUIDO");    
            playerHealth.ReceiveDamage(1.0f);
        }
    }

    private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.CompareTag("EnemyHeadCollider"))
        {
            Debug.Log("TRATANDO DE DESTRUIR UN ENEMIGO");    
            Attackable enemy = other.gameObject.GetComponent<Attackable>();
            if(enemy != null)
                ToCauseDamage(enemy);
        }

        if(other.gameObject.CompareTag("EnemyBodyCollider"))
        {
            Debug.Log("PERSONAJE DEBERÍA SER DESTRUIDO");    
            playerHealth.ReceiveDamage(1.0f);
        }
    }

    /*private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("EnemyHeadCollider"))
        {
            Debug.Log("TRATANDO DE DESTRUIR UN ENEMIGO");    
            Attackable enemy = other.gameObject.GetComponent<Attackable>();
            if(enemy != null)
                ToCauseDamage(enemy);
        }

        if(other.gameObject.CompareTag("EnemyBodyCollider"))
        {
            Debug.Log("PERSONAJE DEBERÍA SER DESTRUIDO");    
            playerHealth.ReceiveDamage(1.0f);
        }
    }*/
    #endregion

    #region CLASS_METHODS
    public void ToCauseDamage(Attackable script)
    {
        script.ReceiveDamage(damage);
    }
    #endregion
}
