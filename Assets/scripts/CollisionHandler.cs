using UnityEngine.SceneManagement;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] AudioClip death;
    [SerializeField] AudioClip success;
    [SerializeField] ParticleSystem deathParticle;
    [SerializeField] ParticleSystem successParticle;
    AudioSource audio;
    ManageScene managescene;
    bool isTransitioning = false;
    private void Start()
    {
        managescene = GetComponent<ManageScene>();
        audio = GetComponent<AudioSource>();
    }
    ManageScene manageScene;
    private void OnCollisionEnter(Collision collision)
    {
        if (isTransitioning) { return; }
        switch (collision.gameObject.tag)
        {
            case "friendly":
                print("friendly");
                break;
            case "Finish":
                isTransitioning = true;
                successParticle.Play();
                audio.PlayOneShot(success);
                GetComponent<NewBehaviourScript>().enabled = false;
                InvokeRepeating("Success", 2f, 3f);
                break;
            default:
                if (!isTransitioning)
                {
                    isTransitioning = true;
                    deathParticle.Play();
                    audio.PlayOneShot(death);
                    GetComponent<NewBehaviourScript>().enabled = false;
                    InvokeRepeating("Death", 2f, 3f);
                }
                break;
        }
    }
    void Death()
    {
        managescene.ReloadScene();
        CancelInvoke();
    }
    void Success()
    {
        managescene.LoadNextScene();
        CancelInvoke();
    }

}
