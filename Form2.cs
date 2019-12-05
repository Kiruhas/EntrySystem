using System;
using System.Windows.Forms;

namespace ProgramForGarazhFinal
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void PeopleBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.peopleBindingSource.EndEdit();     // автосозданная панель сохранения элементов (отключена в форме)
            this.tableAdapterManager.UpdateAll(this.garazhDataSet);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "garazhDataSet.People". При необходимости она может быть перемещена или удалена.
            this.peopleTableAdapter.Fill(this.garazhDataSet.People);

        }
    }
}
