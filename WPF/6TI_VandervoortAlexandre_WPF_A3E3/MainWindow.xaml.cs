using System;
using System.Collections.Generic;
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

namespace _6TI_VandervoortAlexandre_WPF_A3E3
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// 
    /// https://github.com/Ascynx/clueless/blob/main/src/main/java/com/github/ascynx/clueless/features/queries/equations/ShuntingYardImpl.java#L54
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Stack<string> _equation = new();


        public MainWindow()
        {
            InitializeComponent();

            OneButton.Click += EquationButton_Click;
            TwoButton.Click += EquationButton_Click;
            ThreeButton.Click += EquationButton_Click;
            FourButton.Click += EquationButton_Click;
            FiveButton.Click += EquationButton_Click;
            SixButton.Click += EquationButton_Click;
            SevenButton.Click += EquationButton_Click;
            EightButton.Click += EquationButton_Click;
            NineButton.Click += EquationButton_Click;

            CommaButton.Click += EquationButton_Click;
            PlusButton.Click += EquationButton_Click;
            MinusButton.Click += EquationButton_Click;
            DivideButton.Click += EquationButton_Click;
            MultiplyButton.Click += EquationButton_Click;

            ResetButton.Click += ResetButton_Click;
            EqualButton.Click += EqualButton_Click;
        }

        private void EquationButton_Click(object sender, RoutedEventArgs e)
        {
            _equation.TryPeek(out string v);
            if (v == null)
            {
                v = " ";
            }

            string lastType = GetTypeOfChar(v.First());
            string endType = GetTypeOfChar(v.Last());

            if (e.Source is Button button && button.Content is string content)
            {
                _equation.Push(content);

                string type = GetTypeOfChar(content.First());
                if ((lastType == "number" && type == lastType) || (endType == "comma" && type == "number") || (lastType == "number" && type == "comma")) //TODO fonctionne pas quand ça suit une virgule
                {
                    string t = "";
                    t += _equation.Pop();
                    t += _equation.Pop();


                    //fusionne les deux.
                    _equation.Push(t);
                }
            }
            Update();
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            OutputBlock.Text = "" + EvaluateExpression();
        }

        private void Update()
        {
            string output = "";

            string[] copieEquation = new string[_equation.Count];
            _equation.CopyTo(copieEquation, 0);
            for (int i = copieEquation.Length - 1; i >= 0; i--)
            {
                output += copieEquation[i]; //TODO inverser les nombres
            }

            OutputBlock.Text = output.Trim();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            _equation.Clear();
            Update();
        }

        private static float EvaluateExpression()
        {
            float? num1 = null;
            float? num2 = null;
            string? op = null;

            while (_equation.TryPeek(out _))
            {
                string v = _equation.Pop();
                string type = GetTypeOfChar(v.First());
                if (type == "number")
                {
                    int num = int.Parse("" + v);
                    if (num2 == null)
                    {
                        if (op == "minus")
                        {
                            num2 = -num;
                            op = null;
                        } else
                        {
                            num2 = num;
                        }
                    } else if (op == null && num1 == null)
                    {
                        num2 += num;
                    } else if (num1 == null)
                    {
                        num1 = num;
                    } else
                    {
                        throw new Exception("Trouvé 3 nombres les uns à coté des autres dans le stack.");
                    }
                } else
                {
                    if (op == null)
                    {
                        op = type;
                    } else
                    {
                        if (type == "minus")
                        {
                            if (op == "plus")
                            {
                                op = "minus";
                            } else if (op == "minus")
                            {
                                op = "plus";
                            }
                        }
                    }
                }

                if (num1 != null && op != null)
                {
                    float resultat = AppliqueOperateur(op, num1.Value, num2.Value);
                    op = null;
                    num1 = null;
                    num2 = resultat;
                }
            }

            if (num2 == null)
            {
                throw new Exception("Pas réussi à évaluer cette expression.");
            }

            return num2.Value;
        }

        private static string GetTypeOfChar(char c)
        {
            if (c == '1' || c == '2' || c == '3' || c == '4' || c == '5' || c == '6' || c == '7' || c == '8' || c == '9' || c == '0')
            {
                return "number";
            }

            if (c == '*')
            {
                return "multiply";
            }
            if (c == '/')
            {
                return "divide";
            }
            if (c == '+')
            {
                return "plus";
            }
            if (c == '-')
            {
                return "minus";
            }
            if (c == ',')
            {
                return "comma";
            }
            return "UNKNOWN";
        }

        public static float AppliqueOperateur(string type, float f1, float f2)
        {

            switch (type)
            {
                case "plus":
                    {
                        return f1 + f2;
                    };
                case "minus":
                    {
                        return f1 - f2;
                    }
                case "divide":
                    {
                        return f1 / f2;
                    }
                case "multiply":
                    {
                        return f1 * f2;
                    }
                default:
                    {
                        return 0;
                    }
            };
        }
    }
}
