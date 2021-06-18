using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBeating : MonoBehaviour
{

    public AudioSource heartBeatSound60;
    public AudioSource heartBeatSound110;

    private static TCPServer tcpServer;

    private bool enableBeating = false;
    public int heartBeat;
    private float length;

    IEnumerator generateHeartBeat()
    {
        while (enableBeating)
        {
            if (heartBeat < 75)
            {
                heartBeatSound60.Play();
            }
            else
            {
                heartBeatSound110.Play();
            }

            length = (float)(60.0 / (float)heartBeat);
            yield return new WaitForSeconds(length);
        }
    }

    public void setHeartBeat(int newHeartBeat)
    {
        heartBeat = newHeartBeat;
    }

    public void stopHeartBeating()
    {
        enableBeating = false;
    }

    public void startHeartBeating()
    { //To start heartBeating
        if (enableBeating == false)
        {
            enableBeating = true;
            StartCoroutine(generateHeartBeat()); //Instructions to check the radar
        }
    }

    private void Update()
    {
        if (tcpServer.getLastHR() > -1)
        {
            heartBeat = tcpServer.getLastHR();
        } else
        {
            heartBeat = 60;
        }
    }

    private void Start()
    {
        tcpServer = GameObject.Find("TCPServer").GetComponent<TCPServer>();
    }
}

