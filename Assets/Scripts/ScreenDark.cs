using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenDark : MonoBehaviour
{
    [SerializeField] private UnityEvent _onHide;
    [SerializeField] private Image _image;
    [SerializeField, Min(.0f)] private float _speed;

    public void Hide()
    {
        _image.gameObject.SetActive(true);
        StartCoroutine(Hiding());
    }

    private IEnumerator Hiding()
    {
        var c = _image.color;
        while (c.a < 1)
        {
            c = new Color(c.r, c.g, c.b, Mathf.MoveTowards(c.a,
                1, _speed));
            _image.color = c;
            yield return new WaitForFixedUpdate();
        }

        _onHide?.Invoke();
        SceneManager.LoadScene(0);
    }
}