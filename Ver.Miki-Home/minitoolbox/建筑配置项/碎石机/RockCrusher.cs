using System;
using System.Collections.Generic;
using HarmonyLib;
using PeterHan.PLib.Options;
using STRINGS;
using UnityEngine;

namespace minitoolbox.建筑配置项.碎石机
{
	// Token: 0x02000033 RID: 51
	[HarmonyPatch(typeof(RockCrusherConfig), "ConfigureBuildingTemplate")]
	public class RockCrusher
	{
		// Token: 0x0600019D RID: 413 RVA: 0x000045E0 File Offset: 0x000027E0
		private static void Postfix(RockCrusherConfig __instance, ref GameObject go)
		{
			//碎石机追加自定义配方
			if (SingletonOptions<ConfigurationItem>.Instance.RockCrusher_Recipe && ElementLoader.FindElementByHash(SimHashes.MaficRock) != null)
			{
				float num = 0.9f;
				ComplexRecipe.RecipeElement[] array = new ComplexRecipe.RecipeElement[]
				{
					new ComplexRecipe.RecipeElement(SimHashes.MaficRock.CreateTag(), 100f)
				};
				ComplexRecipe.RecipeElement[] array2 = new ComplexRecipe.RecipeElement[]
				{
					new ComplexRecipe.RecipeElement(SimHashes.Iron.CreateTag(), 100f * num, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false),
					new ComplexRecipe.RecipeElement(SimHashes.IgneousRock.CreateTag(), 100f * (1f - num), ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false)
				};
				ComplexRecipe complexRecipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("RockCrusher", array, array2), array, array2);
				complexRecipe.time = 20f;
				complexRecipe.description = string.Format(BUILDINGS.PREFABS.ROCKCRUSHER.RECIPE_DESCRIPTION, SimHashes.MaficRock.CreateTag().ProperName(), SimHashes.Iron.CreateTag().ProperName());
				complexRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.IngredientToResult;
				complexRecipe.fabricators = new List<Tag>
				{
					TagManager.Create("RockCrusher")
				};
			}
			go.AddOrGet<ComplexFabricator>().duplicantOperated = !SingletonOptions<ConfigurationItem>.Instance.RockCrusher_Automatic;
		}
	}
}
