using UnityEngine;

namespace Helpers
{
    public static class ColorAccuracy
    {
        /// <summary>
        /// Calculates how accurate the player's color choice is compared to the customer's request.
        /// </summary>
        /// <param name="playerColor">The color the player selected</param>
        /// <param name="customerColor">The color the customer requested</param>
        /// <returns>Accuracy score from 0 to 100 (100 = perfect match)</returns>
        public static float CalculateAccuracy(Color playerColor, Color customerColor)
        {
            // Convert to HSV for better color matching perception
            Color.RGBToHSV(playerColor, out float playerH, out float playerS, out float playerV);
            Color.RGBToHSV(customerColor, out float customerH, out float customerS, out float customerV);

            // Calculate differences
            float hueDiff = Mathf.Abs(playerH - customerH);
            // Handle hue wraparound (0 and 1 are the same color)
            if (hueDiff > 0.5f) hueDiff = 1f - hueDiff;
            
            float satDiff = Mathf.Abs(playerS - customerS);
            float valDiff = Mathf.Abs(playerV - customerV);

            // Weight the components (hue is most important for color recognition)
            float hueWeight = 0.6f;
            float satWeight = 0.2f;
            float valWeight = 0.2f;

            // Calculate weighted distance
            float totalDistance = (hueDiff * hueWeight) + (satDiff * satWeight) + (valDiff * valWeight);
            
            // Convert to accuracy percentage (0-100)
            float accuracy = Mathf.Clamp01(1f - totalDistance) * 100f;
            
            return accuracy;
        }

        /// <summary>
        /// Alternative RGB-based accuracy calculation (simpler but less perceptually accurate)
        /// </summary>
        /// <param name="playerColor">The color the player selected</param>
        /// <param name="customerColor">The color the customer requested</param>
        /// <returns>Accuracy score from 0 to 100 (100 = perfect match)</returns>
        public static float CalculateAccuracyRGB(Color playerColor, Color customerColor)
        {
            // Calculate RGB distance
            float rDiff = Mathf.Abs(playerColor.r - customerColor.r);
            float gDiff = Mathf.Abs(playerColor.g - customerColor.g);
            float bDiff = Mathf.Abs(playerColor.b - customerColor.b);

            // Use weighted RGB (human eyes are more sensitive to green)
            float distance = (rDiff * 0.3f) + (gDiff * 0.59f) + (bDiff * 0.11f);
            
            // Convert to accuracy percentage
            float accuracy = Mathf.Clamp01(1f - distance) * 100f;
            
            return accuracy;
        }
    }
}
