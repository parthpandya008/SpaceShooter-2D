using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

public class WeaponFactory
{
    private Dictionary<WeaponType, Type> weaponsByType;

    public WeaponFactory()
    {
        var weaponsType = Assembly.GetAssembly(typeof(BaseWeapon)).GetTypes().
            Where
            (
                mytype => mytype.IsClass && !mytype.IsAbstract && mytype.IsSubclassOf(typeof(BaseWeapon))
            );
        weaponsByType = new Dictionary<WeaponType, Type>();
        foreach (var type in weaponsType)
        {
            var temp = Activator.CreateInstance(type) as BaseWeapon;
            weaponsByType.Add(temp.Type, type);
        }
    }

    public  BaseWeapon GetWeapon(WeaponType weaponType)
    {
        if (weaponsByType.ContainsKey(weaponType))
        {
            Type type = weaponsByType[weaponType];
            BaseWeapon weapon = (BaseWeapon)Activator.CreateInstance(type);
            return weapon;
        }
        return null;
    }

    internal IEnumerable<WeaponType> GetWeaponsNames()
    {
        return weaponsByType.Keys;
    }
    

}
