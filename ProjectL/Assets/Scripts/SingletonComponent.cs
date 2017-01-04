using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T m_Instance = null;
	private static object m_Lock = new object();
	private static bool m_IsInstanceNull;

	public static T Instance
	{
		get
		{
			lock (m_Lock)
			{
				if (m_Instance == null && !m_IsInstanceNull)
				{
					GameObject singleton = new GameObject ();
					m_Instance = singleton.AddComponent<T> ();
					singleton.name = typeof(T).ToString ();

					m_IsInstanceNull = false;
				}
				return m_Instance;
			}
		}	
	}

	public static bool IsInstanceNull
	{
		get { return m_IsInstanceNull;}
	}
}