using System.Collections;
using UnityEngine;

public class MoverTransform : MonoBehaviour
{
    [SerializeField, Min(.0f)] private float _speed;

    public void Move(Transform target)
    {
        StartCoroutine(Moving(target));
    }

    private IEnumerator Moving(Transform target)
    {
        while (Vector3.Distance(transform.position, target.position) > .1f)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                                                            target.position,
                                              _speed * Time.fixedDeltaTime);
            yield return new WaitForFixedUpdate();
        }
    }
}