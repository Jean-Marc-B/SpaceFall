using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outerSceneManager : MonoBehaviour
{
    private static gameManager gameManager;
    public outerSoundManager soundManager;
    public openBox box;
    public movePlayer playerToMove;
    public checkJump jump;
    public explosion explosion;

    //State of the Player
    private int playerState = 1;


    // Start is called before the first frame update
    void Start()
    {
      gameManager = GameObject.Find("GameManager").GetComponent<gameManager>();
      gameManager.addPosition(System.DateTime.Now, "Debut de outer Station");
      StartCoroutine(playInitialInstructionsAfter1sec()); //Instructions to turn down electricity
    }

    public int getPlayerState(){
      return playerState;
    }

    public void setPlayerState(int number){
        gameManager.addPosition(System.DateTime.Now, "Etape : " + number);
        playerState = number;
        Debug.Log("Etape : " + number);
    }

    //Checkpoints reload, change position of player and state :
    void checkpoint1(){
      gameManager.addPosition(System.DateTime.Now, "Respawn checkpoint 1 : etat 1");
      setPlayerState(1);
      playerToMove.teleportPlayer(new Vector3(91.31f, 302.67f, -77.66f));
    }

    void checkpoint2(){
      gameManager.addPosition(System.DateTime.Now, "Respawn checkpoint 2 : etat 6");
        if (playerState >= 7)
        {
            setPlayerState(7);
        } else
        {
            setPlayerState(6);
        }
      
      playerToMove.teleportPlayer(new Vector3(28.74348f, 169.7636f, -74.47533f));
    }

    void checkpoint3(){
      gameManager.addPosition(System.DateTime.Now, "Respawn checkpoint 3 : etat 11");
      setPlayerState(11);
      playerToMove.teleportPlayer(new Vector3(64.26083f, 65.72979f, -108.4133f));
    }



    //Initial instructions
    IEnumerator playInitialInstructionsAfter1sec(){
        yield return new WaitForSeconds(1f);
        soundManager.playInitialInstructions();
    }

    //open electricity box is possible
    public void endInitialInstructions(){
      soundManager.canPlayOpenBox();
      box.canOpenBox();
    }


    //Fire begin and confidential datas instructions
    IEnumerator playConfidentialDatasInstructionsAfter10sec(){
      yield return new WaitForSeconds(5f);
      //Fire, explosion sound, electric arcs?
      yield return new WaitForSeconds(5f);
      soundManager.playConfidentialDataInstructions();
    }
    //wait for 10 seconds and begin fires and instructions to get confidential datas
    public void electicityPulledDown(){
      StartCoroutine(playConfidentialDatasInstructionsAfter10sec());
    }

    //Data extractions and parachute Instructions when player is in front of computer, he can use the module
    //Data extraction, explosion instructions
    IEnumerator dataExtractionCorroutine(){
      gameManager.addPosition(System.DateTime.Now, "Debut extraction des donnees");
      yield return new WaitForSeconds(10f);
      //First warning
      //If he still download the datas
      if (jump.getHasJumped()==false){
        soundManager.playFirstWarning();
        yield return new WaitForSeconds(10f);
        //Second warning
        //If he still download the datas
        if (jump.getHasJumped()==false){
          soundManager.playSecondWarning();
          yield return new WaitForSeconds(10f);
          //last warning
          //If he still download the datas
          if (jump.getHasJumped()==false){
            soundManager.playLastWarning();
            yield return new WaitForSeconds(3.5f);
            if (jump.getHasJumped()==false){
              //Explosion no matter what
              explosion.launchExplosion();
          }
          }
        }
      }

    }


    public void dataExtraction(){
      StartCoroutine(dataExtractionCorroutine());
    }
    // Update is called once per frame
    void Update()
    {

      //Reload to checkpoint
      if (Input.GetKeyDown("r")){
        if (playerState < 6){
          checkpoint1();
        }
        else if (playerState < 11){
          checkpoint2();
        }
        else{
          checkpoint3();
        }
      }

    }
}
