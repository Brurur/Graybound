using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SplashParticles : MonoBehaviour
{
    [SerializeField] GameObject[] splashEffect;
    [SerializeField] GameObject[] menuEffect;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip swoosh;
    [SerializeField] AudioClip click;
    [SerializeField] Texture2D cursorTexture;

    private CanvasGroup fadeOverlay;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("TurnOff", 16f);
        Invoke("PlaySwoosh", 13.5f);
        Cursor.visible = false;
        fadeOverlay = GameObject.Find("Fade Overlay").GetComponent<CanvasGroup>();
    }

    private void TurnOff()
    {
        foreach (var effect in splashEffect)
        {
            effect.SetActive(false);
        }

        foreach (var effect in menuEffect)
        {
            effect.SetActive(true);
        }
    }

    private void PlaySwoosh()
    {
        Cursor.visible = true;
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
        audioSource.PlayOneShot(swoosh);
    }

    public void PlayClick()
    {
        audioSource.pitch = Random.Range(0.8f, 1.2f);
        audioSource.PlayOneShot(click);
    }

    public void ClickPlay()
    {
        Invoke("LevelOne", 2f);
        fadeOverlay.DOFade(1, 2);
    }

    private void LevelOne()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void ClickQuit()
    {
        Application.Quit();
    }
}
