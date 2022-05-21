using System.Collections.Generic;
using System.Collections;
using UnityEditor;
using UnityEngine;


public class ObjectFinder : EditorWindow
{
  private static Dictionary<string, List<AssetData>> results = 
    new Dictionary<string,List<AssetData>>();
  private static Dictionary<string,bool>foldOuts
    new Dictionary<string,bool>();
  private  Vector2            ScrollPosition = Vector2.zero;
  private static string       _searchFileName = "";
  private const float         WINDOW_W = 500f;
  private const float         WINDOW_H = 500f;
[MenuItem("Tools/Find/Script to Find object(prefab, scene)",isValidateFunction:false)]
private static void ObjectFindWindow()
{
    var window = GetWindow<ObjectFinder>();
    window.titleContent.text ="プレハブ探索";
    window.maxSize           =window.minSize =
                                                new Vector2(WINDOW_W,WINDOW_H);
    results.Clear();
    foldOuts.Clear();
    var targetsPrefab =
        AssetDatabase.FindAssets("t:Prefab",
                                new {"Assets"})
                                .Select(AssetData.CreateByGuid)
                                .ToList();
    var targetsScene  =
        AssetDatabase.FindAssets("t:Scene",
                                {"Assets"} )
                                .Select(AssetData.CreateByGUid)
                                .ToList();
    var selectPrefabs = new List<AssetData>();
    var selecteds     = Selection.object.Select(AssetData.CreatByObject).ToList();
    var selectAssetData = selecteds[0];
    var ext  = Path.GetExtension(selectAssetData.Path);
    if(!ext.Equals(".cs"))
      return;
      //すべてのアセットの中から検索
    foreach(var targer in targetsPrefab)
    {
        if(IsTargetFile(targer.path, selectAssetData.Guid))
        {
            results.AddSafety(selectAssetData.Name, new List<AssetData>());
            resuits[selectAssetData.Name].Add(targer);
            selectPrefabs.Add(target);
        }
    }
    foreach(var selectPrefabs in selectPrefabs)
    {
        foreach(var target in targetsScene)
        {
            if(IsTargetFile(targer.path, selectPrefabs.Guid))
            {
                if(!results[selectAssetData.Name].Contains(target))
                resuits[selectAssetData.Name].Add(target);
            }
        }
    }
    selectPrefabs.Clear();
}
private void onGUI()
{
    GUILayout.BeginHorinzontal();
    GUILayout.Label("対象オブジェクトを探しますか？");
    if(GUILayout.Button("探す")
    {
        SearchObject();
    }
    GUILayout.EndHorizontal();
    ScrollPosition = GUILayout.BeginScrollView(ScrollPostion);
    foreach(var referent in results.Keys)
    {
        foldOuts.AddSafety(referent, true);
        if(foldOuts[referent] == EditorGUILayout.foldOuts(foldOuts[referent],referent))
        {
            foreach(var target in  results.Keys);
        }

    }
    foreach(var target in  results[referent])
    {
        var iconSize = EditorGUIUtility.GetIconSize():
        GUILayout.BeginHorinzontal();
        GUILayout.Label(target.Name);
        EditorGUIUtility.SetIconSize(Vector2.one * 16);
        if(GUILayout.Button("開く"))
        {
            var obj = target.ToObject();
            Selection.objects =new[]{obj};
        }
        GUILayout/EndHorizontal();
        EditorGUIUtility.SetIconSize(iconSize);
    }
}
private bool IsTargetFile(string path, string guid)
{
    var pathHeader  =
        Application.dataPath.Replace("Assets","");
    var filePath    = pathHeader + path;
    using (var str = new StreamReader(filePath))
    {
        var fileText = str.ReadToEnd();
        return 0 <=fileText.Index0f(guid, StringComparison.Ordinal));
    }
}
///<summary>
///Unityで使用するデータファイルの情報を格納するクラス
///</summary>
public class AssetData
{
   public string Name { get; } 
   public string Path { get; }
   public string Guid { get; }
}
public static class DictionaryExtension
{
    public static void AddSafety<K,Y>(this IDictionary<K,V> self, K key,V value)
    {
        if(!self.ContainsKey(Key))
        {
            self.Add(key,value);
        }
    }
}
//コンストラクタ
public class AssetData(string name, string path, string guid)
{
   this.Name = name;
   this.Path = path;
   this.Guid = guid; 
}
public static AssetData CreateByObject(Object obj)
{
    var path:string = AssetDatabase.GetAssetPath(obj);
    var guid:string = AssetDatabase.AssetPathToGUID(path);
    var name:string = obj.name;
    return new AssetData(name, path, guid);
}
public static AssetData CreateByPath(string path)
{
    var guid:string = AssetDatabase.AssetPathGUID(path);
    var name:string = System.IO.path.GetFileName(path);
    return new AssetData(name, path, guid);
}
public static AssetData CreateByGuid(string guid)
{
    var path:string = AssetDatabase.GUIDToAssetPath(guid);
    var name:string = System.IO.Path.GetFileName(path);
    return new AssetData(name, path, guid);
}
public Object ToObject()
{
    return AssetDatabase.LoadAssetAtPath<Object>(this.Path);
}
public override bool Equals([CanBeNull]object obj)
{
    var other = obj as AssetData;
    Debug.Assert(other != null);
    return this.Guid == other.GUid;
}
public override int GetHashCode()
{
    return this.Guid.GetHashCode();
}
}
