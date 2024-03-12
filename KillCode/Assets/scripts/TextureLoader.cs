using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;


public class TextureLoader : EditorWindow
{
    private string _textureFolderPath;

    [MenuItem("Window/TextureLoader")]
    public static void ShowWindow()
    {
        GetWindow<TextureLoader>();
    }

    private void OnGUI()
    {
        _textureFolderPath = EditorGUILayout.TextField("Texture Folder Path", _textureFolderPath);

        if (GUILayout.Button("Import Textures"))
        {
            ImportTextures(_textureFolderPath);
        }
    }

    private void ImportTextures(string folderPath)
    {
        // 폴더 이름으로 새로운 머티리얼 생성
        string materialName = Path.GetFileNameWithoutExtension(folderPath);
        Material material = new Material(Shader.Find("Standard"));

        // 폴더 내에 있는 이미지 확인
        string[] files = Directory.GetFiles(folderPath);

        foreach (string file in files)
        {
            string textureName = Path.GetFileNameWithoutExtension(file);
            Texture2D texture = AssetDatabase.LoadAssetAtPath<Texture2D>(file);

            // "_" 다음에 있는 글자로 채널명 파악
            string channelName = textureName.Split('_')[1];

            // 생성한 머티리얼에 채널명을 토대로 이미지 할당
            material.SetTexture(channelName, texture);
        }

        // 머티리얼 저장
        AssetDatabase.CreateAsset(material, $"Assets/Materials/{materialName}.mat");
    }
}