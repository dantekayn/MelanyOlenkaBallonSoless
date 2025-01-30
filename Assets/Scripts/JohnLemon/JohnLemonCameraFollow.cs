using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    //zona de variables globales
    public Transform Target;
    [Header("Vectors")]
    //velocidad de seguimiento de la cámara
    [SerializeField]
    private float _smoothing;
    //distancia inicial que hay entre la cámara y el "player"
    [SerializeField]
    private Vector3 _offset;


    // Start is called before the first frame update
    void Start()
    {

        _offset = transform.position - Target.position;
        
    }

    private void LateUpdate()
    {
            
        //posición a la que queremos mover la cámara
        Vector3 desiredPosition = Target.position + _offset;

        //movemos la cámara
        transform.position = Vector3.Lerp(transform.position, desiredPosition, _smoothing *Time.deltaTime);

    }
}
