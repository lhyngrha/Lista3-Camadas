using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Persistencia
{
    public class Curso
    {
        //Responsabilidade de armazenar as ações da camada de Negocios, escrita dos dados
        private string arquivo = "C:\\XML\\cursos.xml";

        public List<Modelo.Curso> Select()
        {
            return abrirArquivo();
        }

        public void Insert(Modelo.Curso c)
        {
            List<Modelo.Curso> cursos = abrirArquivo();
            cursos.Add(c);
            salvarArquivo(cursos);
        }

        private List<Modelo.Curso> abrirArquivo()
        {
            List<Modelo.Curso> result = null;
            try
            {
                using (StreamReader sr = new StreamReader(arquivo))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(List<Modelo.Curso>));
                    result = (List<Modelo.Curso>)xml.Deserialize(sr);
                }
            }
            catch
            {
                result = new List<Modelo.Curso>();
            }
            return result;
        }

        private void salvarArquivo(List<Modelo.Curso> cursos)
        {
            StreamWriter sw = new StreamWriter(arquivo);
            XmlSerializer xml = new XmlSerializer(typeof(List<Modelo.Curso>));
            xml.Serialize(sw, cursos);
            sw.Close();
        }

        public void Update(Modelo.Curso c)
        {
            List<Modelo.Curso> curso = abrirArquivo();
            Modelo.Curso x = (from f in curso where f.Id == c.Id select f).Single();
            x.Descricao = c.Descricao;
            salvarArquivo(curso);
            
        }

        public void Delete(Modelo.Curso c)
        {
            //Logica
            List<Modelo.Curso> curso = abrirArquivo();
            Modelo.Curso x = (from f in curso where f.Id == c.Id select f).Single();
            curso.Remove(x);
            salvarArquivo(curso);
            
        }
    }
}
