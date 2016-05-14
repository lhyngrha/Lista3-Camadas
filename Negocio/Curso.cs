using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Curso
    {
        //Responsável pelas regras de negócio. Intermediário entre a visão e o acesso de dados
        public void Insert(Modelo.Curso c)
        {
            List<Modelo.Curso> curso = Select();
            if (!curso.Exists(a => a.Id == c.Id))
            {
                Persistencia.Curso p = new Persistencia.Curso();
                p.Insert(c);
            }
        }

        public List<Modelo.Curso> Select()
        {
            return (new Persistencia.Curso()).Select();
        }

        public void Update(Modelo.Curso c)
        {
            List<Modelo.Curso> curso = Select();
            if (curso.Exists(a => a.Id == c.Id))
            {
                Persistencia.Curso p = new Persistencia.Curso();
                p.Update(c);
            }
        }

        public void Delete(Modelo.Curso c)
        {
            List<Modelo.Curso> curso = Select();
            if (curso.Exists(a => a.Id == c.Id))
            {
                Persistencia.Curso p = new Persistencia.Curso();
                //Metodo que eu criei
                p.Delete(c);
            }
        }

    }
}
