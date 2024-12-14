using System.Collections;
using System.Linq;
using UnityEngine;
using XInputDotNetPure;

namespace HinputClasses.Internal
{
	public class Vibration
	{
		private struct PresetCurves
		{
			public readonly AnimationCurve leftCurve;

			public readonly AnimationCurve rightCurve;

			public PresetCurves(AnimationCurve left, AnimationCurve right)
			{
				leftCurve = left;
				rightCurve = right;
			}
		}

		private readonly PlayerIndex index;

		private readonly bool canVibrate;

		private float prevLeft;

		private float prevRight;

		public float currentLeft;

		public float currentRight;

		public Vibration(int index)
		{
			if (Utils.os == Utils.OS.Windows && index <= 3)
			{
				this.index = (PlayerIndex)index;
				canVibrate = true;
			}
		}

		public void Update()
		{
			if (currentLeft.IsEqualTo(prevLeft) && currentRight.IsEqualTo(prevRight))
			{
				return;
			}
			prevLeft = currentLeft;
			prevRight = currentRight;
			try
			{
				GamePad.SetVibration(index, currentLeft, currentRight);
			}
			catch
			{
			}
		}

		public void Vibrate(float left, float right, float duration)
		{
			if (canVibrate)
			{
				Utils.Coroutine(_Vibrate(left, right, duration));
			}
			else
			{
				Utils.VibrationNotAvailableError();
			}
		}

		public void Vibrate(AnimationCurve leftCurve, AnimationCurve rightCurve)
		{
			if (canVibrate)
			{
				Utils.Coroutine(_Vibrate(leftCurve, rightCurve));
			}
			else
			{
				Utils.VibrationNotAvailableError();
			}
		}

		public void Vibrate(VibrationPreset vibrationPreset, float left, float right, float duration)
		{
			if (canVibrate)
			{
				PresetCurves curves = GetCurves(vibrationPreset, left, right, duration);
				Utils.Coroutine(_Vibrate(curves.leftCurve, curves.rightCurve));
			}
			else
			{
				Utils.VibrationNotAvailableError();
			}
		}

		public void VibrateAdvanced(float left, float right)
		{
			if (canVibrate)
			{
				currentLeft += left;
				currentRight += right;
			}
			else
			{
				Utils.VibrationNotAvailableError();
			}
		}

		public void StopVibration(float duration)
		{
			if (canVibrate)
			{
				Utils.StopRoutines();
				Utils.Coroutine(_StopVibration(duration));
			}
		}

		private IEnumerator _Vibrate(float left, float right, float duration)
		{
			currentRight += right;
			currentLeft += left;
			yield return new WaitForSecondsRealtime(duration);
			currentRight -= right;
			currentLeft -= left;
		}

		private IEnumerator _Vibrate(AnimationCurve leftCurve, AnimationCurve rightCurve)
		{
			float time = 0f;
			bool leftCurveIsOver = leftCurve.keys.Length == 0;
			bool rightCurveIsOver = rightCurve.keys.Length == 0;
			float leftCurveDuration = Enumerable.Last(leftCurve.keys).time;
			float rightCurveDuration = Enumerable.Last(rightCurve.keys).time;
			while (!leftCurveIsOver || !rightCurveIsOver)
			{
				float leftCurveValue = ((!leftCurveIsOver) ? leftCurve.Evaluate(time) : 0f);
				float rightCurveValue = ((!rightCurveIsOver) ? rightCurve.Evaluate(time) : 0f);
				time += Time.unscaledDeltaTime;
				leftCurveIsOver = time > leftCurveDuration;
				rightCurveIsOver = time > rightCurveDuration;
				currentLeft += leftCurveValue;
				currentRight += rightCurveValue;
				yield return new WaitForEndOfFrame();
				currentLeft -= leftCurveValue;
				currentRight -= rightCurveValue;
			}
		}

		private IEnumerator _StopVibration(float duration)
		{
			float originLeft = currentLeft;
			float originRight = currentRight;
			currentLeft = 0f;
			currentRight = 0f;
			float timeLeft = duration;
			while (timeLeft > 0f)
			{
				timeLeft -= Time.unscaledDeltaTime;
				currentLeft += originLeft * timeLeft / duration;
				currentRight += originRight * timeLeft / duration;
				yield return new WaitForEndOfFrame();
				currentLeft -= originLeft * timeLeft / duration;
				currentRight -= originRight * timeLeft / duration;
			}
			Update();
		}

		private PresetCurves GetCurves(VibrationPreset vibrationPreset, float left, float right, float duration)
		{
			AnimationCurve animationCurve = new AnimationCurve();
			AnimationCurve animationCurve2 = new AnimationCurve();
			if (vibrationPreset == VibrationPreset.ButtonPress)
			{
				animationCurve.AddKey(0f, 0.5f);
				animationCurve.AddKey(0.1f, 0.5f);
				animationCurve2.AddKey(0f, 0.5f);
				animationCurve2.AddKey(0.1f, 0.5f);
			}
			if (vibrationPreset == VibrationPreset.ImpactLight)
			{
				animationCurve.AddKey(0f, 0f);
				animationCurve.AddKey(0.2f, 0f);
				animationCurve2.AddKey(0f, 0.5f);
				animationCurve2.AddKey(0.2f, 0.5f);
			}
			if (vibrationPreset == VibrationPreset.Impact)
			{
				animationCurve.AddKey(0f, 0.2f);
				animationCurve.AddKey(0.2f, 0.2f);
				animationCurve2.AddKey(0f, 0.8f);
				animationCurve2.AddKey(0.2f, 0.8f);
			}
			if (vibrationPreset == VibrationPreset.ImpactHeavy)
			{
				animationCurve.AddKey(0f, 0.5f);
				animationCurve.AddKey(0.2f, 0.5f);
				animationCurve2.AddKey(0f, 1f);
				animationCurve2.AddKey(0.2f, 1f);
			}
			if (vibrationPreset == VibrationPreset.ExplosionShort)
			{
				animationCurve.AddKey(0f, 0.6f);
				animationCurve.AddKey(0.2f, 0.6f);
				animationCurve2.AddKey(0f, 0.3f);
				animationCurve2.AddKey(0.2f, 0.3f);
			}
			if (vibrationPreset == VibrationPreset.Explosion)
			{
				animationCurve.AddKey(0f, 0.8f);
				animationCurve.AddKey(0.5f, 0.8f);
				animationCurve2.AddKey(0f, 0.4f);
				animationCurve2.AddKey(0.5f, 0.4f);
			}
			if (vibrationPreset == VibrationPreset.ExplosionLong)
			{
				animationCurve.AddKey(0f, 1f);
				animationCurve.AddKey(1f, 1f);
				animationCurve.AddKey(1.1f, 0f);
				animationCurve2.AddKey(0f, 0.5f);
				animationCurve2.AddKey(1f, 0.5f);
				animationCurve2.AddKey(1.1f, 0f);
			}
			if (vibrationPreset == VibrationPreset.AmbientSubtle)
			{
				animationCurve.AddKey(0f, 0.1f);
				animationCurve.AddKey(10f, 0.1f);
				animationCurve2.AddKey(0f, 0f);
				animationCurve2.AddKey(10f, 0f);
			}
			if (vibrationPreset == VibrationPreset.Ambient)
			{
				animationCurve.AddKey(0f, 0.3f);
				animationCurve.AddKey(10f, 0.3f);
				animationCurve2.AddKey(0f, 0.1f);
				animationCurve2.AddKey(10f, 0.1f);
			}
			if (vibrationPreset == VibrationPreset.AmbientStrong)
			{
				animationCurve.AddKey(0f, 0.6f);
				animationCurve.AddKey(10f, 0.6f);
				animationCurve2.AddKey(0f, 0.3f);
				animationCurve2.AddKey(10f, 0.3f);
			}
			animationCurve.keys = Enumerable.ToArray(Enumerable.Select(Enumerable.ToList(animationCurve.keys), (Keyframe key) => new Keyframe(key.time * duration, key.value * left)));
			animationCurve2.keys = Enumerable.ToArray(Enumerable.Select(Enumerable.ToList(animationCurve2.keys), (Keyframe key) => new Keyframe(key.time * duration, key.value * right)));
			return new PresetCurves(animationCurve, animationCurve2);
		}
	}
}
