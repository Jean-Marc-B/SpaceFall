using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instructionParachute1 : MonoBehaviour
{
  public outerSceneManager sceneManager;
  public outerSoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter (Collider other)
        {
          if (other.tag == "Player"){
            if (sceneManager.getPlayerState()==11){
              soundManager.playInstructionParachute();
            }
          }
        }

    // Update is called once per frame
    void Update()
    {

    }
}
