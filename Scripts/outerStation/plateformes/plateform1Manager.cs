using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plateform1Manager : MonoBehaviour
{

    public outerSceneManager sceneManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter (Collider other)
        {
          if (other.tag == "Player"){
            if (sceneManager.getPlayerState()==1){
              sceneManager.setPlayerState(2);
            }
          }
        }

    // Update is called once per frame
    void Update()
    {

    }
}
