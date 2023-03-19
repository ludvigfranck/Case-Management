using Case_Management_Submission_Task.MVVM.Models;
using Case_Management_Submission_Task.MVVM.ViewModels;
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

namespace Case_Management_Submission_Task.MVVM.Views
{
    public partial class EditCasesView : UserControl
    {
        public EditCasesView()
        {
            InitializeComponent();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext is EditCasesViewModel viewModel)
            {
                var _selectedCase = viewModel.SelectedCase;

                if (_selectedCase != null)
                {
                    tb_status.Text = _selectedCase.CaseStatus;
                    tb_time.Text = _selectedCase.Time.ToString();
                    tb_description.Text = _selectedCase.CaseDescription;
                    tb_comment.Text = _selectedCase.CaseComment;
                    if(_selectedCase.CaseStatus == "Pending")
                        rb_pending.IsChecked = true;
                    else if(_selectedCase.CaseStatus == "Assigned")
                        rb_assigned.IsChecked = true;
                }
            }
        }
    }
}
