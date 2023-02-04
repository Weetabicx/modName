using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace modName.Items
{
	public class NolingassiumSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("NolingassiumSword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("who up swinging they sword");
		}

		public override void SetDefaults()
		{
			Item.damage = 5000;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 1;
			Item.knockBack = 60;
			Item.value = 10000;
			Item.rare = 2;
			Item.UseSound = SoundID.NPCDeath64;
			Item.autoReuse = true;
			Item.crit = 100;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 1);
			//recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}