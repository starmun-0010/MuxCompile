using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Compiler.Common;
using Compiler.ParserGenerator;

namespace Compiler.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var text = File.ReadAllText(
              $@"{System.IO.Path.Combine($@"{Directory.GetCurrentDirectory()}", @"../../../")}\Expression Grammer.json");
            IGrammarReader reader = new JsonGrammerReader();
            IGrammar grammar = reader.Read(text);
            grammar.Initialize();

            var parserGenerator = new SLRParserGenerator(grammar);


            var parseTable = parserGenerator.GenerateParser();
            Ptv.DataContext = parseTable;
        }
    }
}
