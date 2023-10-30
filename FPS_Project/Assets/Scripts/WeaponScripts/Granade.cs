using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{
    [SerializeField] private float _radius = 30f;
    [SerializeField] private float _rayDistance = 0.1f;
    [SerializeField] private int _damage = 100;
    [SerializeField] private Transform _startPoint;

    public ParticleSystem Explosion;
    private TakeDamage _takeDamage;

    public void Start()
    {
        StartCoroutine(ExplosionGrande(3));
    }

   
    public IEnumerator ExplosionGrande(int delay)
    {
        
        yield return new WaitForSeconds(delay);
        gameObject.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        Explosion.gameObject.SetActive(true);



        var Players = Physics.SphereCastAll(_startPoint.position, _radius, _startPoint.up);

        foreach (var raycastHit in Players)
        {
            if (raycastHit.rigidbody is not null)
            {
                if (raycastHit.collider.tag == "PlayerHitBox")
                {
                    _takeDamage = raycastHit.transform.GetComponent<TakeDamage>();

                    _takeDamage.PlayerHit(_damage);
                }

                if (raycastHit.collider.tag == "AI")
                {
                    _takeDamage = raycastHit.transform.GetComponent<TakeDamage>();
                    _takeDamage.Hit(_damage);
                }



            }
        }
        yield return new WaitUntil(() => !Explosion.isPlaying);
        Destroy(gameObject);
    }

    
}



