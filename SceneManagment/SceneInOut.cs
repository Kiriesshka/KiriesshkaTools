using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneInOut : MonoBehaviour
{
    
    public Image screen;
    public float timeToChangeScene = 0.5f;
    public bool isSetAsLastSibling;

    private bool isBlackToTransparent = true;

    private void Start()
    {
        _SceneIn();
    }
    private void Update()
    {
        if(isBlackToTransparent)
            screen.color = Color.Lerp(screen.color, new Color(0, 0, 0, 0f), Time.deltaTime * 10);
        else
            screen.color = Color.Lerp(screen.color, new Color(0, 0, 0, 1f), Time.deltaTime * 10);
    }
    private void _SceneIn()
    {
        if(isSetAsLastSibling)
            GetComponent<RectTransform>().SetAsLastSibling();
        screen.gameObject.SetActive(true);
        isBlackToTransparent = true;
    }
    private void _SceneOut()
    {
        if(isSetAsLastSibling)
            GetComponent<RectTransform>().SetAsLastSibling();

        isBlackToTransparent = false;
    }
    public void _ChangeScene(int sceneId)
    {
        _SceneOut();
        StartCoroutine(RealChangeScene(sceneId));
    }
    private IEnumerator RealChangeScene(int id)
    {
        yield return new WaitForSeconds(timeToChangeScene);
        SceneManager.LoadScene(id);
    }
}
