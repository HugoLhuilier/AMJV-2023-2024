using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float shootPower = 50;
    [SerializeField] private float lifeTime = 10;

    public Team bulletTeam;
    public int bulletDamages = 5;

    private float timeLived = 0;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(shootPower * transform.forward, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        timeLived += Time.deltaTime;
        if (timeLived > lifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Unit unit = collision.gameObject.GetComponent<Unit>();

        if (unit != null && !unit.team.isSameTeam(bulletTeam))
        {
            unit.lifeComp.GetDamages(bulletDamages);
        }

        Destroy(gameObject);
    }
}
