using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementEffect_H : IElementEffect
{

    private bool m_complete=false;
    private Vector3 moveDirection;
    private float m_time = 0.0f;
    public void Effect(GameObject player)
    {
        PlayerMove player_mov = player.GetComponent<PlayerMove>();
        player_mov.LongJump();
        m_complete = true;
    }

    public bool EffectComplete()
    {
        return m_complete;
    }
}

public class Element_H : Element {


    public override void AttachEffect(GameObject player)
    {
        player.GetComponent<Player>().AddEffect(new ElementEffect_H());
    }

    public override bool CanAttachEffect(GameObject player)
    {
        return !player.GetComponent<PlayerMove>().IsJump();
    }
    public override Color GetElementColor()
    {
        return new Color(0.909803921f, 0.95686274509803f, 0.1529411f);
    }
}
