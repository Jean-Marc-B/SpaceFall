using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class screenManager : MonoBehaviour
{
  public outerSceneManager sceneManager;

    bool canUse = false;
    private bool canPressUp = true;
    private bool canPressDown = true;
    private bool canPressSelect = true;

    private GameObject selection1;
    private GameObject selection2;
    private GameObject selection3;
    private GameObject textMenuFrench;
    private GameObject textMenuEnglish;
    private GameObject textLangueFrench;
    private GameObject textLangueEnglish;
    private GameObject download;
    private GameObject telechargement;
    private bool inMenu = true;
    private bool inLangues = false;
    private bool french = true;
    private GameObject progressbar;
    private Slider slider;
    private GameObject percentage;
    private TextMesh textPercentage;
    private float t = 0.0f;
    private float duration = 48.0f; //download duration
    private bool beginDownload = false;
    // Start is called before the first frame update
    void Start()
    {
        selection1 = this.transform.Find("Selection1").gameObject;
        selection2 = this.transform.Find("Selection2").gameObject;
        selection3 = this.transform.Find("Selection3").gameObject;
        textMenuFrench = this.transform.Find("textesMenuFrench").gameObject;
        textMenuEnglish = this.transform.Find("textesMenuEnglish").gameObject;
        textLangueFrench = this.transform.Find("textesLanguesFrench").gameObject;
        textLangueEnglish = this.transform.Find("textesLanguesEnglish").gameObject;
        download = this.transform.Find("download").gameObject;
        telechargement = this.transform.Find("telechargement").gameObject;
        progressbar = this.transform.Find("Canvas").gameObject.transform.Find("progressBar").gameObject;
        percentage = this.transform.Find("percentage").gameObject;
        textPercentage = percentage.GetComponent<TextMesh>();
        slider = progressbar.GetComponent<Slider>();
        selection2.SetActive(false);
        selection3.SetActive(false);
        textMenuEnglish.SetActive(false);
        textLangueFrench.SetActive(false);
        textLangueEnglish.SetActive(false);
        download.SetActive(false);
        telechargement.SetActive(false);
        progressbar.SetActive(false);
        percentage.SetActive(false);
    }

    public void canUseModule(){
      canUse = true;
    }

    IEnumerator reactivePressDown()
    {
      yield return new WaitForSeconds(1.0f);
      canPressDown = true;
    }

    IEnumerator reactivePressUp()
    {
      yield return new WaitForSeconds(1.0f);
      canPressUp = true;
    }

    IEnumerator reactiveSelect()
    {
        yield return new WaitForSeconds(1.0f);
        canPressSelect = true;
    }

    // Update is called once per frame
    void Update()
    {
      if (GameObject.Find("Bouton_descendre").GetComponent<buttonComputer>().getPressed() && canUse){
        if (canPressDown){
          canPressDown = false;
          StartCoroutine(reactivePressDown());
          if (selection2.activeSelf && inLangues){
            selection2.SetActive(false);
            selection3.SetActive(true);
          }
          else if (selection1.activeSelf){
            selection1.SetActive(false);
            selection2.SetActive(true);
          }
        }
      }

      if (GameObject.Find("Bouton_monter").GetComponent<buttonComputer>().getPressed() && canUse){
        if (canPressUp){
          canPressUp = false;
          StartCoroutine(reactivePressUp());
          if (selection2.activeSelf){
            selection2.SetActive(false);
            selection1.SetActive(true);
          }
          else if (selection3.activeSelf){
            selection3.SetActive(false);
            selection2.SetActive(true);
          }
        }
      }

      if (GameObject.Find("Bouton_sélectionner").GetComponent<buttonComputer>().getPressed() && canUse){

            if (canPressSelect)
            {
                canPressSelect = false;
                StartCoroutine(reactiveSelect());
                if (inMenu)
                { //We are in menu pannel
                    if (selection1.activeSelf)
                    { //Choose language
                        inLangues = true;
                        inMenu = false;
                        if (french)
                        { //It is in french
                            textLangueFrench.SetActive(true);
                            textMenuFrench.SetActive(false);
                        }
                        else
                        { //It is in english
                            textLangueEnglish.SetActive(true);
                            textMenuEnglish.SetActive(false);
                            selection1.SetActive(false);
                            selection2.SetActive(true);
                        }
                    }
                    else
                    { //Data extraction
                        selection2.SetActive(false);
                        if (french)
                        {
                            textMenuFrench.SetActive(false);
                            telechargement.SetActive(true);
                            progressbar.SetActive(true);
                            percentage.SetActive(true);
                            beginDownload = true;
                            sceneManager.dataExtraction();
                        }
                        else
                        {
                            textMenuEnglish.SetActive(false);
                            download.SetActive(true);
                            progressbar.SetActive(true);
                            percentage.SetActive(true);
                            beginDownload = true;
                            sceneManager.dataExtraction();
                        }
                    }
                }
                else
                { //We are in language pannel
                    if (selection1.activeSelf && !french)
                    {
                        french = true;
                        textLangueEnglish.SetActive(false);
                        textLangueFrench.SetActive(true);
                    }
                    else if (selection2.activeSelf && french)
                    {
                        french = false;
                        textLangueFrench.SetActive(false);
                        textLangueEnglish.SetActive(true);
                    }
                    else if (selection3.activeSelf)
                    { //Exit
                        if (french)
                        { //It is in french
                            textLangueFrench.SetActive(false);
                            textMenuFrench.SetActive(true);
                            inLangues = false;
                            inMenu = true;
                            selection3.SetActive(false);
                            selection1.SetActive(true);
                        }
                        else
                        { //It is in english
                            textLangueEnglish.SetActive(false);
                            textMenuEnglish.SetActive(true);
                            inLangues = false;
                            inMenu = true;
                            selection3.SetActive(false);
                            selection1.SetActive(true);
                        }
                    }
                }
            }
      }

      if (beginDownload == true){
        t += Time.deltaTime / duration;
        slider.value = Mathf.Lerp(0, 1, t);
        textPercentage.text = Mathf.RoundToInt(slider.value*100)+"%";
      }

    }
}
