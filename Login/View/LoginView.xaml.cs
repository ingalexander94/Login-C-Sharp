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
using System.Windows.Shapes;
using Login.Controller;
using Login.Model.DTO;

namespace Login.View
{
    /// <summary>
    /// Lógica de interacción para LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {

        AuthController AuthController = new AuthController();

        public LoginView()
        {
            InitializeComponent();
            txtUser.Focus();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ToRegister_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            RegisterView rv = new RegisterView
            {
                Owner = this
            };
            Hide();
            rv.ShowDialog();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtUser.Text.Length == 0 || txtPass.Password.Length == 0)
            {
                MessageBox.Show("Complete el formulario", "Atención", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtUser.Focus();
            }
            else
            {
                UserDTO User = AuthController.Login(txtUser.Text, txtPass.Password);
                if(User == null)
                {
                    MessageBox.Show("Los datos son incorrectos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtUser.Focus();
                } else
                {
                    ResetForm();
                    MessageBox.Show("Bienvenido", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            
        }

        private void ResetForm()
        {
            txtUser.Text = "";
            txtPass.Password = "";
        }

    }
}