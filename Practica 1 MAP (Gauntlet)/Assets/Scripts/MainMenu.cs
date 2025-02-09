using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] AudioClip NormalMainMenu;
    [SerializeField] AudioClip MainMenuUponExit;
    void Start()
    {
        if (GameObject.FindAnyObjectByType<GameManager>() != null) ControladorSonido.Instance.ReproducirSonido(MainMenuUponExit);
        else ControladorSonido.Instance.ReproducirSonido(NormalMainMenu);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown) CargarNivel(2);
    }

    
    public void CargarNivel(int levelindex)
    {
        ControladorSonido.Instance.PararSonido();
        SceneManager.LoadScene(levelindex);

    }

}
