using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class LaserBullet : MonoBehaviour
{
    private float _timeLife = 1.5f;
    Rigidbody _rigitBody;
    private void Start(){
        _rigitBody = gameObject.GetComponent<Rigidbody>();
        _rigitBody.velocity = 10 * gameObject.transform.forward;

        StartCoroutine(LifeBullet());
    }

    private IEnumerator LifeBullet() {
        yield return new WaitForSeconds(_timeLife);
        Destroy(gameObject);
    }
}
