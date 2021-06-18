using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Valve.VR;

public class exitStation : MonoBehaviour
{
  private Animator _animator;
  public AudioSource openDoorSound;
  public AudioSource handlePushSound;
   public SteamVR_Action_Boolean input;
    // Start is called before the first frame update
    void Start()
    {
      _animator = GetComponent<Animator>();
    }

    void openDoorSoundPlay(){
      openDoorSound.Play();
    }

    void handlePushSoundPlay(){
      handlePushSound.Play();
    }

    void launchTheNextScene(){
      SceneManager.LoadScene("outerStation");
    }


    void OnTriggerStay(Collider other){
      if (other.tag == "Hand" && sceneManager.canGoOut == true && input.stateDown == true)
        {
        _animator.SetBool("open", true);
      }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
