namespace AlpineChough.MultiplicationTableGenerator
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Threading;
    using Xwt;

    /// <summary>
    /// The main class.
    /// </summary>
    public static class MainClass
    {
        #region Private Properties

        /// <summary>
        /// Gets the path of the application's temporary folder.
        /// </summary>
        /// <value>The temporary folder.</value>
        private static string TemporaryFolder
        {
            get
            {
                return Path.Combine(Path.GetTempPath(), "AlpineChough.MultiplicationTableGenerator");
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        public static void Main()
        {
            Setup setup = new Setup();

            if (!Directory.Exists(TemporaryFolder))
            {
                Directory.CreateDirectory(TemporaryFolder);
            }

            try
            {
                Application.Initialize();

                using (MainWindow mainWindow = new MainWindow(setup))
                {
                    mainWindow.ApplicationExitRequested += (object sender, EventArgs e) =>
                    {
                        Application.Exit();
                    };

                    mainWindow.GenerateWorksheetRequested += (object sender, EventArgs e) =>
                    {
                        CreatePdf(setup);
                    };

                    mainWindow.Show();
                    Application.Run();
                }
            }
            finally
            {
                foreach (string file in Directory.GetFiles(TemporaryFolder))
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch
                    {
                    }
                }

                try
                {
                    Directory.Delete(TemporaryFolder);
                }
                catch
                {
                }
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates the PDF document.
        /// </summary>
        /// <param name="setup">The setup.</param>
        private static void CreatePdf(Setup setup)
        {
            setup.Path = Path.Combine(TemporaryFolder, "Worksheet_" + DateTime.Now.ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture) + ".pdf");
            setup.Identifier = Guid.NewGuid();
            setup.Symbol = ".";

            PdfCreator pdfCreator = new PdfCreator();
            pdfCreator.Identifier = setup.Identifier;
            pdfCreator.Multiplications = MultiplicationFactory.Create(setup);
            pdfCreator.Symbol = setup.Symbol;
            pdfCreator.Path = setup.Path;
            pdfCreator.Write();

            Process.Start(setup.Path);
        }

        #endregion
    }
}
