using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    #region CLASS_VARIABLES
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float currentHealth;
    #endregion

    #region UNITY_METHODS
    private void Awake() {
        
    }

    private void Start() {
        currentHealth = maxHealth;
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
            Debug.Log("GAME OVER");
            SceneManager.LoadScene("Level 1");
        }
            
    }
    #endregion
}
