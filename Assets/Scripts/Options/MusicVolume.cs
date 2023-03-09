using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controla el volumen del menu de opciones, actualizando el objeto que contiene la música dependiendo de lo que el usuario a seleccionado
/// </summary>
public class MusicVolume : MonoBehaviour
{

    public Slider volumeSlider;
    public GameObject objMusic;

    private float volume = 0f;
    private AudioSource AudioSource;

    void Start()
    {
        objMusic = GameObject.FindWithTag("Music");
        AudioSource = objMusic.GetComponent<AudioSource>();

        volume = AudioSource.volume;
        volumeSlider.value = volume;
    }

    void Update()
    {
        AudioSource.volume = volume;
        PlayerPrefs.SetFloat("volume", volume);
    }

    public void VolumeUpdater()
    {
        volume = volumeSlider.value;
    }

    public void MusicReset()
    {
        PlayerPrefs.DeleteKey("volume");
        AudioSource.volume = 1;
        volumeSlider.value = 1;
    }
}
