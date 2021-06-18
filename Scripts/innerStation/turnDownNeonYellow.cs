using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnDownNeonYellow : MonoBehaviour
{
    private bool lightsDown = false;
    Material mymat;

    // Start is called before the first frame update
    void Start()
    {
      mymat = GetComponent<Renderer>().material;
    }

    IEnumerator turnDownTheNeons(){
        sceneManager.playFlashingLights = true;
        mymat.SetColor("_EmissionColor", Color.black);
        yield return new WaitForSeconds(0.2f);
        mymat.SetColor("_EmissionColor", new Vector4(191,130,0) * 7.305214f);
        yield return new WaitForSeconds(0.2f);
        mymat.SetColor("_EmissionColor", Color.black);
        yield return new WaitForSeconds(0.2f);
        mymat.SetColor("_EmissionColor", new Vector4(191,130,0) * 7.305214f);
        yield return new WaitForSeconds(0.2f);
        mymat.SetColor("_EmissionColor", Color.black);
        yield return new WaitForSeconds(0.2f);
        mymat.SetColor("_EmissionColor", new Vector4(191,130,0) * 7.305214f);
        yield return new WaitForSeconds(0.2f);
        mymat.SetColor("_EmissionColor", Color.black);
        yield return new WaitForSeconds(0.2f);
        mymat.SetColor("_EmissionColor", new Vector4(191,130,0) * 7.305214f);
        yield return new WaitForSeconds(0.2f);
        mymat.SetColor("_EmissionColor", Color.black);
        yield return new WaitForSeconds(0.2f);
        mymat.SetColor("_EmissionColor", new Vector4(191,130,0) * 7.305214f);
        yield return new WaitForSeconds(0.2f);
        mymat.SetColor("_EmissionColor", Color.black);
        yield return new WaitForSeconds(0.2f);
        mymat.SetColor("_EmissionColor", new Vector4(191,130,0) * 7.305214f);
        yield return new WaitForSeconds(0.2f);
        mymat.SetColor("_EmissionColor", Color.black);
        yield return new WaitForSeconds(5f);
        sceneManager.launchAlarm = true; //alarm trigger
    }

    // Update is called once per frame
    void Update()
    {
      if ((sceneManager.turnDownLights == true) && (lightsDown == false)){
        lightsDown = true;
        StartCoroutine(turnDownTheNeons());
      }
    }
}
