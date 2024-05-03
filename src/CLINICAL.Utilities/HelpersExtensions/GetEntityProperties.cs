using System.Reflection;

namespace CLINICAL.Utilities.HelpersExtensions
{
    public static class GetEntityProperties
    {
        //PARA NO DEVOLVER VALORES NULOS EN ENTIDADES
        public static Dictionary<string, object> GetPropertiesWithValues<T>(this T entity)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            var entityParams = new Dictionary<string, object>();

            foreach (PropertyInfo property in properties)
            {
                object value = property.GetValue(entity)!;

                if (value != null)
                {
                    entityParams[property.Name] = value;
                }
            }

            return entityParams;
        }
    }
}
