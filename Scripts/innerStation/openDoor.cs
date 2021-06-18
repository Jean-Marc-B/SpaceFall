using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
  private Animator _animator;
  public AudioSource openDoorSound;
  public AudioSource closeDoorSound;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void closeDoorSoundPlay(){
      closeDoorSound.Play();
    }

    void openDoorSoundPlay(){
      openDoorSound.Play();
    }

    void OnTriggerEnter(Collider other){
      if (other.tag == "Player"){
        _animator.SetBool("open", true);
      }
    }

    void OnTriggerExit(Collider other){
      if (other.tag == "Player"){
        _animator.SetBool("open", false);
      }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
