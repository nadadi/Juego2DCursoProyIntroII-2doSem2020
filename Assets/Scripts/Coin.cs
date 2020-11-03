using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private CapsuleCollider2D myCollider;

    // Se ejecuta 1 sola vez. Antes de cargar la escena.
    private void Awake() {
        myCollider = GetComponent<CapsuleCollider2D>();
    }

    //Se ejecuta 1 sola vez. Al cargar la escena, en el frame 1.
    private void Start() {
        //transform.localScale = new Vector3(3f, 3f, 3f);
    }

    // Se ejecuta por cada frame. 60fps -> 60 veces de ejecución por segundo. 
    // Nos sirve para actualizar el estado de los objetos.
    private void Update() {
        
    }

    // Se ejecuta cada 0.002 segundos. Nos sirve para trabajar las físicas. 
    private void FixedUpdate() {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if(other.gameObject.CompareTag("Player"))
        {
            // Ejecutar partículas, sonidos, aumentar el puntaje del jugador, etc....
            Destroy(this.gameObject);
        }else
        {
            Debug.Log("Choqué contra un elemento");
        }
    }
}
