using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeParachute : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    void OnTriggerStay(Collider other){
      if (other.tag == "Hand" && sceneManager.canTakeParachute == true){
        foreach (Transform child in transform){
          child.GetComponent<MeshRenderer>().enabled=false;
        }
        sceneManager.playGetOutSound = true;
      }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
