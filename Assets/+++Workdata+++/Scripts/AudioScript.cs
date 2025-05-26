using System;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
   private static AudioScript instance;

   private void Awake()
   {
      if (instance == null)
      {
         instance = this;
         DontDestroyOnLoad(gameObject);
      }
      else
      {
         Destroy(gameObject);
      }
   }
}
