using UnityEngine;
using System.Collections;
using UnityEditor;

namespace Adnc.SkillTree
{
	[CustomEditor(typeof(SkillTreeBase), true)]
	public class SkillTreeEditor : Editor
	{
		EditorWindow window;

		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();

			if (GUILayout.Button("Edit Skill Tree"))
			{
				window = EditorWindow.GetWindow<GraphController>();
				window.Show();
			}

			if (GUILayout.Button("Rebuild Uuid"))
			{
				if (EditorUtility.DisplayDialog("Warning",
				$"You are attempting to rebuild Uuid which is expensive.",
				"Proceed", "Quit"))
				{
					var obj = (SkillTreeBase)target;

					var skills = obj.GetSkills();
					for (int i = 0; i < skills.Length; i++)
					{
						skills[i].Uuid = System.Guid.NewGuid().ToString();
					}

					var catagories = obj.GetCategories();
					for (int i = 0; i < catagories.Length; i++)
					{
						catagories[i].Uuid = System.Guid.NewGuid().ToString();
					}

					var collections = obj.GetSkillCollections();
					for (int i = 0; i < collections.Length; i++)
					{
						collections[i].Uuid = System.Guid.NewGuid().ToString();
					}
				}
			}

			// If this isn't set your changes will not take effect
			if (GUI.changed) EditorUtility.SetDirty(target);
		}
	}
}
