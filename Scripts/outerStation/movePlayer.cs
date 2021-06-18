using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{

    //private CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
      //characterController = GetComponent<CharacterController>();
    }

    public void teleportPlayer(Vector3 newPosition){
        //characterController.enabled = false;
        gameObject.transform.position = newPosition; //positions is a list that holds Vector3 positions
        //characterController.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
