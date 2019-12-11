using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqMonstertypeGetByIdRepository<T> : CommandBase<T> where T : class,new()
    {
        public int? id { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
           if(this.id == null)
            {
                throw new BusinessException("id is not nullable", System.Net.HttpStatusCode.BadRequest);
            }
        }
        private T GetData(ObjectContext context)
        {
            return context.db
                .From("cq_monstertype")
                .Where("cq_monstertype.id",this.id)
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
                .Result<T>()
                .FirstOrDefault()
                ;
        }
        protected override Result<T> ExecuteCore(ObjectContext context)
        {
            return Success(this.GetData(context));
        }
    }
}