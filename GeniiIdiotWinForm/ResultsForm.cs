using GeniiIdiot.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeniiIdiotWinForm
{
    public partial class ResultsForm : Form
    {
        public ResultsForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ResultsForm_Load(object sender, EventArgs e)
        {
            var managerResult = new FileManager("results.txt");

            var resultLst = UsersResultRepository.GetUsersResults(managerResult.GetFileInformation());
            foreach (var result in resultLst)
            {
                dataGridView1.Rows.Add(result.Name, result.RightAnswers,result.Diagnose);
            }
        }
    }
}
