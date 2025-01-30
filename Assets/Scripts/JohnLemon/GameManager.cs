using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    //zona de variables globales
    [Header("Images")]
    [SerializeField]
    private Image _caughtImage;
    [SerializeField]
    private Image _wonImage;
    [Header("Fade")]
    //la duración del "fade" de la imagen
    //(que va a aparecer poco a poco)
    [SerializeField]
    private float _fadeDuration;
    //el total del tiempo que voy a dejar la imagen en la pantalla
    [SerializeField]
    private float _displayImageDuration;
    //contador de tiempo
    private float _timer;

    //para saber si el player ha llegado a la salida
    public bool IsPlayerAtExit;
    //para saber si han pillado "player"
    public bool IsPlayerCaught;

    [Header("Audio")]
    [SerializeField]
    private AudioClip _caughtClip;
    [SerializeField]
    private AudioClip _wonClip;
    private AudioSource _audioSource;

    [SerializeField]
    private GameObject _button;

    private void Awake()
    {
        
        _audioSource = GetComponent<AudioSource>();
        _button.SetActive(false);

    }


    // Update is called once per frame
    void Update()
    {
        
        if(IsPlayerAtExit)
        {

            Won();

        }
        else if(IsPlayerCaught)
        {

            Caught();

        }
    }

    public void Restart()
    {

        SceneManager.LoadScene("JohnLemon");

    }


    private void Won()
    {
        _button.SetActive(true);
        _audioSource.clip = _wonClip;
        if (_audioSource.isPlaying == false)
        {

            _audioSource.Play();

        }

        _timer = _timer + Time.deltaTime;
        //aumentar el canal alfa de la imagen poco a poco
        _wonImage.color = new Color(_wonImage.color.r, _wonImage.color.g, _wonImage.color.b, _timer/_fadeDuration);

        //la imagen se queda durante un tiempo
        if(_timer > _fadeDuration + _displayImageDuration)
        {

            Debug.Log("He ganado");

        }

    }

    private void Caught()
    {

        _audioSource.clip = _caughtClip;
        if (_audioSource.isPlaying == false)
        {

            _audioSource.Play();

        }

        _timer = _timer + Time.deltaTime;
        //aumentar el canal alfa de la imagen poco a poco
        _caughtImage.color = new Color(_caughtImage.color.r, _caughtImage.color.g, _caughtImage.color.b, _timer/_fadeDuration);

        //la imagen se queda durante un tiempo
        if (_timer > _fadeDuration + _displayImageDuration)
        {

            Debug.Log("He perdido");
            SceneManager.LoadScene("JohnLemon");

        }

    }

}
