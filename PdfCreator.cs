namespace AlpineChough.MultiplicationTableGenerator
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Text;

    /// <summary>
    /// This class represents the PDF creator.
    /// </summary>
    public class PdfCreator
    {
        #region Private Fields

        /// <summary>
        /// The PDF positions.
        /// </summary>
        private readonly int[] pdfPositions = new[]
        {
            6656, 6701, 6746, 6791, 6837, 7104, 7150, 7196, 7242, 7288, 7555,
            7601, 7647, 7693, 7739, 7961, 8006, 8051, 8096, 8142, 8409, 8455,
            8501, 8547, 8593, 8860, 8906, 8952, 8998, 9044, 9266, 9311, 9356,
            9401, 9447, 9714, 9760, 9806, 9852, 9898, 10165, 10211, 10257,
            10303, 10349, 10571, 10616, 10661, 10706, 10752, 11019, 11065, 
            11111, 11157, 11203, 11470, 11516, 11562, 11608, 11654, 11876,
            11921, 11966, 12011, 12057, 12324, 12370, 12416, 12462, 12508,
            12775, 12821, 12867, 12913, 12959, 13181, 13226, 13271, 13316, 
            13362, 13629, 13675, 13721, 13767, 13813, 14080, 14126, 14172,
            14218, 14264, 14486, 14531, 14576, 14621, 14667, 14934, 14980,
            15026, 15072, 15118, 15385, 15431, 15477, 15523, 15569, 15791,
            15836, 15881, 15926, 15972, 16239, 16285, 16331, 16377, 16423,
            16690, 16736, 16782, 16828, 16874, 17096, 17141, 17186, 17231,
            17277, 17544, 17590, 17636, 17682, 17728, 17995, 18041, 18087,
            18133, 18179, 18401, 18446, 18491, 18536, 18582, 18849, 18895,
            18941, 18987, 19033, 19300, 19346, 19392, 19438, 19484, 19706,
            19751, 19796, 19841, 19887, 20154, 20200, 20246, 20292, 20338, 
            20605, 20651, 20697, 20743, 20789, 21011, 21056, 21101, 21146,
            21192, 21459, 21505, 21551, 21597, 21643, 21910, 21956, 22002,
            22048, 22094, 28584, 28629, 28674, 28719, 28765, 29032, 29078,
            29124, 29170, 29216, 29483, 29529, 29575, 29621, 29667, 29889,
            29934, 29979, 30024, 30070, 30337, 30383, 30429, 30475, 30521,
            30788, 30834, 30880, 30926, 30972, 31194, 31239, 31284, 31329,
            31375, 31642, 31688, 31734, 31780, 31826, 32093, 32139, 32185,
            32231, 32277, 32499, 32544, 32589, 32634, 32680, 32947, 32993,
            33039, 33085, 33131, 33398, 33444, 33490, 33536, 33582, 33804,
            33849, 33894, 33939, 33985, 34252, 34298, 34344, 34390, 34436,
            34703, 34749, 34795, 34841, 34887, 35109, 35154, 35199, 35244,
            35290, 35557, 35603, 35649, 35695, 35741, 36008, 36054, 36100,
            36146, 36192, 36414, 36459, 36504, 36549, 36595, 36862, 36908,
            36954, 37000, 37046, 37313, 37359, 37405, 37451, 37497, 37719,
            37764, 37809, 37854, 37900, 38167, 38213, 38259, 38305, 38351,
            38618, 38664, 38710, 38756, 38802, 39024, 39069, 39114, 39159,
            39205, 39472, 39518, 39564, 39610, 39656, 39923, 39969, 40015,
            40061, 40107, 40329, 40374, 40419, 40464, 40510, 40777, 40823,
            40869, 40915, 40961, 41228, 41274, 41320, 41366, 41412, 41634,
            41679, 41724, 41769, 41815, 42082, 42128, 42174, 42220, 42266,
            42533, 42579, 42625, 42671, 42717, 42939, 42984, 43029, 43074,
            43120, 43387, 43433, 43479, 43525, 43571, 43838, 43884, 43930,
            43976, 44022, 50470, 50515, 50560, 50605, 50651, 50918, 50964,
            51010, 51056, 51102, 51369, 51415, 51461, 51507, 51553, 51775,
            51820, 51865, 51910, 51956, 52223, 52269, 52315, 52361, 52407, 
            52674, 52720, 52766, 52812, 52858, 53080, 53125, 53170, 53215,
            53261, 53528, 53574, 53620, 53666, 53712, 53979, 54025, 54071,
            54117, 54163, 54385, 54430, 54475, 54520, 54566, 54833, 54879, 
            54925, 54971, 55017, 55284, 55330, 55376, 55422, 55468, 55690,
            55735, 55780, 55825, 55871, 56138, 56184, 56230, 56276, 56322, 
            56589, 56635, 56681, 56727, 56773, 56995, 57040, 57085, 57130,
            57176, 57443, 57489, 57535, 57581, 57627, 57894, 57940, 57986,
            58032, 58078, 58300, 58345, 58390, 58435, 58481, 58748, 58794,
            58840, 58886, 58932, 59199, 59245, 59291, 59337, 59383, 59605,
            59650, 59695, 59740, 59786, 60053, 60099, 60145, 60191, 60237,
            60504, 60550, 60596, 60642, 60688, 60910, 60955, 61000, 61045,
            61091, 61358, 61404, 61450, 61496, 61542, 61809, 61855, 61901,
            61947, 61993, 62215, 62260, 62305, 62350, 62396, 62663, 62709,
            62755, 62801, 62847, 63114, 63160, 63206, 63252, 63298, 63519,
            63563, 63607, 63651, 63696, 63957, 64002, 64047, 64092, 64137, 
            64398, 64443, 64488, 64533, 64578, 64795, 64839, 64883, 64927,
            64972, 65233, 65278, 65323, 65368, 65413, 65679, 65724, 65769,
            65814, 65859
        };

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public Guid Identifier { get; set; }

        /// <summary>
        /// Gets or sets the multiplications.
        /// </summary>
        /// <value>The multiplications.</value>
        public Multiplication[] Multiplications { get; set; }

        /// <summary>
        /// Gets or sets the symbol.
        /// </summary>
        /// <value>The symbol.</value>
        public string Symbol { get; set; }

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>The path.</value>
        public string Path { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Write the PDF file.
        /// </summary>
        public void Write()
        {
            using (FileStream fileStream = new FileStream(this.Path, FileMode.Create))
            {
                byte[] data = this.ReadEmbeddedResource("Worksheet.pdf");

                byte[] guidBytes = Encoding.ASCII.GetBytes(this.Identifier.ToString());
                for (int i = 0; i < guidBytes.Length; i++)
                {
                    data[0x012b + i] = guidBytes[i];
                }

                guidBytes = Encoding.ASCII.GetBytes(this.Identifier.ToString().Replace("-", string.Empty));
                for (int i = 0; i < guidBytes.Length; i++)
                {
                    data[0x10487 + i] = guidBytes[i];
                    data[0x104a9 + i] = guidBytes[i];
                }

                DateTimeOffset now = DateTimeOffset.Now;
                string nowAsString =
                    now.DateTime.Year.ToString() +
                    now.DateTime.Month.ToString().PadLeft(2, '0') +
                    now.DateTime.Day.ToString().PadLeft(2, '0') +
                    now.DateTime.Hour.ToString().PadLeft(2, '0') +
                    now.DateTime.Minute.ToString().PadLeft(2, '0') +
                    now.DateTime.Second.ToString().PadLeft(2, '0') +
                    "+" + now.Offset.Hours.ToString().PadLeft(2, '0');

                byte[] nowBytes = Encoding.ASCII.GetBytes(nowAsString);
                for (int i = 0; i < nowBytes.Length; i++)
                {
                    data[0x10384 + i] = nowBytes[i];
                    data[0x103a5 + i] = nowBytes[i];
                }

                for (int i = 0; i < this.pdfPositions.Length; i++)
                {
                    string cell = " ";
                    int numbersIndex = (i / 5) * 2;

                    switch (i % 5)
                    {
                        case 0:
                            if (this.Multiplications[numbersIndex / 2].Multiplicand == 10)
                            {
                                cell = "1";
                            }

                            break;
                        case 1:
                            if (this.Multiplications[numbersIndex / 2].Multiplicand == 10)
                            {
                                cell = "0";
                            }
                            else
                            {
                                cell = this.Multiplications[numbersIndex / 2].Multiplicand.ToString();
                            }

                            break;
                        case 2:
                            cell = this.Symbol;
                            break;
                        case 3:
                            if (this.Multiplications[numbersIndex / 2].Multiplier == 10)
                            {
                                cell = "1";
                            }

                            break;
                        case 4:
                            if (this.Multiplications[numbersIndex / 2].Multiplier == 10)
                            {
                                cell = "0";
                            }
                            else
                            {
                                cell = Multiplications[numbersIndex / 2].Multiplier.ToString();
                            }

                            break;
                    }

                    data[this.pdfPositions[i]] = Encoding.ASCII.GetBytes(cell)[0];
                }

                fileStream.Write(data, 0, data.Length);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Reads the embedded resource.
        /// </summary>
        /// <returns>The embedded resource.</returns>
        /// <param name="filename">The filename.</param>
        private byte[] ReadEmbeddedResource(string filename)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            using (Stream stream = assembly.GetManifestResourceStream(filename))
            {
                byte[] buffer = new byte[16 * 1024];
                using (MemoryStream ms = new MemoryStream())
                {
                    int read;
                    while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }

                    return ms.ToArray();
                }
            }
        }

        #endregion
    }
}
