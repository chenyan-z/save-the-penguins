using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteFriendLocal : MonoBehaviour
{
    public void DestroyGameObject(GameObject objectToDestroy)
    {
      Destroy (objectToDestroy);
    }
}
