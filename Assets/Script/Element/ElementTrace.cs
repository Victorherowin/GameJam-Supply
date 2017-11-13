using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementTrace : MonoBehaviour {
    public string PlayerAimName="Player";
    public string MatrixAimName="Matrix";
    public float MoveSpeed=1.0f;

    private bool m_is_matrix_raduis = false;

    void OnTriggerStay(Collider collision)
    {
        var aim = collision.transform.position;
        var pos = transform.parent.position;
        var dir = Vector3.Normalize(aim - pos)*MoveSpeed;
        if (collision.GetComponent<Player>().Element != null) return;
        if (collision.name == MatrixAimName)
        {
            transform.parent.Translate(dir * Time.fixedDeltaTime);
            m_is_matrix_raduis = true;
        }

        if (!m_is_matrix_raduis && collision.name == PlayerAimName)
        {
            transform.parent.Translate(dir* Time.fixedDeltaTime);
        }
    }
}
