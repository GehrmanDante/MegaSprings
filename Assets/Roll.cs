// using UnfinishedStudios.BeakMessaging;
// using UnityEngine;

// namespace UnfinishedStudios.FPMotion
// {
//     public class Roll : MotionBehaviour
//     {
//         private Event<float> moveX;
//         private Event<float> moveY;

//         protected override void OnStart()
//         {
//             //Get events.
//             moveX = Beak.Get<float>(Constants.MovementX);
//             moveY = Beak.Get<float>(Constants.MovementY);
//         }

//         protected override void RunEffect(MotionFocus focus, Pivot pivot)
//         {
//             //Integer value.
//             int index = (int)focus;

//             var wave = settings[index].Value.Roll;
//             var multipliers = state[index].Value.Roll;

//             var amplitude = wave.GetAmplitude() * 0.1f;
//             var rate = wave.GetRate() * 20f;

//             //Calculate the current amplitude and rate for this frame.
//             var pMovement = new Vector2(moveX.Value, moveY.Value);
//             var cAmplitude = multipliers.Amplitude * pMovement.magnitude * amplitude;
//             var cRate = rate * multipliers.Rate;

//             //Add the velocity.
//             var rVelocity = MathematicUtilities.CalculateNoise(cAmplitude, cRate);
//             pivot.Rotate(rVelocity);
//         }
//     }
// }