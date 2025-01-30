using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    //zona de variables globales
    public Transform Target;
    [Header("Vectors")]
    //velocidad de seguimiento de la c�mara
    [SerializeField]
    private float _smoothing;
    //distancia inicial que hay entre la c�mara y el "player"
    [SerializeField]
    private Vector3 _offset;


    // Start is called before the first frame update
    void Start()
    {

        _offset = transform.position - Target.position;
        
    }

    private void LateUpdate()
    {
            
        //posici�n a la que queremos mover la c�mara
        Vector3 desiredPosition = Target.position + _offset;

        //movemos la c�mara
        transform.position = Vector3.Lerp(transform.position, desiredPosition, _smoothing *Time.deltaTime);

    }
}
