using Case_Management_Submission_Task.MVVM.Models;
using Case_Management_Submission_Task.MVVM.ViewModels;
using Case_Management_Submission_Task.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Case_Management_Submission_Task.MVVM.Views
{
    public partial class CustomersView : UserControl
    {
        public CustomersView()
        {
            InitializeComponent();            
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext is CustomersViewModel viewModel)
            {
                var _selectedCustomer = viewModel.SelectedCustomer;
                if (_selectedCustomer != null)
                {
                    tb_firstName.Text = _selectedCustomer.FirstName;
                    tb_lastName.Text = _selectedCustomer.LastName;
                    tb_email.Text = _selectedCustomer.Email;
                    tb_phoneNumber.Text = _selectedCustomer.PhoneNumber;
                    tb_streetName.Text = _selectedCustomer.StreetName;
                    tb_postalCode.Text = _selectedCustomer.PostalCode;
                    tb_city.Text = _selectedCustomer.City;
                }
            }
        }
    }
}
