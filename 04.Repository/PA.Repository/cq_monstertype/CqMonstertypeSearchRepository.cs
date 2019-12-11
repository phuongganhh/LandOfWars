using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqMonstertypeSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public string name { get; set; }
		public int? sort { get; set; }
		public int? lookface { get; set; }
		public int? life { get; set; }
		public int? mana { get; set; }
		public int? dexterity { get; set; }
		public int? dodge { get; set; }
		public int? helmet_type { get; set; }
		public int? armor_type { get; set; }
		public int? weaponr_type { get; set; }
		public int? weaponl_type { get; set; }
		public int? attack_range { get; set; }
		public int? view_range { get; set; }
		public int? escape_life { get; set; }
		public int? attack_speed { get; set; }
		public int? move_speed { get; set; }
		public int? level { get; set; }
		public int? attack_user { get; set; }
		public int? drop_money_min { get; set; }
		public int? drop_money_max { get; set; }
		public int? size_add2 { get; set; }
		public int? action { get; set; }
		public int? run_speed { get; set; }
		public int? hot_power { get; set; }
		public int? cold_power { get; set; }
		public int? shake_power { get; set; }
		public int? drop_ring { get; set; }
		public int? drop_weapon { get; set; }
		public int? drop_shield { get; set; }
		public int? drop_shoes { get; set; }
		public int? drop_money_change { get; set; }
		public int? drop_item_change { get; set; }
		public int? magic_type { get; set; }
		public int? magic_def { get; set; }
		public int? magic_hitrate { get; set; }
		public int? ai_type { get; set; }
		public int? explode_change1 { get; set; }
		public int? explode_change2 { get; set; }
		public int? explode_change3 { get; set; }
		public int? drop_item_rule { get; set; }
		public int? atk_max { get; set; }
		public int? atk_min { get; set; }
		public int? atk_hot { get; set; }
		public int? atk_shake { get; set; }
		public int? atk_ice { get; set; }
		public int? atk_decay { get; set; }
		public int? def_adj { get; set; }
		public int? def_sub { get; set; }
		public int? def_hot { get; set; }
		public int? def_shake { get; set; }
		public int? def_sting { get; set; }
		public int? def_decay { get; set; }
		public int? weapon_amount { get; set; }
		public int? armor_amount { get; set; }
		public int? thruster_amount { get; set; }
		public int? d_stealitem { get; set; }
		public int? award_exp { get; set; }
		public int? drop_stone_change { get; set; }
		public int? drop_stone_min { get; set; }
		public int? drop_stone_max { get; set; }
		public int? magic_type1 { get; set; }
		public int? magic_type2 { get; set; }
		public int? magic_type3 { get; set; }
		public int? magic_assistan { get; set; }
		public int? magic_assistan2 { get; set; }
		public int? magic_passive { get; set; }
		public int? magic_passive2 { get; set; }
		public int? status_def { get; set; }
		public int? status_lv { get; set; }
		public int? somatotype { get; set; }
		public int? camp { get; set; }
		public int? drop_equip_coe { get; set; }
		public int? drop_ammo_coe { get; set; }
		public int? drop_part_coe { get; set; }
		public int? drop_amplifier_coe { get; set; }
		public int? drop_HumanItem_coe { get; set; }
		public int? drop_expendable_coe { get; set; }
		public int? drop_InsideItem_coe { get; set; }
		public int? drop_explode_coe { get; set; }
		public int? drop_Special_coe { get; set; }
		public int? special_type { get; set; }
		public int? drop_deltalev_coe { get; set; }
		public int? attribute_type { get; set; }
		public int? extra_battlelev { get; set; }
		public int? extra_exp { get; set; }
		public int? extra_damage { get; set; }
		public int? drop_stone_type { get; set; }
		public int? User_atk_adjust { get; set; }
		public int? exempt_damage { get; set; }
		public int? pertinence_magic { get; set; }
		public int? pertinence_magic_damage { get; set; }
		public int? pertinence_weapon { get; set; }
		public int? pertinence_weapon_damage { get; set; }
		public int? drop_emoney_coe { get; set; }
		public int? drop_other_coe { get; set; }
		public int? price { get; set; }
		public int? user_atk_mode { get; set; }
		public int? pertinence_transfrom { get; set; }
		public int? pertinence_transfrom_damage { get; set; }
		public int? weakness_tips { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_monstertype")
				.Select(
					"cq_monstertype.id",
					"cq_monstertype.name",
					"cq_monstertype.sort",
					"cq_monstertype.lookface",
					"cq_monstertype.life",
					"cq_monstertype.mana",
					"cq_monstertype.dexterity",
					"cq_monstertype.dodge",
					"cq_monstertype.helmet_type",
					"cq_monstertype.armor_type",
					"cq_monstertype.weaponr_type",
					"cq_monstertype.weaponl_type",
					"cq_monstertype.attack_range",
					"cq_monstertype.view_range",
					"cq_monstertype.escape_life",
					"cq_monstertype.attack_speed",
					"cq_monstertype.move_speed",
					"cq_monstertype.level",
					"cq_monstertype.attack_user",
					"cq_monstertype.drop_money_min",
					"cq_monstertype.drop_money_max",
					"cq_monstertype.size_add2",
					"cq_monstertype.action",
					"cq_monstertype.run_speed",
					"cq_monstertype.hot_power",
					"cq_monstertype.cold_power",
					"cq_monstertype.shake_power",
					"cq_monstertype.drop_ring",
					"cq_monstertype.drop_weapon",
					"cq_monstertype.drop_shield",
					"cq_monstertype.drop_shoes",
					"cq_monstertype.drop_money_change",
					"cq_monstertype.drop_item_change",
					"cq_monstertype.magic_type",
					"cq_monstertype.magic_def",
					"cq_monstertype.magic_hitrate",
					"cq_monstertype.ai_type",
					"cq_monstertype.explode_change1",
					"cq_monstertype.explode_change2",
					"cq_monstertype.explode_change3",
					"cq_monstertype.drop_item_rule",
					"cq_monstertype.atk_max",
					"cq_monstertype.atk_min",
					"cq_monstertype.atk_hot",
					"cq_monstertype.atk_shake",
					"cq_monstertype.atk_ice",
					"cq_monstertype.atk_decay",
					"cq_monstertype.def_adj",
					"cq_monstertype.def_sub",
					"cq_monstertype.def_hot",
					"cq_monstertype.def_shake",
					"cq_monstertype.def_sting",
					"cq_monstertype.def_decay",
					"cq_monstertype.weapon_amount",
					"cq_monstertype.armor_amount",
					"cq_monstertype.thruster_amount",
					"cq_monstertype.d_stealitem",
					"cq_monstertype.award_exp",
					"cq_monstertype.drop_stone_change",
					"cq_monstertype.drop_stone_min",
					"cq_monstertype.drop_stone_max",
					"cq_monstertype.magic_type1",
					"cq_monstertype.magic_type2",
					"cq_monstertype.magic_type3",
					"cq_monstertype.magic_assistan",
					"cq_monstertype.magic_assistan2",
					"cq_monstertype.magic_passive",
					"cq_monstertype.magic_passive2",
					"cq_monstertype.status_def",
					"cq_monstertype.status_lv",
					"cq_monstertype.somatotype",
					"cq_monstertype.camp",
					"cq_monstertype.drop_equip_coe",
					"cq_monstertype.drop_ammo_coe",
					"cq_monstertype.drop_part_coe",
					"cq_monstertype.drop_amplifier_coe",
					"cq_monstertype.drop_HumanItem_coe",
					"cq_monstertype.drop_expendable_coe",
					"cq_monstertype.drop_InsideItem_coe",
					"cq_monstertype.drop_explode_coe",
					"cq_monstertype.drop_Special_coe",
					"cq_monstertype.special_type",
					"cq_monstertype.drop_deltalev_coe",
					"cq_monstertype.attribute_type",
					"cq_monstertype.extra_battlelev",
					"cq_monstertype.extra_exp",
					"cq_monstertype.extra_damage",
					"cq_monstertype.drop_stone_type",
					"cq_monstertype.User_atk_adjust",
					"cq_monstertype.exempt_damage",
					"cq_monstertype.pertinence_magic",
					"cq_monstertype.pertinence_magic_damage",
					"cq_monstertype.pertinence_weapon",
					"cq_monstertype.pertinence_weapon_damage",
					"cq_monstertype.drop_emoney_coe",
					"cq_monstertype.drop_other_coe",
					"cq_monstertype.price",
					"cq_monstertype.user_atk_mode",
					"cq_monstertype.pertinence_transfrom",
					"cq_monstertype.pertinence_transfrom_damage",
					"cq_monstertype.weakness_tips"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_monstertype")
                        .Select("cq_monstertype.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_monstertype.id","%" + this.id.ToString() + "%");
			}
			if(this.name != null)
			{
				result = result.WhereLike("cq_monstertype.name","%" + this.name.ToString() + "%");
			}
			if(this.sort != null)
			{
				result = result.WhereLike("cq_monstertype.sort","%" + this.sort.ToString() + "%");
			}
			if(this.lookface != null)
			{
				result = result.WhereLike("cq_monstertype.lookface","%" + this.lookface.ToString() + "%");
			}
			if(this.life != null)
			{
				result = result.WhereLike("cq_monstertype.life","%" + this.life.ToString() + "%");
			}
			if(this.mana != null)
			{
				result = result.WhereLike("cq_monstertype.mana","%" + this.mana.ToString() + "%");
			}
			if(this.dexterity != null)
			{
				result = result.WhereLike("cq_monstertype.dexterity","%" + this.dexterity.ToString() + "%");
			}
			if(this.dodge != null)
			{
				result = result.WhereLike("cq_monstertype.dodge","%" + this.dodge.ToString() + "%");
			}
			if(this.helmet_type != null)
			{
				result = result.WhereLike("cq_monstertype.helmet_type","%" + this.helmet_type.ToString() + "%");
			}
			if(this.armor_type != null)
			{
				result = result.WhereLike("cq_monstertype.armor_type","%" + this.armor_type.ToString() + "%");
			}
			if(this.weaponr_type != null)
			{
				result = result.WhereLike("cq_monstertype.weaponr_type","%" + this.weaponr_type.ToString() + "%");
			}
			if(this.weaponl_type != null)
			{
				result = result.WhereLike("cq_monstertype.weaponl_type","%" + this.weaponl_type.ToString() + "%");
			}
			if(this.attack_range != null)
			{
				result = result.WhereLike("cq_monstertype.attack_range","%" + this.attack_range.ToString() + "%");
			}
			if(this.view_range != null)
			{
				result = result.WhereLike("cq_monstertype.view_range","%" + this.view_range.ToString() + "%");
			}
			if(this.escape_life != null)
			{
				result = result.WhereLike("cq_monstertype.escape_life","%" + this.escape_life.ToString() + "%");
			}
			if(this.attack_speed != null)
			{
				result = result.WhereLike("cq_monstertype.attack_speed","%" + this.attack_speed.ToString() + "%");
			}
			if(this.move_speed != null)
			{
				result = result.WhereLike("cq_monstertype.move_speed","%" + this.move_speed.ToString() + "%");
			}
			if(this.level != null)
			{
				result = result.WhereLike("cq_monstertype.level","%" + this.level.ToString() + "%");
			}
			if(this.attack_user != null)
			{
				result = result.WhereLike("cq_monstertype.attack_user","%" + this.attack_user.ToString() + "%");
			}
			if(this.drop_money_min != null)
			{
				result = result.WhereLike("cq_monstertype.drop_money_min","%" + this.drop_money_min.ToString() + "%");
			}
			if(this.drop_money_max != null)
			{
				result = result.WhereLike("cq_monstertype.drop_money_max","%" + this.drop_money_max.ToString() + "%");
			}
			if(this.size_add2 != null)
			{
				result = result.WhereLike("cq_monstertype.size_add2","%" + this.size_add2.ToString() + "%");
			}
			if(this.action != null)
			{
				result = result.WhereLike("cq_monstertype.action","%" + this.action.ToString() + "%");
			}
			if(this.run_speed != null)
			{
				result = result.WhereLike("cq_monstertype.run_speed","%" + this.run_speed.ToString() + "%");
			}
			if(this.hot_power != null)
			{
				result = result.WhereLike("cq_monstertype.hot_power","%" + this.hot_power.ToString() + "%");
			}
			if(this.cold_power != null)
			{
				result = result.WhereLike("cq_monstertype.cold_power","%" + this.cold_power.ToString() + "%");
			}
			if(this.shake_power != null)
			{
				result = result.WhereLike("cq_monstertype.shake_power","%" + this.shake_power.ToString() + "%");
			}
			if(this.drop_ring != null)
			{
				result = result.WhereLike("cq_monstertype.drop_ring","%" + this.drop_ring.ToString() + "%");
			}
			if(this.drop_weapon != null)
			{
				result = result.WhereLike("cq_monstertype.drop_weapon","%" + this.drop_weapon.ToString() + "%");
			}
			if(this.drop_shield != null)
			{
				result = result.WhereLike("cq_monstertype.drop_shield","%" + this.drop_shield.ToString() + "%");
			}
			if(this.drop_shoes != null)
			{
				result = result.WhereLike("cq_monstertype.drop_shoes","%" + this.drop_shoes.ToString() + "%");
			}
			if(this.drop_money_change != null)
			{
				result = result.WhereLike("cq_monstertype.drop_money_change","%" + this.drop_money_change.ToString() + "%");
			}
			if(this.drop_item_change != null)
			{
				result = result.WhereLike("cq_monstertype.drop_item_change","%" + this.drop_item_change.ToString() + "%");
			}
			if(this.magic_type != null)
			{
				result = result.WhereLike("cq_monstertype.magic_type","%" + this.magic_type.ToString() + "%");
			}
			if(this.magic_def != null)
			{
				result = result.WhereLike("cq_monstertype.magic_def","%" + this.magic_def.ToString() + "%");
			}
			if(this.magic_hitrate != null)
			{
				result = result.WhereLike("cq_monstertype.magic_hitrate","%" + this.magic_hitrate.ToString() + "%");
			}
			if(this.ai_type != null)
			{
				result = result.WhereLike("cq_monstertype.ai_type","%" + this.ai_type.ToString() + "%");
			}
			if(this.explode_change1 != null)
			{
				result = result.WhereLike("cq_monstertype.explode_change1","%" + this.explode_change1.ToString() + "%");
			}
			if(this.explode_change2 != null)
			{
				result = result.WhereLike("cq_monstertype.explode_change2","%" + this.explode_change2.ToString() + "%");
			}
			if(this.explode_change3 != null)
			{
				result = result.WhereLike("cq_monstertype.explode_change3","%" + this.explode_change3.ToString() + "%");
			}
			if(this.drop_item_rule != null)
			{
				result = result.WhereLike("cq_monstertype.drop_item_rule","%" + this.drop_item_rule.ToString() + "%");
			}
			if(this.atk_max != null)
			{
				result = result.WhereLike("cq_monstertype.atk_max","%" + this.atk_max.ToString() + "%");
			}
			if(this.atk_min != null)
			{
				result = result.WhereLike("cq_monstertype.atk_min","%" + this.atk_min.ToString() + "%");
			}
			if(this.atk_hot != null)
			{
				result = result.WhereLike("cq_monstertype.atk_hot","%" + this.atk_hot.ToString() + "%");
			}
			if(this.atk_shake != null)
			{
				result = result.WhereLike("cq_monstertype.atk_shake","%" + this.atk_shake.ToString() + "%");
			}
			if(this.atk_ice != null)
			{
				result = result.WhereLike("cq_monstertype.atk_ice","%" + this.atk_ice.ToString() + "%");
			}
			if(this.atk_decay != null)
			{
				result = result.WhereLike("cq_monstertype.atk_decay","%" + this.atk_decay.ToString() + "%");
			}
			if(this.def_adj != null)
			{
				result = result.WhereLike("cq_monstertype.def_adj","%" + this.def_adj.ToString() + "%");
			}
			if(this.def_sub != null)
			{
				result = result.WhereLike("cq_monstertype.def_sub","%" + this.def_sub.ToString() + "%");
			}
			if(this.def_hot != null)
			{
				result = result.WhereLike("cq_monstertype.def_hot","%" + this.def_hot.ToString() + "%");
			}
			if(this.def_shake != null)
			{
				result = result.WhereLike("cq_monstertype.def_shake","%" + this.def_shake.ToString() + "%");
			}
			if(this.def_sting != null)
			{
				result = result.WhereLike("cq_monstertype.def_sting","%" + this.def_sting.ToString() + "%");
			}
			if(this.def_decay != null)
			{
				result = result.WhereLike("cq_monstertype.def_decay","%" + this.def_decay.ToString() + "%");
			}
			if(this.weapon_amount != null)
			{
				result = result.WhereLike("cq_monstertype.weapon_amount","%" + this.weapon_amount.ToString() + "%");
			}
			if(this.armor_amount != null)
			{
				result = result.WhereLike("cq_monstertype.armor_amount","%" + this.armor_amount.ToString() + "%");
			}
			if(this.thruster_amount != null)
			{
				result = result.WhereLike("cq_monstertype.thruster_amount","%" + this.thruster_amount.ToString() + "%");
			}
			if(this.d_stealitem != null)
			{
				result = result.WhereLike("cq_monstertype.d_stealitem","%" + this.d_stealitem.ToString() + "%");
			}
			if(this.award_exp != null)
			{
				result = result.WhereLike("cq_monstertype.award_exp","%" + this.award_exp.ToString() + "%");
			}
			if(this.drop_stone_change != null)
			{
				result = result.WhereLike("cq_monstertype.drop_stone_change","%" + this.drop_stone_change.ToString() + "%");
			}
			if(this.drop_stone_min != null)
			{
				result = result.WhereLike("cq_monstertype.drop_stone_min","%" + this.drop_stone_min.ToString() + "%");
			}
			if(this.drop_stone_max != null)
			{
				result = result.WhereLike("cq_monstertype.drop_stone_max","%" + this.drop_stone_max.ToString() + "%");
			}
			if(this.magic_type1 != null)
			{
				result = result.WhereLike("cq_monstertype.magic_type1","%" + this.magic_type1.ToString() + "%");
			}
			if(this.magic_type2 != null)
			{
				result = result.WhereLike("cq_monstertype.magic_type2","%" + this.magic_type2.ToString() + "%");
			}
			if(this.magic_type3 != null)
			{
				result = result.WhereLike("cq_monstertype.magic_type3","%" + this.magic_type3.ToString() + "%");
			}
			if(this.magic_assistan != null)
			{
				result = result.WhereLike("cq_monstertype.magic_assistan","%" + this.magic_assistan.ToString() + "%");
			}
			if(this.magic_assistan2 != null)
			{
				result = result.WhereLike("cq_monstertype.magic_assistan2","%" + this.magic_assistan2.ToString() + "%");
			}
			if(this.magic_passive != null)
			{
				result = result.WhereLike("cq_monstertype.magic_passive","%" + this.magic_passive.ToString() + "%");
			}
			if(this.magic_passive2 != null)
			{
				result = result.WhereLike("cq_monstertype.magic_passive2","%" + this.magic_passive2.ToString() + "%");
			}
			if(this.status_def != null)
			{
				result = result.WhereLike("cq_monstertype.status_def","%" + this.status_def.ToString() + "%");
			}
			if(this.status_lv != null)
			{
				result = result.WhereLike("cq_monstertype.status_lv","%" + this.status_lv.ToString() + "%");
			}
			if(this.somatotype != null)
			{
				result = result.WhereLike("cq_monstertype.somatotype","%" + this.somatotype.ToString() + "%");
			}
			if(this.camp != null)
			{
				result = result.WhereLike("cq_monstertype.camp","%" + this.camp.ToString() + "%");
			}
			if(this.drop_equip_coe != null)
			{
				result = result.WhereLike("cq_monstertype.drop_equip_coe","%" + this.drop_equip_coe.ToString() + "%");
			}
			if(this.drop_ammo_coe != null)
			{
				result = result.WhereLike("cq_monstertype.drop_ammo_coe","%" + this.drop_ammo_coe.ToString() + "%");
			}
			if(this.drop_part_coe != null)
			{
				result = result.WhereLike("cq_monstertype.drop_part_coe","%" + this.drop_part_coe.ToString() + "%");
			}
			if(this.drop_amplifier_coe != null)
			{
				result = result.WhereLike("cq_monstertype.drop_amplifier_coe","%" + this.drop_amplifier_coe.ToString() + "%");
			}
			if(this.drop_HumanItem_coe != null)
			{
				result = result.WhereLike("cq_monstertype.drop_HumanItem_coe","%" + this.drop_HumanItem_coe.ToString() + "%");
			}
			if(this.drop_expendable_coe != null)
			{
				result = result.WhereLike("cq_monstertype.drop_expendable_coe","%" + this.drop_expendable_coe.ToString() + "%");
			}
			if(this.drop_InsideItem_coe != null)
			{
				result = result.WhereLike("cq_monstertype.drop_InsideItem_coe","%" + this.drop_InsideItem_coe.ToString() + "%");
			}
			if(this.drop_explode_coe != null)
			{
				result = result.WhereLike("cq_monstertype.drop_explode_coe","%" + this.drop_explode_coe.ToString() + "%");
			}
			if(this.drop_Special_coe != null)
			{
				result = result.WhereLike("cq_monstertype.drop_Special_coe","%" + this.drop_Special_coe.ToString() + "%");
			}
			if(this.special_type != null)
			{
				result = result.WhereLike("cq_monstertype.special_type","%" + this.special_type.ToString() + "%");
			}
			if(this.drop_deltalev_coe != null)
			{
				result = result.WhereLike("cq_monstertype.drop_deltalev_coe","%" + this.drop_deltalev_coe.ToString() + "%");
			}
			if(this.attribute_type != null)
			{
				result = result.WhereLike("cq_monstertype.attribute_type","%" + this.attribute_type.ToString() + "%");
			}
			if(this.extra_battlelev != null)
			{
				result = result.WhereLike("cq_monstertype.extra_battlelev","%" + this.extra_battlelev.ToString() + "%");
			}
			if(this.extra_exp != null)
			{
				result = result.WhereLike("cq_monstertype.extra_exp","%" + this.extra_exp.ToString() + "%");
			}
			if(this.extra_damage != null)
			{
				result = result.WhereLike("cq_monstertype.extra_damage","%" + this.extra_damage.ToString() + "%");
			}
			if(this.drop_stone_type != null)
			{
				result = result.WhereLike("cq_monstertype.drop_stone_type","%" + this.drop_stone_type.ToString() + "%");
			}
			if(this.User_atk_adjust != null)
			{
				result = result.WhereLike("cq_monstertype.User_atk_adjust","%" + this.User_atk_adjust.ToString() + "%");
			}
			if(this.exempt_damage != null)
			{
				result = result.WhereLike("cq_monstertype.exempt_damage","%" + this.exempt_damage.ToString() + "%");
			}
			if(this.pertinence_magic != null)
			{
				result = result.WhereLike("cq_monstertype.pertinence_magic","%" + this.pertinence_magic.ToString() + "%");
			}
			if(this.pertinence_magic_damage != null)
			{
				result = result.WhereLike("cq_monstertype.pertinence_magic_damage","%" + this.pertinence_magic_damage.ToString() + "%");
			}
			if(this.pertinence_weapon != null)
			{
				result = result.WhereLike("cq_monstertype.pertinence_weapon","%" + this.pertinence_weapon.ToString() + "%");
			}
			if(this.pertinence_weapon_damage != null)
			{
				result = result.WhereLike("cq_monstertype.pertinence_weapon_damage","%" + this.pertinence_weapon_damage.ToString() + "%");
			}
			if(this.drop_emoney_coe != null)
			{
				result = result.WhereLike("cq_monstertype.drop_emoney_coe","%" + this.drop_emoney_coe.ToString() + "%");
			}
			if(this.drop_other_coe != null)
			{
				result = result.WhereLike("cq_monstertype.drop_other_coe","%" + this.drop_other_coe.ToString() + "%");
			}
			if(this.price != null)
			{
				result = result.WhereLike("cq_monstertype.price","%" + this.price.ToString() + "%");
			}
			if(this.user_atk_mode != null)
			{
				result = result.WhereLike("cq_monstertype.user_atk_mode","%" + this.user_atk_mode.ToString() + "%");
			}
			if(this.pertinence_transfrom != null)
			{
				result = result.WhereLike("cq_monstertype.pertinence_transfrom","%" + this.pertinence_transfrom.ToString() + "%");
			}
			if(this.pertinence_transfrom_damage != null)
			{
				result = result.WhereLike("cq_monstertype.pertinence_transfrom_damage","%" + this.pertinence_transfrom_damage.ToString() + "%");
			}
			if(this.weakness_tips != null)
			{
				result = result.WhereLike("cq_monstertype.weakness_tips","%" + this.weakness_tips.ToString() + "%");
			}

            this.paging.data = result.Result<T>();
            return this.paging;
        }
		protected override void ValidateCore(ObjectContext context)
        {
            this.current_page = this.current_page ?? 1;
            this.page_size = this.page_size ?? context.GetPageSize();
        }
        protected override void OnExecutingCore(ObjectContext context)
        {
            if (this.paging == null)
                this.paging = new Paging<T>();
            this.paging.current_page = this.current_page;
            this.paging.page_size = this.page_size;
            this.paging.is_success = true;
            this.paging.msg = "success";
            this.paging.error_code = 0;
        }
        protected override Result<Paging<T>> ExecuteCore(ObjectContext context)
        {
            return Success(this.GetData(context));
        }
    }
}