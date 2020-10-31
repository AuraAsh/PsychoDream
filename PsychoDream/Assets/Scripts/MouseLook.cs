using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f; //Numero de velocidad del mouse, sensibilidad para moverse
    public Transform playerBody;
    float xRotation = 0f;
    // Start is called before the first frame update
    /*void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //Esconde cursor de la pantalla 
    }*/

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; //Eje 'x' preprogramado dentro de la unidad que cambiara segun el movimiento del mouse, controlando asi la velocidad del mouse * funcion de actualizacion del tiempo
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime; //Misma funcion eje 'y'

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //Valores dados para evitar rotacion en exceso

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); //Rotacion hacia arriba y abajo en el eje 'y'
        playerBody.Rotate(Vector3.up * mouseX); //Rotacion hacia los lados en el eje 'x'
    }
}
