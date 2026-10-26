using UnityEditorInternal;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Pistola : MonoBehaviour
{
    [Header("Referencias")]

    public Transform pistola;
    public Transform firePoint;
    public LineRenderer Line;
    //public GameObject fx1, fx2;

    private XRGrabInteractable grabInteract;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        grabInteract = GetComponent<XRGrabInteractable>();

        grabInteract.activated.AddListener(x => OnActivated());
    }

    private void OnActivated()
    {
        StartCoroutine(Disparando());
    }

    IEnumerator Disparando()
    {
        RaycastHit hitInfo;

       // Instantiate(fx1, firePoint.position, firePoint.rotation);

        if (Physics.Raycast(firePoint.position, firePoint.forward, out hitInfo)){
            Line.SetPosition(0, firePoint.position);
            Line.SetPosition(1, hitInfo.point);
            //Instantiate(fx2,hitInfo.point, hitInfo.collider.gameObject.transform.rotation);
        }
        else
        {
            Line.SetPosition(0, firePoint.position);
            Line.SetPosition(1, firePoint.position + firePoint.forward * 30f);
        }

        Line.enabled = true;
        yield return new WaitForSeconds(0.02f);

        Line.enabled = false;
    }
    
}
