using UnityEngine;
using System.Collections;

public class TitleController : MonoBehaviour {

    public AudioClip titleSound;
    public AudioClip enterSound;

    private GameObject enterTextObj;

    Animation anim = new Animation();

    void Start() 
    {
        enterTextObj = GameObject.FindGameObjectWithTag("EnterText") as GameObject;
        enterTextObj.SetActive(false);

        anim = GetComponent<Animation>();
        anim.Play("MenuMovement");

        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(titleSound);
    }
    
    void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(startGame());
        }
	}

    IEnumerator startGame() 
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(enterSound);
        yield return new WaitForSeconds(3);
        Application.LoadLevel(1);
    }

    void activateEnterText() 
    {
        enterTextObj.SetActive(true);
    }
}