using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressComputation : MonoBehaviour
{
    private static TCPServer tcpServer;
    private float threshold = 0.07f;
    public bool stressed;

    private void Start()
    {
        tcpServer = GameObject.Find("TCPServer").GetComponent<TCPServer>();
        stressed = false;
    }


    void Update()
    {
        float hrv = tcpServer.getLastHRV();
        if (hrv > -1) {
            if (hrv < threshold)
            {
                stressed = true;
            } else
            {
                stressed = false;
            }
        }
        if (Input.GetKeyDown("s"))
        {
            if (stressed)
            {
                stressed = false;
            } else
            {
                stressed = true;
            }
               

        }
    }
}
