using System.Collections;
using System.Collections.Generic;
using BBSamples.PQSG;
using UnityEngine;
using UnityEngine.AI;

public class redes : MonoBehaviour
{
    [SerializeField] private DoneDayNightCycle dayNightCycle;
    [SerializeField] MovementController movementController;
    [SerializeField] private EnemySystem enemySystem;

    [SerializeField] private Material skyboxNeblina;
    [SerializeField] private Material skyboxLluvia;
    [SerializeField] private Material skyboxLunaSangrienta;

    private Vector3 Pneblina, Plluvia,PlunaSagrienta;
    private float qn,qll,qls;
    public float time = 0.5f;

    void Start()
    {
        Pneblina = new Vector3(0, 0, 0);
        Plluvia = new Vector3(0, 0, 0);
        PlunaSagrienta = new Vector3(0, 0, 0);
        qn = 0f;
        qll = 0f;
        qls = 0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(Redes(time));
        }

    }

    public void NocheDia()
    {
        if(dayNightCycle.isNight)
        {
            Plluvia.x = 0.1f;
            Pneblina.x = 0.5f;
            PlunaSagrienta.x = 0.4f;
        }
        else
        {
            Plluvia.x = 0.1f;
            Pneblina.x = 0.3f;
            PlunaSagrienta.x = 0.2f;
        }
    }

    public void Item()
    {
        if(movementController.Item)
        {
            Plluvia.y = 0.2f;
            Pneblina.y = 0.5f;
            PlunaSagrienta.y = 0.5f;
        }
        else
        {
            Plluvia.y = 0.3f;
            Pneblina.y = 0.1f;
            PlunaSagrienta.y = 0.1f;
        }
    }

    public void Atack()
    {
        if(enemySystem.isActack)
        {
            Plluvia.z = 0.1f;
            Pneblina.z = 0.2f;
            PlunaSagrienta.z = 0.6f;
        }
        else
        {
            Plluvia.z = 0.3f;
            Pneblina.z = 0.2f;
            PlunaSagrienta.z = 0.01f;
        }

    }

    public IEnumerator Redes(float delay)
    {
        yield return new WaitForSeconds(delay);
        NocheDia();
        Item();
        Atack();

        qn = Pneblina.x * Plluvia.x * PlunaSagrienta.x;
        qll = Pneblina.y * Plluvia.y * PlunaSagrienta.y;
        qls = Pneblina.z * Plluvia.z * PlunaSagrienta.z;

        if(qn > qll && qn > qls)
        {
            RenderSettings.skybox = skyboxNeblina;
            // Acticar el componente Fog y establecer la densidad en 0.06
            RenderSettings.fog = true;
            RenderSettings.fogDensity = 0.06f;
        }
        else if(qll > qn && qll > qls)
        {
            RenderSettings.skybox = skyboxLluvia;
            RenderSettings.fog = false;
        }
        else
        {
            RenderSettings.skybox = skyboxLunaSangrienta;
            RenderSettings.fog = false;
        }

    }





}
