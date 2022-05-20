using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
#if UNITY_EDITOR

/// <summary>
/// カードマスターデータをスクリプタブルオブジェクト化する
/// </summary>

public class MakeCardMasterDataScriptable : ScriptableObject
{
    private static readonly string _fileName = "CardMasterData";
    private static readonly string _assetPath = "Assets/BuiltInResources/Common/Datas/";
    private static readonly string _readFileName =Application.dataPath + $"/ScriptableDataBase/Editor/{_fileName}.csv";

   [MenuItem("ScriptableObject/Create Card Master Data")]
   private static void MakeCardMasterDataScriptables()
    {
       string[] guid = AssetDatabase.FindAssets($"t:{_fileName}"); 
       //すでに存在する場合は上書きする
       if(0 < guids.Length)
       {
         var emptyCardMasterAsset = AssetDatabase
           .LoadAssetAtPath<CardMasterData>(AssetDatabase.GUIDToAssetPath(guids[0]));
           MakeCardMasterData(emptyCardMasterAsset);
       }
       //存在しない場合は新規作成する
       else
       {
         var emptyCardMasterAsset = CreateInstance<CardMasterData>();
         MakeCardMasterData(emptyCardMasterAsset);
         var assetName = $"{_assetPath}{_fileName}.asset";
         AssetDatabase.CreatAsset(emptyCardMasterAsset,assetName);
         AssetDatabase.Refresh;
       }
    }
    private static void MakeCardMasterData(CardMasterData cardMasterData)
    {
     // モデルデータを削除する
     cardMasterData.card_masters.Clear();
     using(var str = new StreamReader(_readFileName))
     {
　　　　//　ファイルを最後まで読み込む
        var csvDatas =str.ReadToEnd();
       // 改行コードを \nに統一する
        csvDatas = csvDatas.Replace("\r\n","\n").Replace("\r","\n");
        // データ列に分解して改行だけのデータ列は除外する
        var csvLists = csvDatas.Split('\n').Where(st => !string.IsNullOrEmpty(st)).ToList();
        csvLists.ForEach(csvDatas =>
        {
          //csvのデータを要素ごとに分割する
          var csvSplitData = csvData.Split(','.ToList());
          // 船頭のIDを保存するワークを用意する
          int id = 0;
          //　船頭のIDが数値にできればデータと判断する
          if(int.TryParse(sevSplitData[0],out id))
          {
            var cardCharModel = new CardMasterData.CardMaster();
            cardCharModel.crd_id = id; //カードID
            cardCharModel.crd_pct_id = csvSplitData[1];//グラフィック名
            cardCharModel.crd_name = csvSplitData[2];//名称
            cardCharModel.crd_class = int.Parse(csvSplitData[3]);//クラス
            cardCharModel.crd_stars = int.Parse(csvSplitData[4]);//レア度
            cardCharModel.crd_nikname = csvSplitData[5];//クラス名
            cardCharModel.crd_level_limit = int.Parse(csvSplitData[6]);//レベル上限
            cardCharModel.crd_cost = int.Parse(csvSplitData[7]);//カードコスト
            cardCharModel.skill_hand_id = int.Parse(csvSplitData[8]);//手札スキルID
            cardCharModel.skill_hand_gain_lvl = int.Parse(csvSplitData[9]);//手札スキル獲得レア度
            cardCharModel.skill_enter_id = int.Parse(csvSplitData[10]);//登場スキルID
            cardCharModel.skill_enter_gain_lvl = int.Parse(csvSplitData[11]);//登場スキル獲得レア度
            cardCharModel.skill_exit_id = int.Parse(csvSplitData[12]);//退場スキルID
            cardCharModel.skill_exit_gain_lvl = int.Parse(csvSplitData[13]);//退場スキル獲得レア度
            cardCharModel.skill_revenge_id = int.Parse(csvSplitData[14]);//反攻スキルID
            cardCharModel.skill_revenge_gain_lvl = int.Parse(csvSplitData[15]);//反攻スキル獲得レア度
            cardCharModel.chr_caption_tex = csvSplitData[16];//カードに表示する
            cardCharModel.chr_edition = int.Parse(csvSplitData[17]);//エディション名
            cardCharModel.chr_next_id = int.Parse(csvSplitData[18]);//進化ID
            cardCharModel.chr_next_id = int.Parse(csvSplitData[19]);//値段
            cardMasterData.card_masters.Add(cardCharModel);
          }
        });

     }
    }
}
#endif