using UnityEngine;
using System.Collections;
using Mobs.Stormtrooper;
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


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Stormtrooper"))
        {
            Stormtrooper stormtrooper = other.gameObject.GetComponent<Stormtrooper>();
            if (stormtrooper != null)
            {
                stormtrooper?.GetHeathInterface?.SetDamage(100);
            }
        }
    }

    public void InverseVelosity() {
        _rigitBody.velocity = -10 * gameObject.transform.forward;
    }

    private IEnumerator LifeBullet() {
        yield return new WaitForSeconds(_timeLife);
        Destroy(gameObject);
    }
}
