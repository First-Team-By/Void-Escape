using System.Reflection;

public class Resource
{
    public int Energy { get; set; }
    public int Medicine { get; set; }
    public int Metal { get; set; }  
    public int Electronics { get; set; }


    public static Resource operator +(Resource resources1, Resource resources2)
    {
        Resource result = new Resource();
        PropertyInfo[] properties = typeof(Resource).GetProperties();

        foreach (PropertyInfo property in properties)
        {
            if (property.PropertyType == typeof(int))
            {
                int value1 = (int)property.GetValue(resources1);
                int value2 = (int)property.GetValue(resources2);

                property.SetValue(result, value1 + value2);
            }
        }

        return result;
    }

    public static Resource operator -(Resource resources1, Resource resources2)
    {
        Resource result = new Resource();
        PropertyInfo[] properties = typeof(Resource).GetProperties();

        foreach (PropertyInfo property in properties)
        {
            if (property.PropertyType == typeof(int))
            {
                int value1 = (int)property.GetValue(resources1);
                int value2 = (int)property.GetValue(resources2);

                property.SetValue(result, value1 - value2);
            }
        }

        return result;
    }


    public bool IsEnought(Resource resource)
    {
        return Energy >= resource.Energy
            && Medicine >= resource.Medicine
            && Metal >= resource.Metal
            && Electronics >= resource.Electronics;
    }
}
