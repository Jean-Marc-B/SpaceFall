using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableFire : MonoBehaviour
{
    private static gameManager gameManager;
    // Start is called before the first frame update
    void Start(){
    }

    public void launchFire(){
      gameManager = GameObject.Find("GameManager").GetComponent<gameManager>();
      gameManager.addPosition(System.DateTime.Now, "Apparition du feu");
      this.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
