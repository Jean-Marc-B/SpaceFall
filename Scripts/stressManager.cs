using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stressManager : MonoBehaviour
{

    public AudioSource heartBeatSound60;
    public AudioSource heartBeatSound110;

    private bool enableBeating = false;
    private int heartBeat = 60;
    private float length;

    // Start is called before the first frame update
    void Start()
    {
    }

    IEnumerator generateHeartBeat()
    {
        while(enableBeating){
          if (heartBeat<75){
            heartBeatSound60.Play();
          }
          else{
            heartBeatSound110.Play();
          }

          length = (float)(60.0/(float)heartBeat);
          yield return new WaitForSeconds(length);
        }
    }

    public void setHeartBeat(int newHeartBeat){
      heartBeat = newHeartBeat;
    }

    public void stopHeartBeating(){
      enableBeating = false;
    }

    public void startHeartBeating(){ //To start heartBeating
      if (enableBeating == false){
        enableBeating = true;
        StartCoroutine(generateHeartBeat()); //Instructions to check the radar
      }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
