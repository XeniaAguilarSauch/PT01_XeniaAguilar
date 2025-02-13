using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast_Script : MonoBehaviour
{
    private RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//sale un raycast desde la camara, como está adjuntada al personaje funciona igual(?)

        if(Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray, out hit))
            {
                Debug.Log("Hola");//Deberes: hacer que diga algo cuando toque un objeto en especifico
            }
        }
    }
}
