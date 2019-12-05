using System;
using System.Windows.Forms;

namespace ProgramForGarazhFinal
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            peopleBindingSource.Filter = "Dept > 0"; // отображает собственников из БД только имеющих долг
        }

        private void PeopleBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.peopleBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.garazhDataSet);

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "garazhDataSet.People". При необходимости она может быть перемещена или удалена.
            this.peopleTableAdapter.Fill(this.garazhDataSet.People);

        }
    }
}
