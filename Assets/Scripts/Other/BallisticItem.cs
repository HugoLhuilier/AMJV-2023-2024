using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;

[RequireComponent(typeof(Rigidbody))]
public class BallisticItem : MonoBehaviour
{
    [SerializeField] private float travelTime = 3;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void ThrowItem(Vector3 initPos, Vector3 targetPos, float travelTime)
    {
        Vector3 trajet = targetPos - initPos;
        Vector3 initForce = (trajet / travelTime) - (travelTime * Physics.gravity / 2);

        rb.AddForce(initForce, ForceMode.Impulse);
    }

    public static BallisticItem LaunchItem(GameObject go, Transform pLaunchPos, Vector3 pDestPos)
    {
        GameObject insBullet = Instantiate(go, pLaunchPos.position, pLaunchPos.rotation);
        BallisticItem balComp = insBullet.GetComponent<BallisticItem>();

        balComp.ThrowItem(pLaunchPos.position, pDestPos, balComp.travelTime);

        return balComp;
    }
}
