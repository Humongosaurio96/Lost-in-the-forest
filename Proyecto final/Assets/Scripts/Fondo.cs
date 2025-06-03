using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;

public class Fondo : MonoBehaviour
{
    //Velocidad del efecto Paralax
    public float efectoParallax;

    //Variables para cargar la cámara
    //y la última posición de la misma
    private Transform camara;
    private Vector3 ultimaPosicionCamara;

    private void Start()
    {
        //obtiene la pcamara del juego
        camara=Camera.main.transform;
        //Carga la posición inicial de la camara
        ultimaPosicionCamara = camara.position;
    }

    //A este metodo se llama en cada Frame si Behaviourt está habilitado
    //Se recomienda para el uso de las cáramas
    private void LateUpdate()
    {
        //Carga en un vector de 3 ejes la diferencia entre posicion actual y ultima
        Vector3 movimientoFondo = camara.position-ultimaPosicionCamara;
        //mover la imagen a la que se asocia este script a un vector3 que contiene
        //el movimiento en X * la velocidad del efecto, y el movimiento Y lo mantiene
        transform.position += new Vector3(movimientoFondo.x * efectoParallax,
            movimientoFondo.y, 0);
        ultimaPosicionCamara=camara.position;
    }

}

