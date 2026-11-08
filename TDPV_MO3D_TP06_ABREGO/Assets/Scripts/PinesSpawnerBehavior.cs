using UnityEngine;

public class PinesBehavior : MonoBehaviour
{
    [SerializeField] private GameObject pines;

    void Start()
    {
        Restart();
    }

    private void OnEnable()
    {
        GameEvents.OnRestart += Restart;
    }

    private void OnDisable()
    {
        GameEvents.OnRestart -= Restart;
    }

    private void Restart()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        GameObject newPines = Instantiate(pines, transform.position, Quaternion.identity);
        newPines.transform.parent = transform;
    }
}
