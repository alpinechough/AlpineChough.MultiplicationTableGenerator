namespace AlpineChough.MultiplicationTableGenerator
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// This static class provides methods to creates multiplications.
    /// </summary>
    public static class MultiplicationFactory
    {
        #region Public Methods

        /// <summary>
        /// Creates all multiplications (shuffled) according to specified setup.
        /// </summary>
        /// <param name="setup">The setup.</param>
        /// <returns>All multiplications (shuffled).</returns>
        public static Multiplication[] Create(Setup setup)
        {
            List<Multiplication> multiplications = new List<Multiplication>();

            int n = 0;
            while (multiplications.Count < 108)
            {
                List<Multiplication> m = CreateSorted(setup);
                Shuffle(m, setup.Identifier.GetHashCode() + n++);
                multiplications.AddRange(m);
            }

            return multiplications.ToArray();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates all multiplications (sorted) according to specified setup.
        /// </summary>
        /// <param name="setup">The setup.</param>
        /// <returns>All multiplications (sorted).</returns>
        private static List<Multiplication> CreateSorted(Setup setup)
        {
            List<Multiplication> result = new List<Multiplication>();

            for (int multiplicand = 0; multiplicand < 11; multiplicand++)
            {
                for (int multiplier = 0; multiplier < 11; multiplier++)
                {
                    if (setup.Matrix[multiplicand][multiplier])
                    {
                        Multiplication multiplication = new Multiplication();
                        multiplication.Multiplicand = multiplicand;
                        multiplication.Multiplier = multiplier;
                        result.Add(multiplication);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Shuffle the specified list using the specified seed.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="seed">The seed.</param>
        private static void Shuffle(List<Multiplication> list, int seed)
        {  
            Random random = new Random(seed);  
            for (int n = list.Count - 1; n > 0; n--)
            {  
                int k = random.Next(n + 1);  
                Multiplication value = list[k];  
                list[k] = list[n];  
                list[n] = value;  
            }  
        }

        #endregion
    }
}
