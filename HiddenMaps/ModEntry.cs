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
            "\t F1: Shred\n" +
            "\t F2: Majesty\n" +
            "\t F3: Nobody Wants You\n" +
            "\t F4: Work\n" +
            "\t F5: Good News\n" +
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
                gameManager.SetDestinationAndUpdateUIFromDestinationString("Shred");
            }
            if (Input.GetKeyDown(KeyCode.F2))
            {
                gameManager.SetDestinationAndUpdateUIFromDestinationString("Majesty");
            }
            if (Input.GetKeyDown(KeyCode.F3))
            {
                gameManager.SetDestinationAndUpdateUIFromDestinationString("NobodyWantsYou");
            }
            if (Input.GetKeyDown(KeyCode.F4))
            {
                gameManager.SetDestinationAndUpdateUIFromDestinationString("Work");
            }
            if (Input.GetKeyDown(KeyCode.F5))
            {
                gameManager.SetDestinationAndUpdateUIFromDestinationString("GoodNews");
            }
        }
    }
}
