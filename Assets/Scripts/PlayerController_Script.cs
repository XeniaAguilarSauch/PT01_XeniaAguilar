using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController_Script : MonoBehaviour
{
    public float speed;
    public float mouseSensivity;
    public float scaleStep;

    private float rotationX = 0f;
    private float rotationY = 0f;

    public Text textPosition;
    public Text textRotation;
    public Text textScale;

  

    // Start is called before the first frame update
    void Start()
    {
        //lo ponemos en el start porque es cuando se inicia
        Cursor.lockState= CursorLockMode.Locked; // Bloque el cursor en el centro de la pantalla
        Cursor.visible =false; //Oculta el cursor

    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        Rotacion();
        Escala();

       
        
       
        //paraque el personaje escale de tamaño cuando apriete la p aumente i cuando aptiete la m disminuya

        if (Input.GetKeyDown(KeyCode.P)) //Disminuir escala
        {
            transform.localScale += Vector3.one * scaleStep; 
            transform.localScale = new Vector3(Mathf.Max(transform.localScale.x, 0.2f), Mathf.Max(transform.localScale.y, 0.2f), Mathf.Max(transform.localScale.z, 0.2f));
        }






        if (textPosition != null && textRotation != null && textScale != null) 
        {
            textPosition.text = $"Position \nX: {transform.position.x:F2} \nY: {transform.position.y:F2} \nZ: {transform.position.z:F2}";
            textRotation.text = $"Rotacion \nX: {rotationX:F2} \nY: {rotationY:F2}";
            textScale.text = $"Scale \nX:{transform.localScale.x:F2} \nY:{transform.localScale.y:F2} \nZ:{transform.localScale.z:F2}"; 
            //Para mostrar en pantalla los numeros y que cambien
        }

    }

    public void Movimiento()
    {
         float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(moveX, 0, moveY);  //Mover personaje sin saltar sin girar camara

    }

    public void Rotacion()
    {
         //Rotacion con el mouse
        rotationX += Input.GetAxis("Mouse X") * mouseSensivity;
        rotationY -= Input.GetAxis("Mouse Y") * mouseSensivity;
        rotationY = Mathf.Clamp(rotationY, -90f, 90f); //Limita la rotacion
        transform.rotation = Quaternion.Euler(rotationY, rotationX, 0); //Hace que se ejecute bien lo anterior
        //Cogemos la posicion horizontal verticla que hace el mouse Y la sensibilidad que tiene
    }

    public void Escala()
    {
        //paraque el personaje escale de tamaño cuando apriete la p aumente i cuando aptiete la m disminuya

        if (Input.GetKeyDown(KeyCode.P)) //Disminuir escala
        {
            transform.localScale += Vector3.one * scaleStep; 
            transform.localScale = new Vector3(Mathf.Max(transform.localScale.x, 0.2f), Mathf.Max(transform.localScale.y, 0.2f), Mathf.Max(transform.localScale.z, 0.2f));
        }

    }
}
