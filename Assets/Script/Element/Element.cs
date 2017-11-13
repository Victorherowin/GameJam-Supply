using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IElementEffect
{
    void Effect(GameObject player);
    bool EffectComplete();//效果是否完成
}

public abstract class Element : MonoBehaviour
{
    public virtual bool CanAttachEffect(GameObject player) { return true; }
    public abstract void AttachEffect(GameObject player);
    public abstract Color GetElementColor();


    public static void ElementGenerator(System.Type type, Transform p)
    {
        GameObject prefab = Resources.Load<GameObject>("perfab/" + type.ToString().Replace("_", "-"));
        GameObject obj = GameObject.Instantiate(prefab);
        var dir = p.forward;
        dir.y = 0.0f;
        obj.transform.localPosition = p.position + dir * 1.8f;
    }
}