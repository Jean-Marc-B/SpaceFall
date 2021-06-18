using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerSoundOpenBox : MonoBehaviour
{

  public outerSoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerStay(Collider other){
      if (other.tag == "Player"){
        soundManager.triggerOpenBoxInstruction();
      }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
