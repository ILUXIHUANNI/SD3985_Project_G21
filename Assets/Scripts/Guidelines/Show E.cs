using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class ShowE : MonoBehaviour
{
    [SerializeField] GameObject plant;
    Plant plantbool;
    [SerializeField] GameObject guidelines;

    bool isOpen = false;
    private void Awake()
    {
        plantbool = plant.GetComponent<Plant>();
    }

    private void Update()
    {
        if (plantbool.getCheck())
        {
            if (guidelines.active == false)
                guidelines.SetActive(true);
        }
    }
}
