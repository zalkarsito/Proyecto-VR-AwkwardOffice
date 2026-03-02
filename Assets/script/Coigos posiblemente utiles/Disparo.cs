using Oculus.Haptics;
using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject Bullet;
    public float shootForce;
    public Transform shootPoint;
    //public ParticleSystem particleShoot;
    public AudioSource audioShoot;
    public HapticClip clip1;
    private HapticClipPlayer player;
    void Awake()
    {
        player = new HapticClipPlayer(clip1);
    }

    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
        {
            if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            {

                Instantiate(Bullet, shootPoint.position, shootPoint.rotation).GetComponent<Rigidbody>().AddForce(shootPoint.forward * shootForce);
                //StartCoroutine(VibrateForSeconds(0.5f, 1f, 0.3f, OVRInput.Controller.RTouch));
                //particleShoot.Play();
                player.Play(Oculus.Haptics.Controller.Right);
                audioShoot.Play();
            }

        }
    }
    IEnumerator VibrateForSeconds(float duration, float frequency, float amplitude, OVRInput.Controller controller)
    {

        OVRInput.SetControllerVibration(frequency, amplitude, controller);
        yield return new WaitForSeconds(duration);

        OVRInput.SetControllerVibration(0, 0, controller);
    }
    public void PlayHapticClip1()
    {
        player.Play(Controller.Right);
    }
    public void StopHaptics()
    {
        player.Stop();
    }
}
