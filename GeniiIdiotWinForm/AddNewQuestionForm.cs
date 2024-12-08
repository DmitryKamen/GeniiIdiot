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
    public partial class AddNewQuestionForm : Form
    {
        public AddNewQuestionForm()
        {
            InitializeComponent();
        }

        private void AddNewQuestionForm_Load(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var parsed = InputValidator.TryParseToNumber(questionAnswerTextBox.Text, out int userAnswer, out string errorMassage);
            if (!parsed)
            {
                MessageBox.Show(errorMassage);
            }

            var newQuestion = new Question(questionTextBox.Text, userAnswer);
            QuestionsRepository.Add(newQuestion);

            Close();
        }
    }
}
