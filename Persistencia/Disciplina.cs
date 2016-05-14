using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Persistencia
{
    public class Disciplina
    {
        private string arquivo = "C:\\XML\\disciplinas.xml";

        public void Insert(Modelo.Disciplina d)
        {
            //Abre a lista já criada
            List<Modelo.Disciplina> disciplinas = abrirArquivo();
            //Adiciona a lista o objeto 
            disciplinas.Add(d);
            //Salvar o arquivo com o objeto inserido
            salvarArquivo(disciplinas);
        }

        public List<Modelo.Disciplina> Select()
        {
            //retorna a lista
            return abrirArquivo();
        }

        public void Update(Modelo.Disciplina d)
        {
            //Abre a lista já criada
            List<Modelo.Disciplina> disciplinas = abrirArquivo();
            //Procura o arquivo que possui o id que deseja atualizar
            Modelo.Disciplina x = (from f in disciplinas where f.Id == d.Id select f).Single();
            //Atualiza as informações
            x.Descricao = d.Descricao;
            //Salva o arquivo com as informações novas
            salvarArquivo(disciplinas);
        }

        public void Delete(Modelo.Disciplina d)
        {
            List<Modelo.Disciplina> disciplinas = abrirArquivo();
            Modelo.Disciplina x = (from f in disciplinas where f.Id == d.Id select f).Single();
            disciplinas.Remove(x);
            salvarArquivo(disciplinas);
        }

        private void salvarArquivo(List<Modelo.Disciplina> d)
        {
            //Cria arquivo de texto
            StreamWriter sw = new StreamWriter(arquivo);
            //Instancia arquivo XML
            XmlSerializer xml = new XmlSerializer(typeof(List<Modelo.Disciplina>));
            //Serializa o segundo e escreve em um Stream
            xml.Serialize(sw, d);
            sw.Close();
        }

        private List<Modelo.Disciplina> abrirArquivo()
        {
            List<Modelo.Disciplina> result = null;
            //Try usado para verificar se o arquivo já existe
            try
            {
                //Instancia para ler arquivo de texto
                using (StreamReader sr = new StreamReader(arquivo))
                {
                    //Instancia de arquivo XML
                    XmlSerializer xml = new XmlSerializer(typeof(List<Modelo.Disciplina>));
                    //Lista em formato List após deserializar arquivo Stream
                    result = (List<Modelo.Disciplina>)xml.Deserialize(sr);
                }
            }
            catch
            {
                result = new List<Modelo.Disciplina>();
            }
            //retorno da Lista
            return result;
        }
    }
}
