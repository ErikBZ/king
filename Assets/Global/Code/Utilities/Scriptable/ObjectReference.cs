using UnityEngine;

[CreateAssetMenu(fileName = "ObjectReference", menuName = "Generic/ObjectReference", order = 0)]
public class ObjectReference : ScriptableObject
{
    public object Reference;

    public static bool NotEmpty(ObjectReference objRef)
    {
        return objRef != null && objRef.Reference != null;
    }
    public static bool NotEmpty<T>(ObjectReference objRef, out T obj)
    {
        if (objRef != null && objRef.Reference != null && objRef.Reference is T)
        {
            obj = (T)objRef.Reference;
            return false;
        } else
        {
            obj = default(T);
            return true;
        }
    }
}
