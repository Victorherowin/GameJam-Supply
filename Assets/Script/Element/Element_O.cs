using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementEffect_O : IElementEffect
{
    bool m_complete = false;
    public void Effect(GameObject player)
    {
        ui_time.ui_t.open_time += 5;
        m_complete = true;
    }

    public bool EffectComplete()
    {
        return m_complete;
    }
}

public class Element_O : Element {
    public override void AttachEffect(GameObject player)
    {
        player.GetComponent<Player>().AddEffect(new ElementEffect_O());
    }

    public override Color GetElementColor()
    {
        return new Color(0.192156f,0.745098f, 0.755098f);
    }
}
