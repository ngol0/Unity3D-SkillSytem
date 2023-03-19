using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{ 
    static bool applicationIsQuitting = false;
    static T _instance;
    public static T instance
    {
        get
        {
            if (applicationIsQuitting)
            {
                return null;
            }
            if (_instance == null)
            {
                _instance = (T)FindObjectOfType(typeof(T));
                
                if (_instance == null)
                {
                    GameObject singleton = new GameObject();
                    _instance = singleton.AddComponent<T>();
                    singleton.name = typeof(T).ToString();
                }
            }
            return _instance;
        }
    }
    public virtual void Awake()
    {
        applicationIsQuitting = false;
        CheckInstance();
    }

    public void OnDestroy()
    {
        applicationIsQuitting = true;
    }
    // Update is called once per frame
    protected bool CheckInstance()
    {
       if (this == instance) return true;
       Destroy(this);
       return false; 
    }
}
