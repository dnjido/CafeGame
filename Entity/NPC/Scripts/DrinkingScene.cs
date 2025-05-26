using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DrinkingScene : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Camera _sceneCamera;
    [SerializeField] private GameObject _npcSpawn, _endText;

    private void Update()
    {
        if (Input.GetButtonDown("Use"))
        {
            SetCamera();
            StartScene();
        }
    }

    public void SetCamera()
    {
        FindObjectOfType<FadeController>().FadeIn(.5f, EnableCamera);
    }

    public void EnableCamera()
    {
        FindObjectOfType<FadeController>().FadeOut(.5f);
        Camera.main.enabled = false;
        _sceneCamera.enabled = true;
        _sceneCamera.transform.DOMove(_sceneCamera.transform.position + _sceneCamera.transform.forward, 3).SetEase(Ease.InOutQuad);
    }

    public void StartScene()
    {
        StartCoroutine(Scene());
    }

    private IEnumerator Scene()
    {
        while (_animator.speed > 0)
        {
            _animator.speed -= .5f;
            yield return null;
        }

        yield return new WaitForSeconds(.5f);

        _npcSpawn.SetActive(true);

        yield return new WaitForSeconds(.5f);

        float fovTimer = 0;
        while (fovTimer < .5)
        {
            fovTimer += Time.deltaTime;
            _sceneCamera.fieldOfView -= .6f;
            yield return null;
        }

        FindObjectOfType<FadeController>().FadeIn(.01f);
        yield return new WaitForSeconds(1f);
        _endText.SetActive(true); 

        FindObjectOfType<FadeController>().FadeOut(1.5f);
        yield return new WaitForSeconds(1.5f);

        yield return new WaitForSeconds(1.5f);

        FindObjectOfType<FadeController>().FadeIn(1);

        yield return new WaitForSeconds(1.5f);

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
