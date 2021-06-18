using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class openBox : MonoBehaviour
{

  private static gameManager gameManager;
  private Animator _animator;
  public AudioSource openDoorSound;
  public SteamVR_Action_Boolean input;
  private bool canOpen = false;
  private bool opened = false;
    // Start is called before the first frame update
    void Start()
    {
      gameManager = GameObject.Find("GameManager").GetComponent<gameManager>();
      _animator = GetComponent<Animator>();
    }

    public void canOpenBox(){
      canOpen = true;
    }

    void openDoorSoundPlay(){
      openDoorSound.Play();
    }

    void OnTriggerStay(Collider other){
        if ((other.tag == "Hand") && (canOpen == true) && (opened == false) && (input.stateDown == true))
        {
        opened = true;
        gameManager.addPosition(System.DateTime.Now, "Ouverture de l'armoire electrique");
        _animator.SetBool("open", true);
      }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
