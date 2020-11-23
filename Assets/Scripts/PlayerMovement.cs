using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    #region CLASS_VARIABLES
    [Range(5f,50f)] [SerializeField] 
    private float walkSpeed = 10f; 
    [Range(1f, 20f)] [SerializeField] 
    private float jumpForce = 100f;
    public bool _isJumping;  
    private Rigidbody2D _myRigidbody;
    private Animator _myAnimator;
    private float _horizontalAxisValue;
    private float _direction;
    #endregion   

    #region UNITY_METHODS
    private void Awake() {
        _myRigidbody = GetComponent<Rigidbody2D>();
        _myAnimator = GetComponent<Animator>();
        if(_myRigidbody == null)
            Debug.LogError("El gameobject " +gameObject.name + " NO posee un Rigidbody2D");
    }

    private void Start() {
        _isJumping = false; 
        _direction = 1;   
    }

    private void Update() {
        //Obteniendo un valor entre -1 y 1 (continuo)...
        _horizontalAxisValue = Input.GetAxis("Horizontal");

        if(_horizontalAxisValue != 0f){
            _myAnimator.SetBool("Running", true);
            _myAnimator.SetFloat("RunningSpeed", _horizontalAxisValue);
        }            
        else{
            _myAnimator.SetBool("Running", false);
            _myAnimator.SetFloat("IdleDirection", _direction);
        }

        //Obtenemos la tecla espacio
        if(Input.GetKeyDown(KeyCode.Space) && !_isJumping)
        {
            _isJumping = true;
            _myAnimator.SetBool("Jumping", true);
            _myRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);    
        }

        if(_horizontalAxisValue > 0)
            _direction = 1;
        else if(_horizontalAxisValue  < 0)
            _direction = -1;
    }

    private void FixedUpdate() {
        _myRigidbody.velocity = new Vector2(_horizontalAxisValue * walkSpeed, _myRigidbody.velocity.y);
    }   

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Platform"))
        {
            _isJumping = false;
            _myAnimator.SetBool("Jumping", false);
        }
    }
    #endregion
}
