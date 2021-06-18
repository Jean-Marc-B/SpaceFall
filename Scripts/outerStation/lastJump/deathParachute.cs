using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathParachute : MonoBehaviour
{
  public AudioSource fall;
  public outerSceneManager sceneManager;
  public parachuteManager parachute;

    // Start is called before the first frame update
    void Start()
    {

    }

    IEnumerator death(){
      yield return new WaitForSeconds(0.1f);
      SceneManager.LoadScene("deathScene");
    }


    void OnTriggerEnter (Collider other)
        {
          if (other.tag == "Player"){
            if (sceneManager.getPlayerState()==11){
              if (parachute.getParachuteOpened()==false){
                fall.Play();
                StartCoroutine(death());
              }
            }
          }
        }

    // Update is called once per frame
    void Update()
    {

    }
}
