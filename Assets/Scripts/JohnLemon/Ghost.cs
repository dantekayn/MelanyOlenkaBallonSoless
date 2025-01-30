using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{

    //zona de variables globales
    [Header("WayPoints")]
    //"Array" de posiciones para la patrulla del fantasma
    [SerializeField]
    private Transform[] _positionsArray;
    [SerializeField]
    private float _speed;
    //almacenar la posición a la que se dirige el fantasma
    private Vector3 _posToGo;
    //índice para controlar en qué posición (casilla) del "array" estoy
    private int _i;
    private Ray _ray;
    private RaycastHit _hit;

    public GameManager GameManagerScript;

    // Start is called before the first frame update
    void Start()
    {

        _i = 0;
        _posToGo = _positionsArray[_i].position;
        
    }

    private void FixedUpdate()
    {

        DetectionJohnLemon();

    }

    // Update is called once per frame
    void Update()
    {

        Move();
        ChangePosition();
        Rotate();
        
    }

    private void Move()
    {

        transform.position = Vector3.MoveTowards(transform.position, _posToGo, _speed * Time.deltaTime );

    }

    private void ChangePosition()
    {

        //si el fantasma ha llegado a su destino
        if(Vector3.Distance(transform.position, _posToGo) <= Mathf.Epsilon)
        {

            //comprobar si estoy en la última casilla del "array" ( elemento 1)
            //un "array" con dos elementos: el elemento 0 y el elemento 1
            if(_i == _positionsArray.Length - 1)
            {

                //vuelvo a la casilla inicial del "array"
                _i = 0;

            }
            else
            {

                _i++; // es igual a _i = _i + 1

            }

            _posToGo = _positionsArray[_i].position;

        }

    }

    private void Rotate()
    {

        transform.LookAt(_posToGo);

    }

    private void DetectionJohnLemon()
    {

        //subir el origen del ray 1 metro en el eje y con respecto al punto
        //de pivote del objeto
        _ray.origin = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
        _ray.direction = transform.forward;

        if(Physics.Raycast(_ray, out _hit))
        {

            if(_hit.collider.CompareTag("JohnLemon"))
            {

                Debug.Log("Soy el fantasma y te he pillado");
                GameManagerScript.IsPlayerCaught = true;

            }

        }

    }
}
