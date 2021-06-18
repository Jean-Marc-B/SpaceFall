using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class checkJump : MonoBehaviour
{
  public outerSceneManager sceneManager;
  public explosion explosion;
  private static gameManager gameManager;
  private static screenManager screenManager;
  public JoystickMovementForOutter playerJoystickMovement;
    private int percentage;

    private bool hasJumped = false;
    // Start is called before the first frame update
    void Start()
    {
      gameManager = GameObject.Find("GameManager").GetComponent<gameManager>();
      screenManager = GameObject.Find("Ordi").GetComponent<screenManager>();
    }

    public bool getHasJumped(){
      return hasJumped;
    }

    public int getPercentage()
    {
        return percentage;
    }


    void OnTriggerEnter (Collider other)
        {
          if (other.tag == "Player"){
            if (sceneManager.getPlayerState()==11){
              hasJumped = true;
              StartCoroutine(launchExplosionAfter7Seconds());
              string s = screenManager.transform.Find("percentage").gameObject.GetComponent<TextMesh>().text;
              gameManager.addPosition(System.DateTime.Now, "Saut : "+s+" des donnees extraites");
              Debug.Log("Saut : "+s+" des donnees extraites");
              percentage = int.Parse(s.Remove(s.Length - 1));
              gameManager.setPercentage(percentage);
              playerJoystickMovement.gravity = 10;
            }
          }
        }
    IEnumerator launchExplosionAfter7Seconds()
    {
        yield return new WaitForSeconds(7.0f);
        explosion.launchExplosion();
    }
    

    // Update is called once per frame
    void Update()
    {

    }
}
