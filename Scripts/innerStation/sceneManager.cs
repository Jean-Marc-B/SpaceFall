using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneManager : MonoBehaviour
{
    private static gameManager gameManager;

    //public stressManager stressM;
    public static bool instructionsRadarFinished = false;
    public static bool radarCheck = false;
    public static bool overheatThinkingFinished = false;
    public static bool turnDownLights = false;
    public static bool launchAlarm = false;
    public static bool alarmUp = false;
    public static bool instructionsTemperatureFinished = false;
    public static bool temperatureCheck = false;
    public static bool instructionsTemperature2Finished = false;
    public static bool temperatureCheck2 = false;
    public static bool instructionsParachuteFinished = false;
    public static bool canTakeParachute = false;
    public static bool takeParachuteFinished = false;
    public static bool canGoOut = false;

    //Sons

    public static bool playInstructionsRadarSound = false;
    public static bool playOverheatSound = false;
    public static bool playFlashingLights = false;
    public static bool playTemperatureSound = false;
    public static bool playElectricProblemSound = false;
    public static bool playParachuteSound = false;
    public static bool playGetOutSound = false;

    // Start is called before the first frame update
    void Start()
    {
      gameManager = GameObject.Find("GameManager").GetComponent<gameManager>();
      gameManager.addPosition(System.DateTime.Now, "Debut du jeu");
      StartCoroutine(playInstructionsRadarAfter3sec()); //Instructions to check the radar

    }


    IEnumerator playInstructionsRadarAfter3sec(){
        yield return new WaitForSeconds(3f);
        playInstructionsRadarSound = true;
    }


    IEnumerator playTemperatureAfter5Sec()
    {
        yield return new WaitForSeconds(5f);
        playTemperatureSound = true;
    }


    // Update is called once per frame
    void Update()
    {
      if (instructionsRadarFinished == true){
          radarCheck = true; //Player can now go check the radar, then he has a conversation with captain
      }
      if (overheatThinkingFinished == true){ //conversation with Captain got cut
        turnDownLights = true; //Lights go down and electricity arches appear and alarm trigger
      }
      if (alarmUp == true){ //captain communication come back after 5sec
        StartCoroutine(playTemperatureAfter5Sec()); //Instructions about temperature
      }
      if (instructionsTemperatureFinished == true){
        temperatureCheck = true; //Player can now go check the temperature, then captain ask to check other temperature screen
      }
      if (instructionsTemperature2Finished == true){
        temperatureCheck2 = true; //Player can now go check the second temperature screen, then captain ask to go take the parachute
      }
      if (instructionsParachuteFinished == true){
        canTakeParachute = true; //Player can now go take the parachute and then the captain ask him to leave
      }
      if (takeParachuteFinished == true){
        canGoOut = true; //Player can now get out of the station
      }
    }
}
