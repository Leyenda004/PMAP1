using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIkeyBehaviour : MonoBehaviour
{
    [SerializeField] GameObject[] keysUi;
    void Start()
    {
        print(keysUi[0].name);
        print(keysUi[1].name);
        EvaluateKeys(0);
    }

    public void EvaluateKeys(int keyAmmount)
    {
        if (keyAmmount == 0)
        {
            keysUi[0].SetActive(false);
            keysUi[1].SetActive(false);
        }
        else if (keyAmmount == 1)
        {
            keysUi[0].SetActive(true);
            keysUi[1].SetActive(false);
        }
        else if (keyAmmount == 2)
        {
            keysUi[0].SetActive(true);
            keysUi[1].SetActive(true);
        }
    }
}
