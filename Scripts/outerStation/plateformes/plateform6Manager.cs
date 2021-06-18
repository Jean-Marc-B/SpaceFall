using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class plateform6Manager : MonoBehaviour
{

    public AudioSource fall;
    public outerSceneManager sceneManager;
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
            if (sceneManager.getPlayerState()==9){
              sceneManager.setPlayerState(10);
            }
            if (sceneManager.getPlayerState()<9){
              fall.Play();
              StartCoroutine(death());
            }
          }
        }

    // Update is called once per frame
    void Update()
    {

    }
}
