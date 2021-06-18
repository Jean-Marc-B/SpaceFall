using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class parachuteManager : MonoBehaviour
{

    private static gameManager gameManager;
    public outerSoundManager soundManager;

    public JoystickMovementForOutter playerJoystickMovement;
    public SteamVR_Action_Boolean input;

    public AudioSource openParachuteSound;
    private bool canOpen = false;
    private bool parachuteOpened = false;
    // Start is called before the first frame update
    void Start()
    {
      gameManager = GameObject.Find("GameManager").GetComponent<gameManager>();
      this.gameObject.GetComponent<MeshRenderer>().enabled=false;
    }

    public void canOpenParachute(){
      canOpen = true;
    }

    public bool getParachuteOpened(){
      return parachuteOpened;
    }

    IEnumerator playCongratulationAfter1Sec(){
    yield return new WaitForSeconds(1);
    soundManager.playCongratulation();
    }

    private void openParachute()
    {
        canOpen = false;
        gameManager.addPosition(System.DateTime.Now, "Ouverture parachute");
        openParachuteSound.Play();
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
        playerJoystickMovement.gravity = 2;
        parachuteOpened = true;
        StartCoroutine(playCongratulationAfter1Sec());
    }

    // Update is called once per frame
    void Update()
    {
        if (canOpen == true && input.stateDown == true) {
            openParachute();
        }
    }
}
