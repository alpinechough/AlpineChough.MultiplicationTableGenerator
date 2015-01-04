namespace AlpineChough.MultiplicationTableGenerator
{
    using System;

    /// <summary>
    /// This class represents the setup.
    /// </summary>
    public class Setup
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AlpineChough.MultiplicationTableGenerator.Setup"/> class.
        /// </summary>
        public Setup()
        {
            this.Identifier = Guid.NewGuid();

            this.Matrix = new bool[11][];
            for (int i = 0; i < 11; i++)
            {
                this.Matrix[i] = new bool[11];
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>The path.</value>
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public Guid Identifier { get; set; }

        /// <summary>
        /// Gets or sets the symbol.
        /// </summary>
        /// <value>The symbol.</value>
        public string Symbol { get; set; }

        /// <summary>
        /// Gets or sets the multipliers and multiplicands.
        /// </summary>
        /// <value>The matrix.</value>
        public bool[][] Matrix { get; set; }

        #endregion
    }
}
