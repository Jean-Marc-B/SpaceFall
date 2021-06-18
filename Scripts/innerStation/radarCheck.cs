using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radarCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    void OnTriggerStay(Collider other){
      if (other.tag == "Player" && sceneManager.radarCheck == true){
        sceneManager.playOverheatSound = true;
      }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
