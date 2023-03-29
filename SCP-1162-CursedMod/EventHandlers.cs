namespace SCP_1162_CursedMod
{
    using UnityEngine;
    using System.Linq;
    using Random = UnityEngine.Random;
    using CustomPlayerEffects;
    using CursedMod.Events.Arguments.Items;
    using CursedMod.Features.Wrappers.Round;
    using CursedMod.Features.Wrappers.Player;
    using CursedMod.Features.Wrappers.Inventory.Items;
    using MapGeneration;
    using CursedMod.Features.Wrappers.AdminToys;

    public class EventHandlers
    {
        private Vector3 SCP1162Position;

        public void OnMapGenerated()
        {
            Spawn1162();
        }

        public void Spawn1162()
        {
            var Room = RoomIdentifier.AllRoomIdentifiers.First(x => x.name.Contains("LCZ_173"));
            var scp1162 = CursedPrimitiveObject.Create(PrimitiveType.Cylinder, Vector3.zero, new Vector3(1.3f, 0.1f, 1.3f), Vector3.zero, Color.black);
            scp1162.Transform.parent = Room.transform;
            scp1162.Transform.localPosition = new Vector3(17f, 13f, 3.59f);
            scp1162.Transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
            scp1162.Spawn();
            SCP1162Position = scp1162.Position;
        }

        public void OnPlayerDroppingItem(PlayerDroppingItemEventArgs ev)
        {
            if (!CursedRound.HasStarted) return;
            if (Vector3.Distance(SCP1162Position, ev.Player.Position) <= Plugin.Instance.Config.SCP1162Distance)
            {
                if (!ev.IsThrow)
                {
                    if (Plugin.Instance.Config.CuttingHands)
                    {
                        if (Plugin.Instance.Config.OnlyThrow)
                        {
                            ev.Player.EnableEffect<SeveredHands>(1000);
                            return;
                        }
                        else if (Plugin.Instance.Config.ChanceCutting >= Random.Range(0, 101))
                        {
                            ev.Player.EnableEffect<SeveredHands>(1000);
                            return;
                        }
                    }

                    OnUseSCP1162(ev.Player, ev.Item);
                }
                else
                {
                    OnUseSCP1162(ev.Player, ev.Item);
                }
            }
            return;
        }

        private void OnUseSCP1162(CursedPlayer player, CursedItem item)
        {
            var newItemType = Plugin.Instance.Config.DroppingItems.RandomItem();

            player.ShowHint(
            Plugin.Instance.Config.ItemDropMessage.Replace("{dropitem}", item.ItemType.ToString())
                    .Replace("{giveitem}", newItemType.ToString()), 3);

            player.RemoveItem(item);
            player.AddItem(newItemType);
        }
    }
}
