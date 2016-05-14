using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Persistencia
{
    public class Aluno
    {
        public string arquivo = "C:\\XML\\alunos.xml";

        private List<Modelo.Aluno> abrirArquivo()
        {
            List<Modelo.Aluno> result = null;
            try
            {
                using (StreamReader sw = new StreamReader(arquivo))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(List<Modelo.Aluno>));
                    result = (List<Modelo.Aluno>)xml.Deserialize(sw);
                }
            }
            catch
            {
                result = new List<Modelo.Aluno>();
            }

            return result;
        }

        private void salvarArquivo(List<Modelo.Aluno> alunos)
        {
            StreamWriter sw = new StreamWriter(arquivo);
            XmlSerializer xml = new XmlSerializer(typeof(List<Modelo.Aluno>));
            xml.Serialize(sw, alunos);
            sw.Close();
        }

        public void Insert(Modelo.Aluno a)
        {
            List<Modelo.Aluno> alunos = abrirArquivo();
            alunos.Add(a);
            salvarArquivo(alunos);
        }

        public void Update(Modelo.Aluno a)
        {
            List<Modelo.Aluno> alunos = abrirArquivo();
            Modelo.Aluno x = (from f in alunos where f.Id == a.Id select f).Single();
            x.Nome = a.Nome;
            x.Email = a.Email;
            x.Fone = a.Fone;
            x.Nascimento = a.Nascimento;
            x.IdCurso = a.IdCurso;
            salvarArquivo(alunos);
        }

        public void Delete(Modelo.Aluno a)
        {
            List<Modelo.Aluno> alunos = abrirArquivo();
            Modelo.Aluno x = (from f in alunos where f.Id == a.Id select f).Single();
            alunos.Remove(x);
            salvarArquivo(alunos);
        }

        public List<Modelo.Aluno> Select()
        {
            return abrirArquivo();
        }
    }
}
