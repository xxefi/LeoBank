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

namespace LeoBank.Views
{
    /// <summary>
    /// Логика взаимодействия для PayBalanceView.xaml
    /// </summary>
    public partial class PayBalanceView : UserControl
    {
        public PayBalanceView()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string text = textBox.Text;

            text = text.Replace(" ", "");

            if (text.Length > 4 && text.Length % 4 == 0 )
            {
                StringBuilder newText = new();
                for ( int i = 0; i < text.Length; i++ )
                {
                    newText.Append(text[i]);
                    if ((i + 1) % 4 == 0 && i != text.Length - 1)
                    {
                        newText.Append(' ');
                    }
                }
                textBox.Text = newText.ToString();
                textBox.CaretIndex = textBox.Text.Length;
            }
        }

        private void card_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string text = textBox.Text;

            text = text.Replace(" ", "");

            int maxLength = 16;

            if (text.Length >= maxLength)
            {
                e.Handled = true;
            }
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string text = textBox.Text;

            text = new string(text.Where(char.IsDigit).ToArray());


            if (text.Length == 4)
            {
                textBox.Text = $"{text.Substring(0, 2)}/{text.Substring(2)}";
                textBox.CaretIndex = textBox.Text.Length;
            }
            else if (text.Length > 2 && text.Length % 2 == 0)
            {
                StringBuilder newText = new();
                for (int i = 0; i < text.Length; i++)
                {
                    newText.Append(text[i]);
                    if ((i + 1) % 2 == 0 && i != text.Length - 1)
                    {
                        newText.Append("/");
                    }
                }
                textBox.Text = newText.ToString();
                textBox.CaretIndex = textBox.Text.Length;
            }
            
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string text = textBox.Text;
            int maxLength = 5;

            if (text.Length >= maxLength)
            {
                e.Handled = true;
            }
        }

        private void PasswordBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            PasswordBox passwordBox = (PasswordBox)sender;
            string text = passwordBox.Password;
            

            int maxLength = 3;

            if (text.Length >= maxLength)
            {
                e.Handled = true;
            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            {
                ((dynamic)this.DataContext).CVV = ((PasswordBox)sender).Password;
            }
        }
    }
}
