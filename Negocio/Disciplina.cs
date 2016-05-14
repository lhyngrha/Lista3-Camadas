using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Disciplina
    {
        private void Insert(Modelo.Disciplina d)
        {
            //Pega a lista já criada, usando Select(), definido na Persistencia
            List<Modelo.Disciplina> disciplinas = Select();
            //Verifica se o id já foi escolhido antes
            if (!disciplinas.Exists(a => a.Id == d.Id))
            {
                //Cria uma instancia de Persistencia Disciplina
                Persistencia.Disciplina p = new Persistencia.Disciplina();
                //Insere disciplina utilizando a instancia de Persistencia
                p.Insert(d);
            }
        }

        private List<Modelo.Disciplina> Select()
        {
            return (new Persistencia.Disciplina()).Select();
        }

        private void Update(Modelo.Disciplina d)
        {
            List<Modelo.Disciplina> disciplinas = Select();
            if (disciplinas.Exists(a => a.Id == d.Id))
            {
                Persistencia.Disciplina p = new Persistencia.Disciplina();
                p.Update(d);
            }
        }

        private void Delete(Modelo.Disciplina d)
        {
            List<Modelo.Disciplina> disciplinas = Select();
            if (disciplinas.Exists(a => a.Id == d.Id))
            {
                Persistencia.Disciplina p = new Persistencia.Disciplina();
                p.Delete(d);
            }
        }


        
    }
}
