using MelonLoader;
using System;
using UnityEngine;

namespace SignalisMachete
{
    public class BringBackMachete : MelonMod
    {
        public override void OnUpdate()
        {
            // add in 3 useful variables !
            Renderer rend;
            GameObject MachetePlaceholder = GameObject.Find("__Prerequisites__/Character Origin/Character Root/Ellie_Default/metarig/Root/hips/spine/chest/shoulder_R/upper_arm_R/forearm_R/hand_R/WeaponMount/Weapons/Machete/PlaceholderBaton");
            GameObject MacheteObject = GameObject.Find("__Prerequisites__/Character Origin/Character Root/Ellie_Default/metarig/Root/hips/spine/chest/shoulder_R/upper_arm_R/forearm_R/hand_R/WeaponMount/Weapons/Machete");
            if (Input.GetKeyDown(KeyCode.I) && Input.GetKeyDown(KeyCode.X))
            {
                if (MacheteAllowedInv() == true && MacheteAllowedBox() == true)
                {
                    MacheteBroughtBack();
                    MacheteTexture();
                }
                else
                {
                    MacheteTexture();
                }
            }
            if (InventoryManager.EquippedWeapon.name == "MacheteWeapon" && MachetePlaceholder.gameObject.active == true)
            {
                MachetePlaceholder.gameObject.SetActive(false);
                rend = MacheteObject.gameObject.transform.GetComponent<MeshRenderer>();
                rend.enabled = true;
                MelonLogger.Msg("Assigned texture successfully!");
            }

        }
        public static bool MacheteAllowedInv()
        {
            int mc = 0;
            foreach (var i in InventoryManager.elsterItems)
            {
                if (i.Key._name == "Machete")
                {
                    return false;
                }
                else
                {
                    mc++;
                    if (mc == InventoryManager.elsterItems.Count)
                    {
                        return true;
                    }
                }
            }
            return true;
        }
        public static bool MacheteAllowedBox()
        {
            int mc = 0;
            foreach (var i in InventoryManager.boxItems)
            {
                if (i.Key._name == "Machete")
                {
                    return false;
                }
                else
                {
                    mc++;
                    if (mc == InventoryManager.boxItems.Count)
                    {
                        return true;
                    }
                }
            }
            return true;
        }
        public static void MacheteTexture()
        {
            Renderer rend;
            GameObject MachetePlaceholder = GameObject.Find("__Prerequisites__/Character Origin/Character Root/Ellie_Default/metarig/Root/hips/spine/chest/shoulder_R/upper_arm_R/forearm_R/hand_R/WeaponMount/Weapons/Machete/PlaceholderBaton");
            GameObject MacheteObject = GameObject.Find("__Prerequisites__/Character Origin/Character Root/Ellie_Default/metarig/Root/hips/spine/chest/shoulder_R/upper_arm_R/forearm_R/hand_R/WeaponMount/Weapons/Machete");
            // search inv for machete
            foreach (var i in InventoryManager.elsterItems)
            {
                if (i.Key._name == "Machete")
                {
                    // disabledplaceholder and turn on machete render
                    try
                    {
                        MachetePlaceholder.gameObject.SetActive(false);
                        rend = MacheteObject.gameObject.transform.GetComponent<MeshRenderer>();
                        rend.enabled = true;
                        MelonLogger.Msg("Assigned texture successfully!");
                    }
                    catch (Exception e)
                    {
                        MelonLogger.Msg($"Failed to assign texture.  Error: {e}");
                    }
                }
            }
        }
        public static void MacheteBroughtBack()
        {
            foreach (AnItem item in InventoryManager.allItems.Values)
            {
                if (item.name == "Machete")
                {
                    InventoryManager.AddItem(item, 1);
                }    
            }
        }
    }
}
