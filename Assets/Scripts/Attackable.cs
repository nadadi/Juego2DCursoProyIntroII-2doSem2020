using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackable : MonoBehaviour
{
    #region CLASS_VARIABLES
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float currentHealth;
    [SerializeField]
    private List<BoxCollider2D> collider2Ds;
    #endregion

    #region UNITY_METHODS
    private void Start() {
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            ReceiveDamage(1.0f);
        }
    }

    private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            ReceiveDamage(1.0f);
        }
    }
    #endregion

    #region CLASS_METHODS
    public bool IsDead()
    {
        return (currentHealth <= 0f);
    }

    public void ReceiveDamage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth < 0f)
        {
            currentHealth = 0f;
            Debug.Log("ACABA DE MORIR EL ENEMIGO: " +gameObject.name);
            foreach (BoxCollider2D enemyCollider in collider2Ds)
            {
                enemyCollider.enabled = false;
            }
            Destroy(gameObject);
        }
            
    }
    #endregion
}
