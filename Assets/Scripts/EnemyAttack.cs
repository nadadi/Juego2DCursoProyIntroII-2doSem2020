using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EnemyAttack : MonoBehaviour
{
    #region CLASS_VARIABLES
    [SerializeField]
    [Range(0f,2f)]
    private float verticalDistanceToRays = 0.5f;
    [SerializeField]
    [Range(0f,2f)]
    private float minAttackDistance = 0.5f;
    private Vector2 upperPointToAttack;
    private Vector2 middlePointToAttack;
    private Vector2 lowerPointToAttack;
    private EnemyHorizontalPatrolling enemyMovement;
    private bool isAttacking; 
    private SpriteRenderer myRenderer;
    #endregion

    #region UNITY_METHODS
    private void Awake() {
        enemyMovement = GetComponent<EnemyHorizontalPatrolling>();
        myRenderer = GetComponent<SpriteRenderer>();
        upperPointToAttack = new Vector2(transform.position.x, transform.position.y + verticalDistanceToRays);
        middlePointToAttack = new Vector2(transform.position.x, transform.position.y);
        lowerPointToAttack = new Vector2(transform.position.x, transform.position.y - verticalDistanceToRays);
    }

    private void Start() {
        isAttacking = false;
    }

    private void Update() {
        if(enemyMovement == null)
            return;

        upperPointToAttack = new Vector2(transform.position.x, transform.position.y + verticalDistanceToRays);
        middlePointToAttack = new Vector2(transform.position.x, transform.position.y);
        lowerPointToAttack = new Vector2(transform.position.x, transform.position.y - verticalDistanceToRays);

        if(enemyMovement.IsFacingRight())
        {
            RaycastHit2D upperHit = Physics2D.Raycast(upperPointToAttack, Vector2.right, minAttackDistance);
            RaycastHit2D middleHit = Physics2D.Raycast(middlePointToAttack, Vector2.right, minAttackDistance);
            RaycastHit2D lowerHit = Physics2D.Raycast(lowerPointToAttack, Vector2.right, minAttackDistance);
            if(middleHit.collider != null)
            {
                if(middleHit.collider.CompareTag("Player"))
                {
                    isAttacking = true;
                    enemyMovement.StopMovement();
                    myRenderer.color = Color.red;    
                }
            }
            /*if(upperHit.collider.CompareTag("Player") || middleHit.collider.CompareTag("Player") 
                || lowerHit.collider.CompareTag("Player"))
            {
                isAttacking = true;
                enemyMovement.StopMovement();
                myRenderer.color = Color.red;
            }*/
        }else
        {
            RaycastHit2D upperHit = Physics2D.Raycast(upperPointToAttack, Vector2.left, minAttackDistance);
            RaycastHit2D middleHit = Physics2D.Raycast(middlePointToAttack, Vector2.left, minAttackDistance);
            RaycastHit2D lowerHit = Physics2D.Raycast(lowerPointToAttack, Vector2.left, minAttackDistance);
            /*if(upperHit.collider.CompareTag("Player") || middleHit.collider.CompareTag("Player") 
                || lowerHit.collider.CompareTag("Player"))
            {
                isAttacking = true;
                enemyMovement.StopMovement();
                myRenderer.color = Color.red;
            }*/
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(upperPointToAttack, 0.1f);
        Gizmos.DrawSphere(middlePointToAttack, 0.1f);
        Gizmos.DrawSphere(lowerPointToAttack, 0.1f);
        if(enemyMovement != null)
        {
            if(enemyMovement.IsFacingRight())
            {
                Gizmos.DrawLine(upperPointToAttack, upperPointToAttack + Vector2.right);
                Gizmos.DrawLine(middlePointToAttack, middlePointToAttack + Vector2.right);
                Gizmos.DrawLine(lowerPointToAttack, lowerPointToAttack + Vector2.right);
            }else
            {
                Gizmos.DrawLine(upperPointToAttack, upperPointToAttack + Vector2.left);
                Gizmos.DrawLine(middlePointToAttack, middlePointToAttack + Vector2.left);
                Gizmos.DrawLine(lowerPointToAttack, lowerPointToAttack + Vector2.left);
            }
        }else
        {
            Awake();
        }
    }
    #endregion

    #region CLASS_METHODS
        
    #endregion
}
