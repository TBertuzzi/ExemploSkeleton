using System;
namespace ExemploSkeleton.Helpers
{
    public static class ObjectConverter
    {
        public static T CastModel<T>(object data)
        {
            var ret = (T)Activator.CreateInstance(typeof(T));

            foreach (var p in ret.GetType().GetProperties())
            {
                if (data.GetType().GetProperty(p.Name) != null)
                    p.SetValue(ret, data.GetType().GetProperty(p.Name)?.GetValue(data));
            }

            return ret;
        }
    }
}
