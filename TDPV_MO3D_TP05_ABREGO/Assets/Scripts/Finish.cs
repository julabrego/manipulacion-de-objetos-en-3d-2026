using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    Collider myCollider;

    private void Start()
    {
        myCollider = GetComponent<Collider>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 playerPosition = other.gameObject.transform.position;

            if (IsObjectFitting(other.gameObject))
            {
                GameEvents.TriggerVictory();
                other.gameObject.SetActive(false);
            }
        }
    }

    public bool IsObjectFitting(GameObject innerObject)
    {
        Collider innerCollider = innerObject.GetComponent<Collider>();

        if (innerCollider == null)
        {
            Debug.LogError("Both objects must have colliders.");
            return false;
        }

        Bounds outer = myCollider.bounds;
        Bounds inner = innerCollider.bounds;

        return inner.min.x >= outer.min.x && inner.max.x <= outer.max.x
            && inner.min.y >= outer.min.y && inner.max.y <= outer.max.y;
    }
}
