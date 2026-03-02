using UnityEngine;

public class TrashCollector : MonoBehaviour
{

    public GameManager Manager;

    private void Start()
    {
        Manager = Object.FindFirstObjectByType<GameManager>();
    }
    private void OnCollisionEnter(Collision other)
    {
        Manager.TargetHit(other.gameObject);
        if (other.gameObject.CompareTag("Trash"))
        {
            other.gameObject.SetActive(false);

        }
    }
}
