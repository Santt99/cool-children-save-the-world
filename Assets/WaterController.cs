using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    private Material _WaterMaterial;
    private bool hasCollided = false;
    private IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        _WaterMaterial = gameObject.GetComponent<MeshRenderer>().material;

    }
    private void Update()
    {
        if (hasCollided)
        {
            coroutine = ReduceWaves();
            StartCoroutine(coroutine);
        }
    }

    void OnCollisionEnter(Collision other)
    {

        if (_WaterMaterial.HasProperty("_CollisionPosition"))
        {
            ContactPoint contact = other.GetContact(0);
            Vector3 localPostion = transform.InverseTransformPoint(contact.point);
            _WaterMaterial.SetFloat("_Collided", 1);
            _WaterMaterial.SetVector("_CollisionPosition", localPostion);
            _WaterMaterial.SetFloat("_WaveAmplitud", 0.02f);
            hasCollided = true;

        }

    }

    private IEnumerator ReduceWaves()
    {


        float waveAmplitude = _WaterMaterial.GetFloat("_WaveAmplitud");
        if (waveAmplitude >= 0)
        {
            yield return new WaitForSecondsRealtime(0.25f);
            _WaterMaterial.SetFloat("_WaveAmplitud", waveAmplitude - 0.0025f);

        }
        else
        {


            _WaterMaterial.SetFloat("_Collided", 0);

            hasCollided = false;
        }

    }
}
