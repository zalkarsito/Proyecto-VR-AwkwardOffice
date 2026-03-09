using System.Collections;
using UnityEngine;

public class TrashCollector : MonoBehaviour
{

    public GameManager Manager;
    public GameObject confettipos;
    public GameObject confettiPrefab;
    private GameObject confetti;
    public AudioSource audioPoint;
    public ParticleSystem ps;

    private void Start()
    {
        Manager = Object.FindFirstObjectByType<GameManager>();
        ps.Stop();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("colisiona con la papelera");
        Manager.TargetHit(other.gameObject);
        if (other.gameObject.CompareTag("Trash"))
        {
            Debug.Log("Entra en el comparador de trash");

            other.gameObject.SetActive(false);

            ps.Play();
            StartCoroutine(Espera());
            audioPoint.Play();
            

        }
    }

    IEnumerator Espera()
    {
        yield return new WaitForSeconds(2f);
        //confetti.SetActive(false);
        ps.Stop();
    }
}
