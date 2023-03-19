using Case_Management_Submission_Task.MVVM.ViewModels;
using Case_Management_Submission_Task.Services;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


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
