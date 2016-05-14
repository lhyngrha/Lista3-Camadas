using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Persistencia
{
    public class Boletim
    {
        public string arquivo = "C:\\XML\\boletins.xml";

        private void salvarArquivo(List<Modelo.Boletim> boletins)
        {
            StreamWriter sw = new StreamWriter(arquivo);
            XmlSerializer xml = new XmlSerializer(typeof(List<Modelo.Boletim>));
            xml.Serialize(sw, boletins);
            sw.Close();
        }

        private List<Modelo.Boletim> abrirArquivo()
        {
            List<Modelo.Boletim> result = null;
            try
            {
                using (StreamReader sr = new StreamReader(arquivo))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(List<Modelo.Boletim>));
                    result = (List<Modelo.Boletim>)xml.Deserialize(sr);

                }
            }
            catch
            {
                result = new List<Modelo.Boletim>();
            }

            return result;
        }

        public void Insert(Modelo.Boletim b)
        {
            List<Modelo.Boletim> boletins = abrirArquivo();
            boletins.Add(b);
            salvarArquivo(boletins);
        }

        public void Update(Modelo.Boletim b)
        {
            List<Modelo.Boletim> boletins = abrirArquivo();
            Modelo.Boletim x = (from f in boletins where f.Ano == b.Ano && f.IdAluno == b.IdAluno && f.IdDisciplina == b.IdDisciplina select f).Single();
            x.Nota1 = b.Nota1;
            x.Nota2 = b.Nota2;
            x.Nota3 = b.Nota3;
            x.Nota4 = b.Nota4;
            x.MediaParcial = b.MediaParcial;
            x.NotaFinal = b.NotaFinal;
            x.MediaFinal = b.MediaFinal;
            salvarArquivo(boletins);
        }

        public void Delete(Modelo.Boletim b)
        {
            List<Modelo.Boletim> boletins = abrirArquivo();
            Modelo.Boletim x = (from f in boletins where f.Ano == b.Ano && f.IdAluno == b.IdAluno && f.IdDisciplina == b.IdDisciplina select f).Single();
            boletins.Remove(x);
            salvarArquivo(boletins);
        }

        public List<Modelo.Boletim> Select()
        {
            return abrirArquivo();
        }
    }
}
