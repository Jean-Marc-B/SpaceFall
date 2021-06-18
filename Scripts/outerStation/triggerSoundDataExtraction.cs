using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerSoundDataExtraction : MonoBehaviour
{

  public outerSoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerStay(Collider other){
      if (other.tag == "Player"){
        soundManager.triggerDataExtractionInstruction();
      }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
