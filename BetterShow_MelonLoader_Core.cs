using BetterShow_MelonLoader;
using Il2Cpp;
using MelonLoader;
using HarmonyLib;

[assembly: MelonInfo(typeof(BetterShow_MelonLoader.BetterShow), Info.NAME, Info.VER, Info.AUTHOR, null)]
[assembly: MelonGame("LanPiaoPiao", "PlantsVsZombiesRH")]

namespace BetterShow_MelonLoader
{
    public class Info
    {
        public const String GUID = "salmon.pvzrh.bettershow";   //GUID
        public const String NAME = "BetterShow";   //NAME
        public const String VER = "1.0.0";   //VER
        public const String AUTHOR = "Salmon";   //AUTHOR
    }

    public class BetterShow : MelonMod
    {
        public static Board board = new Board();

        public override void OnInitializeMelon()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            LoggerInstance.Msg(Info.Name + " 加载成功！");
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            try
            {
                board = GameAPP.board.GetComponent<Board>();
            }
            catch (Exception) { }
        }
    }

    [HarmonyPatch(typeof(Plant), "Update")]
    public class Plant_UpdatePatch
    {
        [HarmonyPostfix]
        public static void Postfix(Plant __instance)
        {
            __instance.UpdateHealthText();
        }
    }

    [HarmonyPatch(typeof(Plant), "UpdateHealthText")]
    public class Plant_HealthTextPatch
    {
        [HarmonyPostfix]
        public static void Postfix(Plant __instance)
        {
            switch (__instance.thePlantType)
            {
                case PlantType.SunMine:
                    __instance.healthText.text += '\n' + "生产冷却:" + (((int)__instance.thePlantProduceCountDown).ToString() + "s" + "\n出土:" + (((int)__instance.attributeCountdown).ToString() + 's'));
                    __instance.healthTextShadow.text += '\n' + "生产冷却:" + (((int)__instance.thePlantProduceCountDown).ToString() + "s" + "\n出土:" + (((int)__instance.attributeCountdown).ToString() + 's'));
                    break;
                case PlantType.SunFlower:
                case PlantType.PeaSunFlower:
                case PlantType.TwinFlower:
                case PlantType.SunNut:
                case PlantType.SunShroom:
                case PlantType.SeaSunShroom:
                    __instance.healthText.text += '\n' + "生产冷却:" + (((int)__instance.thePlantProduceCountDown).ToString() + 's');
                    __instance.healthTextShadow.text += '\n' + "生产冷却:" + (((int)__instance.thePlantProduceCountDown).ToString() + 's');
                    break;
                case PlantType.SunMagnet:
                    __instance.healthText.text += '\n' + "生产冷却:" + (((int)__instance.attributeCountdown).ToString() + 's');
                    __instance.healthTextShadow.text += '\n' + "生产冷却:" + (((int)__instance.attributeCountdown).ToString() + 's');
                    break;
                case PlantType.PotatoMine:
                    __instance.healthText.text += '\n' + "出土:" + (((int)__instance.attributeCountdown).ToString() + 's');
                    __instance.healthTextShadow.text += '\n' + "出土:" + (((int)__instance.attributeCountdown).ToString() + 's');
                    break;
                case PlantType.PeaMine:
                    __instance.healthText.text += '\n' + "出土:" + (((int)(__instance.attributeCountdown / 2)).ToString() + 's');
                    __instance.healthTextShadow.text += '\n' + "出土:" + (((int)(__instance.attributeCountdown / 2)).ToString() + 's');
                    break;
                case PlantType.Chomper:
                case PlantType.PeaChomper:
                case PlantType.SunChomper:
                case PlantType.CherryChomper:
                case PlantType.NutChomper:
                case PlantType.PotatoChomper:
                    __instance.healthText.text += '\n' + "咀嚼冷却:" + (((int)__instance.attributeCountdown).ToString() + 's');
                    __instance.healthTextShadow.text += '\n' + "咀嚼冷却:" + (((int)__instance.attributeCountdown).ToString() + 's');
                    break;
                case PlantType.Marigold:
                case PlantType.TwinMarigold:
                    __instance.healthText.text += '\n' + "生产冷却:" + (((int)__instance.thePlantProduceCountDown).ToString() + 's');
                    __instance.healthTextShadow.text += '\n' + "生产冷却:" + (((int)__instance.thePlantProduceCountDown).ToString() + 's');
                    break;
                case PlantType.CobCannon:
                case PlantType.FireCannon:
                case PlantType.IceCannon:
                case PlantType.MelonCannon:
                case PlantType.UltimateCannon:
                    __instance.healthText.text += '\n' + "生产冷却:" + (((int)__instance.attributeCountdown).ToString() + 's');
                    __instance.healthTextShadow.text += '\n' + "生产冷却:" + (((int)__instance.attributeCountdown).ToString() + 's');
                    break;
                case PlantType.SuperPumpkin:
                case PlantType.FinalPumpkin:
                case PlantType.BlowerPumpkin:
                    __instance.healthText.text += '\n' + "生产冷却:" + (((int)__instance.attributeCountdown).ToString() + 's');
                    __instance.healthTextShadow.text += '\n' + "生产冷却:" + (((int)__instance.attributeCountdown).ToString() + 's');
                    break;
                case PlantType.HypnoEmperor:
                    __instance.healthText.text += '\n' + "生成冷却:" + (((int)__instance.GetComponent<HyponoEmperor>().summonZombieTime).ToString() + "s " + "剩余魅惑次数:" + (__instance.GetComponent<HyponoEmperor>().restHealth));
                    __instance.healthTextShadow.text += '\n' + "生成冷却:" + (((int)__instance.GetComponent<HyponoEmperor>().summonZombieTime).ToString() + "s " + "剩余魅惑次数:" + (__instance.GetComponent<HyponoEmperor>().restHealth));
                    break;
                case PlantType.HypnoQueen:
                    __instance.healthText.text += '\n' + "生成冷却:" + (((int)__instance.GetComponent<HypnoQueen>().summonZombieTime).ToString() + "s " + "剩余魅惑次数:" + (__instance.GetComponent<HypnoQueen>().restHealth));
                    __instance.healthTextShadow.text += '\n' + "生成冷却:" + (((int)__instance.GetComponent<HypnoQueen>().summonZombieTime).ToString() + "s " + "剩余魅惑次数:" + (__instance.GetComponent<HypnoQueen>().restHealth));
                    break;
                case PlantType.LanternMagnet:
                case PlantType.CherryMagnet:
                case PlantType.Magnetshroom:
                    __instance.healthText.text += '\n' + "消化:" + (((int)__instance.attributeCountdown).ToString() + 's');
                    __instance.healthTextShadow.text += '\n' + "消化:" + (((int)__instance.attributeCountdown).ToString() + 's');
                    break;
                case PlantType.SuperStar:
                    __instance.healthText.text += '\n' + "普通陨石:" + (((int)BetterShow.board.bigStarPassiveCountDown).ToString() + 's');
                    __instance.healthTextShadow.text += '\n' + "普通陨石:" + (((int)BetterShow.board.bigStarPassiveCountDown).ToString() + 's');
                    break;
                case PlantType.UltimateStar:
                    __instance.healthText.text += '\n' + "究极陨石:" + ((int)BetterShow.board.ultimateStarCountDown).ToString() + 's';
                    __instance.healthTextShadow.text += '\n' + "究极陨石:" + ((int)BetterShow.board.ultimateStarCountDown).ToString() + 's';
                    break;
                case PlantType.GoldCabbage:
                case PlantType.GoldCorn:
                case PlantType.GoldGarlic:
                case PlantType.GoldUmbrella:
                case PlantType.GoldMelon:
                case PlantType.SuperUmbrella:
                case PlantType.EmeraldUmbrella:
                case PlantType.RedEmeraldUmbrella:
                    __instance.healthText.text += '\n' + "大招冷却:" + (((int)__instance.flashCountDown).ToString() + 's');
                    __instance.healthTextShadow.text += '\n' + "大招冷却:" + (((int)__instance.flashCountDown).ToString() + 's');
                    break;
            }
        }
    }
}
