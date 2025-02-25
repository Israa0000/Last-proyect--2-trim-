using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Direction : MonoBehaviour
{
    Vector3 restPosition;
    Vector3 cursorPosition;
    Vector3 cursorWorldPosition;
    float angleToDirection;
    
    void Update()
    {
        //POSICION DEL PLAYER
        restPosition = new Vector3 (0,1,0);

        //POSICION DEL CURSOR 
        cursorPosition = Input.mousePosition;
        cursorWorldPosition = Camera.main.ScreenToWorldPoint(cursorPosition);
        cursorWorldPosition.z = 0;

        Vector3 direction = cursorWorldPosition - transform.position;

        //DIRECCION PLAYER - CURSOR
        angleToDirection = Vector3.SignedAngle(restPosition, direction, Vector3.forward);

        //PASAR EL EJE DE 'DIRECION - CURSOR' A LA ROTACION DEL PLAYER
        transform.rotation = Quaternion.Euler(0, 0, angleToDirection);

        print(cursorWorldPosition);
    }

}