using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleChecker : MonoBehaviour
{
    public List<GameObject> gameObjects = new List<GameObject>();

    public bool isok()
    {
        foreach (GameObject obj in gameObjects)
        {
            Dragable dragable = obj.GetComponent<Dragable>();
            if (!dragable.IsTargeted)
            {
                return false;
            }
        }
        return true;
    }
}
