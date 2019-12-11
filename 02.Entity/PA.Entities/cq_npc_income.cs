namespace Entities
{
    public class cq_npc_income
    {
		public int? id { get; set; }
		public int? npc_id { get; set; }
		public int? owner_id { get; set; }
		public int? owner_type { get; set; }
		public long? income_exp { get; set; }
		public long? income_money { get; set; }

    }
}
