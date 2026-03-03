using UnityEngine;

public class TrashCollector : MonoBehaviour
{

    public GameManager Manager;

    private void Start()
    {
        Manager = Object.FindFirstObjectByType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("colisiona con la papelera");
        Manager.TargetHit(other.gameObject);
        if (other.gameObject.CompareTag("Trash"))
        {
            Debug.Log("Entra en el comparador de trash");
            other.gameObject.SetActive(false);

        }
    }
}
