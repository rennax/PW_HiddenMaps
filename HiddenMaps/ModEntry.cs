using Il2Cpp;
using MelonLoader;
using UnityEngine;

[assembly: MelonInfo(typeof(HiddenMaps.ModEntry), "HiddenMaps", "0.0.1", "Renaxi")]

namespace HiddenMaps
{




    class ModEntry : MelonMod
    {
        GameManager? gameManager;

        const string guide = "\n" +
            "To play levels from the Breachers collection. Use the following keys:\n" +
            "\t F1: DestinyIsCalling\n" +
            "\t F2: EverBurningFlame\n" +
            "\t F3: Soulbound (WIP)\n" +
            "\t F4: TheOtherSonOfOdin\n" +
            "\n";

        bool InitGameManager()
        {
            MelonLogger.Msg("Getting GameManager.");
            GameObject managerGO = GameObject.Find("Managers");
            if (managerGO == null)
            {
                MelonLogger.Warning("GameManager is not yet initialized. Trying again later.");
                return false;
            }

            gameManager = managerGO.GetComponent<GameManager>();
            return true;
        }

        public override void OnLateInitializeMelon()
        {
            MelonLogger.Msg(guide);
        }

        public override void OnUpdate()
        {
            if (gameManager == null)
            {
                if (InitGameManager() == false || gameManager == null) return;
            }

            if (Input.GetKeyDown(KeyCode.F1))
            {
                gameManager.SetDestinationAndUpdateUIFromDestinationString("DestinyIsCalling");
            }
            if (Input.GetKeyDown(KeyCode.F2))
            {
                gameManager.SetDestinationAndUpdateUIFromDestinationString("EverBurningFlame");
            }
            if (Input.GetKeyDown(KeyCode.F3))
            {
                gameManager.SetDestinationAndUpdateUIFromDestinationString("Soulbound");
            }
            if (Input.GetKeyDown(KeyCode.F4))
            {
                gameManager.SetDestinationAndUpdateUIFromDestinationString("TheOtherSonOfOdin");
            }
        }
    }
}
