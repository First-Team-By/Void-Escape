using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


public class EntityResistances
{
    public float DamageResistance { get; set; }

    public float BleedResistance { get; set; } 

    public float BurnResistance { get; set; }

    public float PoisonResistance { get; set; }

    public static EntityResistances operator +(EntityResistances entityResistances1, EntityResistances entityResistances2)
    {
        EntityResistances result = new EntityResistances();
        PropertyInfo[] properties = typeof(EntityResistances).GetProperties();

        foreach (PropertyInfo property in properties)
        {
            if (property.PropertyType == typeof(float))
            {
                float value1 = (float)property.GetValue(entityResistances1);
                float value2 = (float)property.GetValue(entityResistances2);

                property.SetValue(result, value1 + value2);
            }
        }

        return result;
    }

    public static EntityResistances operator -(EntityResistances entityResistances1, EntityResistances entityResistances2)
    {
        EntityResistances result = new EntityResistances();
        PropertyInfo[] properties = typeof(EntityResistances).GetProperties();

        foreach (PropertyInfo property in properties)
        {
            if (property.PropertyType == typeof(float))
            {
                float value1 = (float)property.GetValue(entityResistances1);
                float value2 = (float)property.GetValue(entityResistances2);

                var difference = Math.Clamp(value1 - value2, 0, float.MaxValue);
                property.SetValue(result, difference);
            }
        }

        return result;
    }
}

