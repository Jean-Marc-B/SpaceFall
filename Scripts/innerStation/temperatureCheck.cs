using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temperatureCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    void OnTriggerStay(Collider other){
      if (other.tag == "Player" && sceneManager.temperatureCheck == true){
        sceneManager.playElectricProblemSound = true;
      }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
