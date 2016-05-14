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
    /// Interaction logic for Curso.xaml
    /// </summary>
    public partial class Curso : Window
    {
        public Curso()
        {
            InitializeComponent();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            Modelo.Curso x = new Modelo.Curso();
            x.Id = int.Parse(txtId.Text);
            x.Descricao = txtDesc.Text;
            Negocio.Curso c = new Negocio.Curso();
            c.Insert(x);

            /*new Negocio.Curso().Insert(new Modelo.Curso
            {
                Id = int.Parse(txtID.Text),
                Descricao = txtDesc.Text
            });*/
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            /*Modelo.Curso x = new Modelo.Curso();
            x.Id = int.Parse(txtId.Text);
            x.Descricao = txtDesc.Text;
            Negocio.Curso c = new Negocio.Curso();
            c.Update(x);*/

            new Negocio.Curso().Update(new Modelo.Curso { Id = int.Parse(txtId.Text), Descricao = txtDesc.Text });

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            new Negocio.Curso().Delete(new Modelo.Curso { Id = int.Parse(txtId.Text), Descricao = txtDesc.Text });
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = new Negocio.Curso().Select();
        }
    }
}
