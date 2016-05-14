using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Boletim
    {
        public void Insert(Modelo.Boletim b)
        {
            List<Modelo.Boletim> boletins = Select();
            if(!boletins.Exists(a=> a.Ano == b.Ano) && !boletins.Exists(a=> a.IdAluno == b.IdAluno) && !boletins.Exists(a=> a.IdDisciplina == b.IdDisciplina))
            {
                Persistencia.Boletim p = new Persistencia.Boletim();
                p.Insert(b);
            }
        }

        public void Delete(Modelo.Boletim b)
        {
            List<Modelo.Boletim> boletins = Select();
            if (boletins.Exists(a => a.Ano == b.Ano) && boletins.Exists(a => a.IdAluno == b.IdAluno) && boletins.Exists(a => a.IdDisciplina == b.IdDisciplina))
            {
                Persistencia.Boletim p = new Persistencia.Boletim();
                p.Delete(b);
            }
        }

        public List<Modelo.Boletim> Select()
        {
            return(new Persistencia.Boletim()).Select();
        }

        public void Update(Modelo.Boletim b)
        {
            List<Modelo.Boletim> boletins = Select();
            if (boletins.Exists(a => a.Ano == b.Ano) && boletins.Exists(a => a.IdAluno == b.IdAluno) && boletins.Exists(a => a.IdDisciplina == b.IdDisciplina))
            {
                Persistencia.Boletim p = new Persistencia.Boletim();
                p.Update(b);
            }
        }
    }
}
