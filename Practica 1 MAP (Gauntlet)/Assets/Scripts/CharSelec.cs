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
    [SerializeField] private GameObject screen;

    void Start()
    {
        EventSystem.current.SetSelectedGameObject(GetComponentsInChildren<Button>()[random.Next(0, 1)].gameObject); //mi mejor creación hasta la fecha
    }

    public void ValkyrieSelection()
    {
        screen.SetActive(false);
        SceneManager.LoadScene(1);
        GameManager.Instance.CharSelection("valkyrie");

    }
    public void  ElfSelection()
    {
        screen.SetActive(false);
        SceneManager.LoadScene(1);
        GameManager.Instance.CharSelection("valkyrie");

    }

}
