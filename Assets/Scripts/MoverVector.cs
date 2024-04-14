using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverVector : MonoBehaviour
{
    [SerializeField, Min(.0f)] private float _speed;

    public void Move(Vector3 pos)
    {
        StartCoroutine(Moving(pos));
    }

    private IEnumerator Moving(Vector3 pos)
    {
        while (Vector3.Distance(transform.position, pos) > .1f)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                pos, _speed * Time.fixedDeltaTime);
            yield return new WaitForFixedUpdate();
        }
    }
}