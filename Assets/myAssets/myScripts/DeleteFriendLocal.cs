using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteFriendLocal : MonoBehaviour
{
    private GameObject objectToDestroy;
    public void SetObjectToDestroy(GameObject _objectToDestroy)
    {
        objectToDestroy = _objectToDestroy;
    }

    public void DestroyGameObject()
    {
      Destroy (objectToDestroy);
    }
}
