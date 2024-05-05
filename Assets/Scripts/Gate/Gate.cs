using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] GameObject plant;
    Gateplant plantBool;

    private void Awake()
    {
        plantBool = plant.GetComponent<Gateplant>();
    }

    private void Update()
    {
        OpenGate();
    }

    void OpenGate()
    {
        Vector2 stopPos = new Vector2(-35.55f, 16.03f);
        float dis = (stopPos - (Vector2)transform.position).magnitude;
        if (plantBool.getCheck())
        {
            if (dis >= 0.3f)
            {
                transform.position += new Vector3(0, 12f, 0) * Time.deltaTime;
            }
        }
        else
        {
            if ( dis <= 5.39f)
            {
                transform.position += new Vector3(0, -12f, 0) * Time.deltaTime;
            }
        }
    }
}
