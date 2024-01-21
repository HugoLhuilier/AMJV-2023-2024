using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;

[RequireComponent(typeof(Rigidbody))]
public class BallisticItem : MonoBehaviour
{
    [SerializeField] private float travelTime = 3;

    private Vector3 launchPos;
    private Vector3 destinationPos;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        Vector3 trajet = destinationPos - launchPos;
        Vector3 initForce = (trajet / travelTime) - (travelTime * Physics.gravity / 2);

        rb.velocity = initForce;
    }

    public static BallisticItem LaunchItem(GameObject go, Transform pLaunchPos, Vector3 pDestPos)
    {
        GameObject insBullet = Instantiate(go, pLaunchPos.position, pLaunchPos.rotation);
        BallisticItem balComp = insBullet.GetComponent<BallisticItem>();

        balComp.launchPos = pLaunchPos.position;
        balComp.destinationPos = pDestPos;

        return balComp;
    }
}
