using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Aluno
    {
        public void Insert(Modelo.Aluno a)
        {
            List<Modelo.Aluno> alunos = Select();
            if (!alunos.Exists(z => z.Id == a.Id) && alunos.Exists(z=> z.IdCurso == z.IdCurso))
            {
                Persistencia.Aluno p = new Persistencia.Aluno();
                p.Insert(a);
            }
        }

        public void Update(Modelo.Aluno d)
        {
            List<Modelo.Aluno> alunos = Select();
            if (alunos.Exists(z => z.Id == d.Id))
            {
                Persistencia.Aluno p = new Persistencia.Aluno();
                p.Update(d);
            }
        }

        public void Delete(Modelo.Aluno d)
        {
            List<Modelo.Aluno> alunos = Select();
            if (alunos.Exists(z => z.Id == d.Id))
            {
                Persistencia.Aluno p = new Persistencia.Aluno();
                p.Delete(d);
            }
        }

        public List<Modelo.Aluno> Select()
        {
            return (new Persistencia.Aluno().Select());
        }
    }
}
