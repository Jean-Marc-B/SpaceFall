using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StressSystem : MonoBehaviour
{
    static StressSystem instance;

    private static StressComputation stressComputation;
    private static GameObject tunnelVision;
    private HeartBeating heartBeating;

    private List<int> stressDetected = new List<int>();
    private List<bool> stress = new List<bool>();

    // Creates a singleton that will persist between scenes
    void Awake()
    {
        // Singleton
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keeps the same script on all scenes
        }
        stressComputation = GameObject.Find("StressComputation").GetComponent<StressComputation>();
        heartBeating = GameObject.Find("HeartBeating").GetComponent<HeartBeating>();
        tunnelVision = gameObject.transform.GetChild(2).gameObject;
    }

    private void Start()
    {
        // Every 1 second, we need to check the stress level to adjust tunnel vision and heart beating sound
        InvokeRepeating("checkStressLevel", 1f, 1f);
    }

    // Activates or desactivates tunnel vision and heart beating sound. Stores in a list the current stress status
    private void checkStressLevel()
    {
        if (stressDetected.Count > 3)
        {
            stressDetected.RemoveAt(0);
        }
        if (stressComputation.stressed)
        {
            stressDetected.Add(1);
        }
        else
        {
            stressDetected.Add(0);
        }
        bool stressed = stressDetected.Average() > 0.5;
        stress.Add(stressed);

        if (stressed == true)
        {
            tunnelVision.SetActive(true);
            heartBeating.startHeartBeating();
        }
        else
        {
            tunnelVision.SetActive(false);
            heartBeating.stopHeartBeating();
        }
    }

    // This function is called after the parachute, when the colonel is about to give a feedback
    // It returns 0, 1 or 2 depending on the stress managment of the player :
    // 0 : the player stressed too much
    // 1 : the player stressed for a while, but managed to get the control back
    // 2 : the player didn't stress too much
    public int getStressLevel()
    {
        float percentageOfTimeStressed = (float)stress.Where(c => c).Count() / (float) stress.Count();

        // First case : the player stressed less than 5% of the time
        if (percentageOfTimeStressed < 0.05)
        {
            return 2;
        }

        // Else, we want to know if the player managed to get the control back or not.
        // We extract the number of times he had a sequence of 4 seconds where he stressed.
        int numberOfSequencedStress = getNumberOfSequencedStress(3, stress);
        if (numberOfSequencedStress > 0)
        {
            // If it had a sequence, we verify if he had one in the last 20 seconds before talking to the colonel
            // If he has, we return 0
            if (getNumberOfSequencedStress(3, stress.Skip(stress.Count() - 30).ToList()) > 0)
            {
                return 0;
            }
            // If he didn't stress during the last 20 seconds, we assume he managed to get the control back and return 1
            else
            {
                return 1;
            }
        }

        // If he had no sequence of stress, we return 2
        return 2;

    }

    // Returns the number of times where the player stressed for more than numberOfTrues seconds.
    private int getNumberOfSequencedStress(int numberOfTrues, List<bool> stress)
    {
        int numberOfSequences = 0;
        int currentSequence = 0;

        for (int i = 0; i < stress.Count(); i++)
        {
            if (stress[i]) // Player is stressing
            {
                currentSequence++; // We increment the number of consecutive "true"
            }
            else // Player is not stressing
            {
                // If the sequence is longer than numberOfTrues, the number of sequences is incremented
                // Else, it won't be taken into account
                if (currentSequence > numberOfTrues)
                {
                    numberOfSequences++;
                }
                // We reset the two other variables
                currentSequence = 0;
            }
        }
        // We finally manage the case where the player is inside a sequence at the end of the list
        if (currentSequence >= numberOfTrues)
        {
            numberOfSequences++;
        }

        return numberOfSequences;
    }

    private void Update()
    {
        
    }
}
