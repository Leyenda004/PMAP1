using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class selectionator : MonoBehaviour
{
    System.Random random = new System.Random(); // maldita ambigüedad que dolor de cabeza me ha dado
    GameObject Inputselector;

    void Start()
    {
        Inputselector = GameObject.FindGameObjectWithTag("InputSelector");

        DontDestroyOnLoad(Inputselector);
    }

    public void InputSelection(string choice)
    {
        Inputselector.name = choice;
        SceneManager.LoadScene(1);


    }
}
