using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    [SerializeField]
    private Transform stackPoint;

    [SerializeField]
    private List<GameObject> stackObjects;
    [SerializeField]
    private List<GameObject> silverObjects;
    [SerializeField]
    private AudioSource audioSource;

    private int goldCount;
    private int silverCount;

    private int stackObjectsCount;

    public static StackManager stack;
    private void Awake()
    {
        if (!stack)
        {
            stack = this;
        }
    }

    public void AddSilver(GameObject currentSilverObject)
    {
        currentSilverObject.GetComponent<Rigidbody>().isKinematic = true;
        currentSilverObject.GetComponent<Rigidbody>().freezeRotation = true;
        currentSilverObject.GetComponent<Collider>().enabled = false;
        silverObjects.Add(currentSilverObject);
        stackObjects.Add(currentSilverObject);
        currentSilverObject.transform.parent = stackPoint;
        StackObjects();
        DisplaySilver();
        PlayPopSound();
    }

    public void RemoveLastSilver()
    {
        GameObject removingSilver = silverObjects[silverObjects.Count - 1];
        silverObjects.Remove(removingSilver);
        stackObjects.Remove(removingSilver);
        removingSilver.transform.parent = null;
        Destroy(removingSilver);
        StackObjects();
        DisplaySilver();
        PlayPopSound();
    }

    public void DisplaySilver()
    {
        Manager.manager.DisplaySilver(silverObjects.Count);
    }

    public void StackObjects()
    {
        stackObjectsCount = stackObjects.Count;
        for (int i = 0; i < stackObjectsCount; i++)
        {
            stackObjects[i].transform.position = new Vector3(stackPoint.position.x,
                stackPoint.position.y + ((float)i / 4),
                stackPoint.position.z);

            stackObjects[i].transform.rotation = stackPoint.transform.rotation;
        }
    }

    public void PlayPopSound()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }

    public int GetSilver()
    {
        return silverObjects.Count;
    }
}
