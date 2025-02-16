using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
    [SerializeField]
    private GameObject ElfArrow;
    [SerializeField]
    private GameObject ValkyrieArrow;
    [SerializeField]
    private static string selectedChar;

    void Start()
    {
        

        GOSelector = GameObject.FindGameObjectWithTag("CharSelection");
        DontDestroyOnLoad(GOSelector);
    }

    public void CharSelection(string choice)
    {
        GOSelector.name = choice;
        SceneManager.LoadScene(3);

   
    }


        

}
