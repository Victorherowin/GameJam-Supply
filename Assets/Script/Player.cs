using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public Element Element;
    public ParticleSystem ParticleEffect;
    private List<IElementEffect> m_effect_list = new List<IElementEffect>();

    public AudioSource AbsortSound;
    //private Color m_current_color;
    //private Color m_middle_color;
    //private Color m_step_color;


    //public void Awake()
    //{
    //    m_current_color = GetComponentInChildren<MeshRenderer>().material.color;
    //    m_middle_color=m_current_color;
    //}

    public void AddEffect(IElementEffect effect)
    {
        m_effect_list.Add(effect);
    }

    public void AddElement(Element ele)
    {
        Element = ele;
    }

    void Update ()
    {
        if(this.transform.position.y<-5)
        {
            ui_time.ui_t.show_game_over();
        }
        //if (m_element_list.Count != 0)
        //{
        //    var color = m_element_list[0].GetElementColor();
        //    m_step_color = (color - m_current_color)/50.0f;
        //    m_current_color = color;
        //}
        //    //颜色渐变
        //if (m_middle_color != m_current_color)
        //{
        //    m_middle_color += m_step_color;
        //    var ren = GetComponentsInChildren<MeshRenderer>();
        //    ren[0].material.color = m_middle_color;
        //}

        if (Input.GetButton("UseElement")&&ui_time.ui_t.game_open)//释放元素
        {
            if (Element == null) return;
            if (Element.CanAttachEffect(gameObject))
            {
                Element.AttachEffect(gameObject);
                ParticleEffect.gameObject.SetActive(false);
                Destroy(Element.gameObject);
                Element = null;
            }
        }

        if(Input.GetButton("ThrowElement"))
        {
            if (Element == null) return;
            Element.ElementGenerator(Element.GetType(), transform);
            ParticleEffect.gameObject.SetActive(false);
            Destroy(Element.gameObject);
            Element = null;
        }

        foreach(var effect in m_effect_list)//元素效果
        {
            effect.Effect(gameObject);
        }

        foreach(var effect in m_effect_list)//清除过期效果
        {
            if (effect.EffectComplete())
            {
                m_effect_list.Remove(effect);
                break;
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (Element != null) return;
        if (col.tag == "ElementBody")
        {
            var obj = col.transform.parent;
            AddElement(obj.GetComponent<Element>());
            Vector3 pos = transform.position;
            Destroy(obj.GetComponentInChildren<ElementTrace>().gameObject);
            Destroy(obj.GetComponentInChildren<SphereCollider>());
            obj.transform.parent = transform;
            obj.transform.position = Vector3.zero;
            obj.transform.localPosition = -Vector3.forward * 1.15f;
            var mainModule = ParticleEffect.main;
            mainModule.startColor = Element.GetElementColor();

            AbsortSound.Play();

            ParticleEffect.gameObject.SetActive(true);
            //AudioSource.PlayClipAtPoint(pickupClip, pos, 0.3f);
        }
    }
}
