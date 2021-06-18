using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instructionParachute2 : MonoBehaviour
{
  public outerSceneManager sceneManager;
  public outerSoundManager soundManager;
  public parachuteManager parachute;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter (Collider other)
        {
          if (other.tag == "Player"){
            if (sceneManager.getPlayerState()==11){
              soundManager.playOpenParachute();
              parachute.canOpenParachute();
            }
          }
        }

    // Update is called once per frame
    void Update()
    {

    }
}
