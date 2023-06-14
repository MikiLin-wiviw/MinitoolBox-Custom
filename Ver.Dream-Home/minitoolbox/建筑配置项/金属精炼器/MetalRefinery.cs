using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using STRINGS;

namespace minitoolbox.建筑配置项.金属精炼器
{
    [HarmonyPatch(typeof(MetalRefineryConfig), "ConfigureBuildingTemplate")]
    public class MetalRefinery
    {
        public static void Postfix(MetalRefineryConfig __instance,ref GameObject go)
        {
            //金属精炼器自定义配方
            if (SingletonOptions<ConfigurationItem>.Instance.MetalRefinery_CustomRecipe)
            {
                Element element = ElementLoader.FindElementByHash(SimHashes.Katairite);
                ComplexRecipe.RecipeElement[] array = new ComplexRecipe.RecipeElement[]
                {
                    new ComplexRecipe.RecipeElement(ElementLoader.FindElementByHash(SimHashes.Katairite).tag, 1000f)
                };
                ComplexRecipe.RecipeElement[] array2 = new ComplexRecipe.RecipeElement[]
                {
                    new ComplexRecipe.RecipeElement(ElementLoader.FindElementByHash(SimHashes.SuperInsulator).tag, 600f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false)
                };
                string obsolete_id = ComplexRecipeManager.MakeObsoleteRecipeID("MetalRefinery", element.tag);
                string text = ComplexRecipeManager.MakeRecipeID("MetalRefinery", array, array2);
                ComplexRecipe complexRecipe = new ComplexRecipe(text, array, array2);
                complexRecipe.time = 40f;
                complexRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.IngredientToResult;
                complexRecipe.description = string.Format(BUILDINGS.PREFABS.METALREFINERY.RECIPE_DESCRIPTION, ElementLoader.FindElementByHash(SimHashes.SuperInsulator).name, ElementLoader.FindElementByHash(SimHashes.Katairite).name);
                complexRecipe.fabricators = new List<Tag>
                {
                    TagManager.Create("MetalRefinery")
                };
                ComplexRecipeManager.Get().AddObsoleteIDMapping(obsolete_id, text);
            }

            //金属精炼器的容量
            float refineryWaterCapacity = 金属精炼器.容量;

            //金属精炼器是否会加热冷却剂，默认是true
            bool fudge = 金属精炼器.加热;
            LiquidCooledRefinery liquidCooledRefinery = go.AddOrGet<LiquidCooledRefinery>();
            //游戏里是加热液体0.8f
            liquidCooledRefinery.thermalFudge = (fudge ? 0.8f : 0f);
            ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
            conduitConsumer.capacityKG = refineryWaterCapacity;
        }
        private static void Postfix(GameObject go, Tag prefab_tag)
        {
            //是否需要复制人去操作
            go.AddOrGet<ComplexFabricator>().duplicantOperated = 金属精炼器.操作;
        }

    }
}
