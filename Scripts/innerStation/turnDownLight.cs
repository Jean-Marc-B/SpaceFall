using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnDownLight : MonoBehaviour
{
    private Light myLight;
    private bool lightsDown = false;

    // Start is called before the first frame update
    void Start()
    {
      myLight = GetComponent<Light>();
    }

    IEnumerator turnDownTheLights()
    {

        myLight.enabled = false;
        yield return new WaitForSeconds(0.2f);
        myLight.enabled = true;
        yield return new WaitForSeconds(0.2f);
        myLight.enabled = false;
        yield return new WaitForSeconds(0.2f);
        myLight.enabled = true;
        yield return new WaitForSeconds(0.2f);
        myLight.enabled = false;
        yield return new WaitForSeconds(0.2f);
        myLight.enabled = true;
        yield return new WaitForSeconds(0.2f);
        myLight.enabled = false;
        yield return new WaitForSeconds(0.2f);
        myLight.enabled = true;
        yield return new WaitForSeconds(0.2f);
        myLight.enabled = false;
        yield return new WaitForSeconds(0.2f);
        myLight.enabled = true;
        yield return new WaitForSeconds(0.2f);
        myLight.enabled = false;
        yield return new WaitForSeconds(0.2f);
        myLight.enabled = true;
        yield return new WaitForSeconds(0.2f);
        myLight.enabled = false;
        yield return new WaitForSeconds(5f);
        sceneManager.launchAlarm = true; //alarm trigger
    }


    // Update is called once per frame
    void Update()
    {
      if ((sceneManager.turnDownLights == true) && (lightsDown == false)){
        lightsDown = true;
        StartCoroutine(turnDownTheLights());
      }
    }
}
