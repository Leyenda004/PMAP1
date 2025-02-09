using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorSonido : MonoBehaviour
{
    public static ControladorSonido Instance;
    [SerializeField] private AudioSource audioSource;
    private void Awake()
    {
        if (Instance != null && Instance != this) //patron singleton
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    public void ReproducirSonido(AudioClip sonido)
    {
        audioSource.PlayOneShot(sonido);
    }
    public void PararSonido()
    {
        audioSource.Stop();
    }
}
