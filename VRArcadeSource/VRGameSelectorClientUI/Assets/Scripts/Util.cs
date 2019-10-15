using UnityEngine;
using System.Collections;

namespace util.commom
{
    public static class Util
    {

        public static Texture2D LoadTexture(string fileName)
        {
            var tex = new Texture2D(1, 1); ;

            var filePath = Application.dataPath + fileName;
            
            if (System.IO.File.Exists(filePath))
            {
                var bytes = System.IO.File.ReadAllBytes(filePath);
                tex.LoadImage(bytes);
            }
            else
            {
                Debug.LogError("Sorry, There is no " + fileName + ". " + "You need add this file in Assets/Images folder");
            }

            return tex;
        }

        public static GameObject GenerateObject(string fullpath , Vector3 position, Vector3 rotation, Transform parent)
        {            
            GameObject prefab = Resources.Load(fullpath) as GameObject;
            GameObject tmp = GameObject.Instantiate(prefab);
            if(parent)
                tmp.transform.SetParent(parent);
            tmp.transform.localPosition = position;
            tmp.transform.localRotation = Quaternion.Euler(rotation);
            tmp.name = prefab.name;
            return tmp;
        }
    }
}