using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temperatureCheck2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    void OnTriggerStay(Collider other){
      if (other.tag == "Player" && sceneManager.temperatureCheck2 == true){
        sceneManager.playParachuteSound = true;
      }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
