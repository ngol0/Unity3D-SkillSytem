using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillItem", menuName = "SkillSO/SkillItem")]
public class SkillItem : ScriptableObject
{
    public int id;
    public string displayName;
    [TextArea(3,10)] public string description;
    public ITarget targetingStratergy;
    public IFilter[] filterList;
    public IEffect[] effectList;
    public float cooldownTime;
    public float manaCost;

    public SkillData data;
    Mana mana;
    SkillManager cooldown;

    public void Use(GameObject user, Vector3 instantPoint)
    {
        data = new SkillData(user);
        mana = user.GetComponent<Mana>();

        if (manaCost > mana.CurMana) return;

        ActionManager actionManager = user.GetComponent<ActionManager>();
        actionManager.StartAction(data);

        cooldown = user.GetComponent<SkillManager>();
        if (!cooldown || cooldown.GetCoolDownTime(this) > 0) return;

        data.instantPoint = instantPoint;
        targetingStratergy.StartTarget(data, ProcessTargets);
    }

    public void ProcessTargets()
    {
        if (data.IsCanceled) return;
        if (!mana.UseMana(manaCost)) return;
        cooldown.StartCoolingDown(this, cooldownTime);

        //filter target
        foreach (var filter in filterList)
        {
            data.targets = filter.Filter(data.targets);
        }
        
        //apply effect
        //todo: when applying effect, prevent other actions from starting
        foreach (var effect in effectList)
        {
            effect.ApplyEffect(data, () => OnDoneEffect(effect.name));
        }
    }

    private void OnDoneEffect(string name = "")
    {
        
    }
}
