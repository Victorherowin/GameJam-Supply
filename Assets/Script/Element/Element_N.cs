using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementEffect_N : IElementEffect
{

    bool m_complete = false;
    bool m_first = true;
    float m_time = 0.0f;
    float player_speed;
    public void Effect(GameObject player)
    {
        //var player_move = player.GetComponent<PlayerMove>();
        //if (m_first)
        //{
        //    m_first = false;
        //    player_speed = player_move.speed;
        //}

        //if (m_time >= 2.0f)
        //{
        //    m_complete = true;
        //    player_move.speed = player_speed;
        //    return;
        //}
        //player_move.speed = 9.0f;

        //m_time += Time.deltaTime;
        
        Vector3 dir = player.transform.forward.normalized;
        RaycastHit hit = new RaycastHit();
        dir.y = 0.0f;
        if (!Physics.Raycast(player.transform.position, dir, out hit, 3.0f))
            player.transform.Translate(dir * 3.0f,Space.World);
        else
            player.transform.Translate(dir * hit.distance - dir * 0.8f,Space.World);
        m_complete = true;
    }

    public bool EffectComplete()
    {
        return m_complete;
    }
}

public class Element_N : Element
{
    public override void AttachEffect(GameObject player)
    {
        player.GetComponent<Player>().AddEffect(new ElementEffect_N());
    }

    public override Color GetElementColor()
    {
        return new Color(0.788235f, 0.0f, 0.0f);
    }
}
