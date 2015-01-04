namespace AlpineChough.MultiplicationTableGenerator
{
    using System;
    using System.Collections.Generic;
    using Xwt;

    /// <summary>
    /// The main window.
    /// </summary>
    public class MainWindow : Window
    {
        #region Private Fields

        /// <summary>
        /// The multiplier and multiplicand checkboxes.
        /// </summary>
        private CheckBox[][] checkboxes = null;

        /// <summary>
        /// The worksheet setup.
        /// </summary>
        private Setup setup = null;

        #endregion

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AlpineChough.MultiplicationTableGenerator.MainWindow"/> class.
        /// </summary>
        /// <param name="setup">The setup.</param>
        public MainWindow(Setup setup)
        {
            this.checkboxes = new CheckBox[11][];
            for (int i = 0; i < 11; i++)
            {
                this.checkboxes[i] = new CheckBox[11];
            }

            this.setup = setup;

            this.Title = "Multiplication Table Generator";
            this.Content = this.CreateContent();
        }

        #endregion

        #region Public Events

        /// <summary>
        /// Occurs when a application exit is requested.
        /// </summary>
        public event EventHandler<EventArgs> ApplicationExitRequested;

        /// <summary>
        /// Occurs when a worksheet generation is requested.
        /// </summary>
        public event EventHandler<EventArgs> GenerateWorksheetRequested;

        #endregion

        #region Protected Methods

        /// <summary>
        /// Raises the application exit requested event.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected virtual void OnApplicationExitRequested(EventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException("e");
            }

            if (this.ApplicationExitRequested != null)
            {
                this.ApplicationExitRequested(this, e);
            }
        }

        /// <summary>
        /// Raises the application exit requested event.
        /// </summary>
        protected void OnApplicationExitRequested()
        {
            this.OnApplicationExitRequested(EventArgs.Empty);
        }

        /// <summary>
        /// Raises the close requested event.
        /// </summary>
        /// <returns>True, if close should be executed, otherwise false.</returns>
        protected override bool OnCloseRequested()
        {
            this.OnApplicationExitRequested();
            return false;
        }

        /// <summary>
        /// Raises the generate requested event.
        /// </summary>
        protected void OnGenerateRequested()
        {
            this.OnGenerateRequested(EventArgs.Empty);
        }

        /// <summary>
        /// Raises the generate requested event.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected void OnGenerateRequested(EventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException("e");
            }

            if (this.GenerateWorksheetRequested != null)
            {
                bool nothingSelected = true;

                for (int multiplicand = 0; multiplicand < 11; multiplicand++)
                {
                    for (int multiplier = 0; multiplier < 11; multiplier++)
                    {
                        nothingSelected &= this.checkboxes[multiplicand][multiplier].State == CheckBoxState.Off;
                        this.setup.Matrix[multiplicand][multiplier] = this.checkboxes[multiplicand][multiplier].State == CheckBoxState.On;
                    }
                }

                if (nothingSelected)
                {
                    return;
                }

                this.GenerateWorksheetRequested(this, e);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates the content.
        /// </summary>
        /// <returns>The content.</returns>
        private Widget CreateContent()
        {
            VBox vbox = new VBox();

            Table table = new Table();

            for (int multiplier = 1; multiplier < 12; multiplier++)
            {
                Label lblx = new Label((multiplier - 1).ToString());
                int multiplierCopy = multiplier;
                lblx.ButtonPressed += (sender, e) => this.SelectAllMultiplier(multiplierCopy - 1);
                table.Add(lblx, multiplier, 0, 1, 1, true, true, WidgetPlacement.Center);
            }

            for (int multiplicand = 1; multiplicand < 12; multiplicand++)
            {
                Label lbly = new Label((multiplicand - 1).ToString());
                int multiplicandCopy = multiplicand;
                lbly.ButtonPressed += (sender, e) => this.SelectAllMultiplicands(multiplicandCopy - 1);
                table.Add(lbly, 0, multiplicand);

                for (int multiplier = 1; multiplier < 12; multiplier++)
                {
                    CheckBox checkBox = new CheckBox();
                    this.checkboxes[multiplier - 1][multiplicand - 1] = checkBox;
                    checkBox.TooltipText = string.Format("{0} · {1} = ?", multiplier - 1, multiplicand - 1);
                    table.Add(checkBox, multiplier, multiplicand);
                }
            }

            vbox.PackStart(table);

            HBox bottonBox = new HBox();
            bottonBox.HorizontalPlacement = WidgetPlacement.End;

            Button clearButton = new Button("Clear");
            clearButton.Clicked += (object sender, EventArgs e) => this.ClearSelections();
            bottonBox.PackStart(clearButton);

            Button generateButton = new Button("Generate");
            generateButton.Clicked += (object sender, EventArgs e) => this.OnGenerateRequested();
            bottonBox.PackStart(generateButton);

            vbox.PackEnd(bottonBox);

            return vbox;
        }

        /// <summary>
        /// Selects all multiplicands.
        /// </summary>
        /// <param name="multiplicand">The Multiplicands.</param>
        private void SelectAllMultiplicands(int multiplicand)
        {
            bool allSelected = true;
            for (int i = 0; i < 11; i++)
            {
                allSelected &= this.checkboxes[i][multiplicand].State == CheckBoxState.On;
            }

            for (int i = 0; i < 11; i++)
            {
                this.checkboxes[i][multiplicand].State = allSelected ? CheckBoxState.Off : CheckBoxState.On;
            }
        }

        /// <summary>
        /// Selects all multiplier.
        /// </summary>
        /// <param name="multiplier">The multiplier.</param>
        private void SelectAllMultiplier(int multiplier)
        {
            bool allSelected = true;
            for (int i = 0; i < 11; i++)
            {
                allSelected &= this.checkboxes[multiplier][i].State == CheckBoxState.On;
            }

            for (int i = 0; i < 11; i++)
            {
                this.checkboxes[multiplier][i].State = allSelected ? CheckBoxState.Off : CheckBoxState.On;
            }
        }

        /// <summary>
        /// Clears the selections.
        /// </summary>
        private void ClearSelections()
        {
            for (int multiplicand = 0; multiplicand < 11; multiplicand++)
            {
                for (int multiplier = 0; multiplier < 11; multiplier++)
                {
                    this.checkboxes[multiplicand][multiplier].State = CheckBoxState.Off;
                }
            }
        }
        
        #endregion
    }
}
