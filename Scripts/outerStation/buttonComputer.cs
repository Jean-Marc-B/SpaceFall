using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonComputer : MonoBehaviour
{
    private bool pressed = false;
    private bool canBeActivated = true;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Hand") && (canBeActivated == true))
        {
            canBeActivated = false;
            pressed = true;
            StartCoroutine(reactivateButtonAfter1Second());
        }
    }
    IEnumerator reactivateButtonAfter1Second()
    {
        yield return new WaitForSeconds(1f);
        canBeActivated = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Hand")
        {
            pressed = false;
        }
    }

    public bool getPressed()
    {
        return pressed;
    }
}
