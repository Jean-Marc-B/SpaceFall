using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class explosion : MonoBehaviour
{

    private static gameManager gameManager;
    public checkJump checkJump;
    public screenManager screenManager;
    private bool hasNotExploded = true;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<gameManager>();
    }

    IEnumerator explode()
    {
        gameManager.addPosition(System.DateTime.Now, "Explosion");
        gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Play();
        gameObject.transform.GetChild(0).gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2.0f);
        gameObject.transform.GetChild(1).gameObject.GetComponent<ParticleSystem>().Play();
        gameObject.transform.GetChild(1).gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2.0f);
        gameObject.transform.GetChild(2).gameObject.GetComponent<ParticleSystem>().Play();
        gameObject.transform.GetChild(2).gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2.0f);
        gameObject.transform.GetChild(3).gameObject.GetComponent<ParticleSystem>().Play();
        gameObject.transform.GetChild(3).gameObject.GetComponent<AudioSource>().Play();
        //Vérifier si il a sauté ou pas encore
        yield return new WaitForSeconds(2.0f);
        gameObject.transform.GetChild(4).gameObject.GetComponent<ParticleSystem>().Play();
        gameObject.transform.GetChild(4).gameObject.GetComponent<AudioSource>().Play();

        string s = screenManager.transform.Find("percentage").gameObject.GetComponent<TextMesh>().text;
        int percentage = int.Parse(s.Remove(s.Length - 1));

        if (checkJump.getHasJumped() == false)
        { //Si il n'a pas déjà sauté
            yield return new WaitForSeconds(1.0f);
            SceneManager.LoadScene("deathScene");
        } else if (checkJump.getPercentage() >= 78) {
            // S'il a sauté trop tard
            yield return new WaitForSeconds(1.0f);
            SceneManager.LoadScene("deathScene");
        }
        else{
            yield return new WaitForSeconds(3.0f);
            gameObject.transform.GetChild(5).gameObject.GetComponent<ParticleSystem>().Play();
            gameObject.transform.GetChild(5).gameObject.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(3.0f);
            gameObject.transform.GetChild(6).gameObject.GetComponent<ParticleSystem>().Play();
            gameObject.transform.GetChild(6).gameObject.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(3.0f);
            gameObject.transform.GetChild(7).gameObject.GetComponent<ParticleSystem>().Play();
            gameObject.transform.GetChild(7).gameObject.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(5.0f);
            gameObject.transform.GetChild(7).gameObject.GetComponent<ParticleSystem>().Play();
            gameObject.transform.GetChild(7).gameObject.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(5.0f);
            gameObject.transform.GetChild(7).gameObject.GetComponent<ParticleSystem>().Play();
            gameObject.transform.GetChild(7).gameObject.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(5.0f);
            gameObject.transform.GetChild(7).gameObject.GetComponent<ParticleSystem>().Play();
            gameObject.transform.GetChild(7).gameObject.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(5.0f);
            gameObject.transform.GetChild(7).gameObject.GetComponent<ParticleSystem>().Play();
            gameObject.transform.GetChild(7).gameObject.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(5.0f);
            gameObject.transform.GetChild(7).gameObject.GetComponent<ParticleSystem>().Play();
            gameObject.transform.GetChild(7).gameObject.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(5.0f);
            gameObject.transform.GetChild(7).gameObject.GetComponent<ParticleSystem>().Play();
            gameObject.transform.GetChild(7).gameObject.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(5.0f);
            gameObject.transform.GetChild(7).gameObject.GetComponent<ParticleSystem>().Play();
            gameObject.transform.GetChild(7).gameObject.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(5.0f);
            gameObject.transform.GetChild(7).gameObject.GetComponent<ParticleSystem>().Play();
            gameObject.transform.GetChild(7).gameObject.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(5.0f);
            gameObject.transform.GetChild(7).gameObject.GetComponent<ParticleSystem>().Play();
            gameObject.transform.GetChild(7).gameObject.GetComponent<AudioSource>().Play();
        }

    }


    public void launchExplosion(){
        if (hasNotExploded) {
            hasNotExploded = false;
            StartCoroutine(explode());
        }
        
    }

}
