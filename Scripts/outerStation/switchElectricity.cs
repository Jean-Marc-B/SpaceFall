using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class switchElectricity : MonoBehaviour
{

  private static gameManager gameManager;
  public outerSceneManager sceneManager;
  public enableFire fire;
  public electricArc elec;
  public SteamVR_Action_Boolean input;

  private Animator _animator;
  public AudioSource powerDownSound;
  public AudioSource switchSound;
  public AudioSource alarmSound;

  private bool down = false;
    // Start is called before the first frame update
    void Start()
    {
      gameManager = GameObject.Find("GameManager").GetComponent<gameManager>();
      _animator = GetComponent<Animator>();
    }

    void powerDownSoundPlay(){
      powerDownSound.Play();
    }

    void switchSoundPlay(){
      switchSound.Play();
    }

    //Stops alarm sound and launch fire
    void stopAlarmSound(){
      alarmSound.Stop();
      fire.launchFire();
      elec.launchElectricArc();
    }

    void OnTriggerStay(Collider other){
      if ((other.tag == "Hand") && (down == false) && (input.stateDown == true)){
        down = true;
        gameManager.addPosition(System.DateTime.Now, "Switch electrique dessendu");
        _animator.SetBool("turnDown", true);
        sceneManager.electicityPulledDown();
        sceneManager.setPlayerState(7);
      }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
