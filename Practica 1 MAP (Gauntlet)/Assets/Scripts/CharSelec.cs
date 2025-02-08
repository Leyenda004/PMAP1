using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharSelec : MonoBehaviour
{
    System.Random random = new System.Random(); // maldita ambigüedad que dolor de cabeza me ha dado
    GameObject GOSelector;

    void Start()
    {
        GOSelector = GameObject.FindGameObjectWithTag("CharSelection");
        EventSystem.current.SetSelectedGameObject(GetComponentsInChildren<Button>()[random.Next(0, 1)].gameObject); //mi mejor creación hasta la fecha
        DontDestroyOnLoad(GOSelector);
    }

    public void CharSelection(string choice)
    {
        GOSelector.name = choice;
        SceneManager.LoadScene(1);



    }

}
