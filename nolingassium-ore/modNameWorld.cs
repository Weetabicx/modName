using ExampleMod.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;
using Terraria.NPCID;

namespace modName
{
    public class modNameWorld : ModWorld
    {
        public override void PostUpdate() {
            if (npc.type == NPCID.GreenSlime)
            {
                if (!Mworld.spawnOre)
                {
                    // setting these two to true may allow some functions to work differently, might help?
                    WorldGen.noTileActions = true;
                    WorldGen.gen = true;
                    
                    Main.NewText("A feeling of hope washes over your mind, a green light shines in the darkness below", 0, 200, 0);
                    
                    // WorldGen.rockLayer may not exist after the world is created.
                    // (int)((double)(WorldGen.rockLayer * Main.maxTilesY) * 40E-05) evaluates to ~3528 for a large world
                    // (int)((Main.maxTilesX * Main.maxTilesY) * 1.75E-4) will yield a silimar result, can will work at any stage of the game
                    for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * 1.75E-4); k++)
                    {
                        // techically these should be lowercase, but they dont have to be
                        int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                        int y = WorldGen.genRand.Next((int)WorldGen.rockLayer, Main.maxTilesY - 200);
                        // consider using WorldGen.OreRunner instead of this. Also, use ModContent.TileType<NeoniteOre>(), as mod.TileType is deprecated
                        WorldGen.OreRunner(x, y, WorldGen.genRand.Next(9, 15), WorldGen.genRand.Next(5, 9), (short)ModContent.TileType<NolingassiumOre>());
                        
                        // you can use something like this to see if this code is getting run enough
                        Main.NewText($"Tried to create ore at {x} {y}. (iteration {k} of {(int)((double)(WorldGen.rockLayer * Main.maxTilesY) * 40E-05)})");
                    }
                    
                    // gotta be sure to set this back to false
                    WorldGen.noTileActions = false;
                    WorldGen.gen = false;
                    
                    Mworld.spawnOre = true;
                }
            }


        }
    }
}