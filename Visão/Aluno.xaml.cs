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

namespace Visão
{
    /// <summary>
    /// Interaction logic for Aluno.xaml
    /// </summary>
    public partial class Aluno : Window
    {
        public Aluno()
        {
            InitializeComponent();
            SelectCursos();
            
        }

        private void SelectCursos()
        {
            var r = new Negocio.Curso().Select();
            comboBox.ItemsSource = r.ToList();
            comboBox.SelectedValuePath = "Id";
            comboBox.DisplayMemberPath = "Descricao";
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            new Negocio.Aluno().Insert(new Modelo.Aluno
            {
                Id = int.Parse(txtId.Text),
                Nome = txtNome.Text,
                Email = txtEmail.Text,
                Fone = txtFone.Text,
                Nascimento = Convert.ToDateTime(datapicekr.SelectedDate),
                IdCurso = Convert.ToInt16(comboBox.SelectedItem)
            
            }
                );
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = new Negocio.Aluno().Select();
        }
    }
}
