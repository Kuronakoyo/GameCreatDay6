using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CardMasterData
{
   [Serializable]
   public class CardMaster
   {
   public int crd_id;
   public string crd_pct_id;	
   public string crd_name;
   public int chr_class;
   public int chr_stars;
   public string chr_nikname;
   public int chr_level_limit;
   public int crd_cost;	
   public int skill_hand_id;
   public int skill_hand_gain_lvl;
   public int skill_enter_id;	
   public int skill_enter_gain_lvl;	
   public int skill_exit_id;	
   public int skill_exit_gain_lvl;
   public int skill_revenge_id;	
   public int skill_revenge_gain_lvl;	
   public string chr_caption_tex;	
   public int chr_edition;	
   public int chr_next_id;	
   public int chr_price;
   }
   public List<CardMaster> card_masters = new List<CardMaster>();
}
