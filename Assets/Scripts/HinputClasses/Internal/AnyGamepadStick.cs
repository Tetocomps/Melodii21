using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HinputClasses.Internal
{
	public class AnyGamepadStick : Stick
	{
		private readonly List<Stick> sticks;

		public AnyGamepadStick(string stickName, Gamepad gamepad, int index)
			: base(stickName, gamepad, index, isEnabled: true)
		{
			sticks = Enumerable.ToList(Enumerable.Select(Hinput.gamepad, (Gamepad g) => g.sticks[index]));
		}

		protected override Vector2 GetPosition()
		{
			List<Stick> list = Enumerable.ToList(Enumerable.Where(sticks, (Stick s) => s.distance.IsNotEqualTo(0f)));
			if (list.Count == 0)
			{
				return Vector2.zero;
			}
			return new Vector2(Enumerable.Average(list, (Stick stick) => stick.horizontal), Enumerable.Average(list, (Stick stick) => stick.vertical));
		}
	}
}
