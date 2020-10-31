using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 8f;
    public float gravity = -9.81f;
    Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z; //Direccion en la que queremos movernos en funcion x y z

        controller.Move(move * speed * Time.deltaTime); //Movimiento basado en las cordenadas locales del jugador

        velocity.y += gravity * Time.deltaTime; //Aumentar velocidad con base en el numero de gravedad
        controller.Move(velocity * Time.deltaTime); //Movimiento en funcion de la velocidad
        
    }
}
