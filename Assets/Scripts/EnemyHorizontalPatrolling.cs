using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyHorizontalPatrolling : MonoBehaviour
{
    #region CLASS_VARIABLES
    [SerializeField]
    [Range(1f, 10f)]
    private float distanceToPatrol = 2.0f;
    [SerializeField]
    [Range(0.0f, 1.0f)]
    private float minDistanceToChangeDirection = 0.2f;
    [SerializeField]
    [Range(0f, 5.0f)]
    private float movementSpeed = 5.0f;
    private Vector2 rightPoint;
    private Vector2 leftPoint;
    private Vector2 goalPoint;
    private Vector2 currentDirection;
    private Rigidbody2D myRigidbody;
    private float initialMovementSpeed;
    #endregion

    #region UNITY_METHODS    
    private void Awake() {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        // Calculando los valores de la derecha e izquierda.
        initialMovementSpeed = movementSpeed;
        rightPoint = new Vector2(transform.position.x + distanceToPatrol, transform.position.y); 
        leftPoint = new Vector2(transform.position.x - distanceToPatrol, transform.position.y); 
        goalPoint = (Random.Range(0,2) == 0)?rightPoint:leftPoint;
        currentDirection = (goalPoint - (Vector2)transform.position).normalized;
        /* -> if(Random.Range(0,2) == 0) 
                {
                    goalPoint = rightPoint;
                }
                else
                {
                    goalPoint = leftPoint;
                }
        */
    }

    private void Update() {
        float currentDistanceToGoalPoint = Vector2.Distance(transform.position, goalPoint);

        if(currentDistanceToGoalPoint <= minDistanceToChangeDirection)
        {
            if(goalPoint == rightPoint)
                goalPoint = leftPoint;
            else
                goalPoint = rightPoint;
            currentDirection = (goalPoint - (Vector2)transform.position).normalized;
        }
    }

    private void FixedUpdate() {
        myRigidbody.velocity = currentDirection * movementSpeed;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(rightPoint, 0.5f);
        Gizmos.DrawSphere(leftPoint, 0.5f);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + minDistanceToChangeDirection, transform.position.y, 0f));
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x - minDistanceToChangeDirection, transform.position.y, 0f));
    }
    #endregion

    #region CLASS_METHODS
    public bool IsFacingRight()
    {
        return (goalPoint == rightPoint)?true:false;
    }

    public void StopMovement()
    {
        movementSpeed = 0;
    }
    #endregion
}
