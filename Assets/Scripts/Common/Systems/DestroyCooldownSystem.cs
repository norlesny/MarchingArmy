using Common.Components;
using Unity.Entities;
using UnityEngine;

namespace Common.Systems
{
	public sealed class DestroyCooldownSystem : ComponentSystem
	{
		[Inject] private Data data;

		protected override void OnUpdate()
		{
			float deltaTime = Time.deltaTime;

			for (var i = 0; i < data.Length; ++i)
			{
				float cooldown = data.Cooldown[i].Value;
				cooldown -= deltaTime;
				if (cooldown <= 0f)
				{
					PostUpdateCommands.DestroyEntity(data.Entity[i]);
				}
				else
				{
					data.Cooldown[i] = new DestroyCooldown {Value = cooldown};
				}
			}
		}

		private struct Data
		{
			public readonly int Length;
			public EntityArray Entity;
			public ComponentDataArray<DestroyCooldown> Cooldown;
		}
	}
}