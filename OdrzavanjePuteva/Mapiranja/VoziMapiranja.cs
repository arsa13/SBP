using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using OdrzavanjePuteva.Entiteti;

namespace odrzavanjePuteva.Mapiranja
{
    class VoziMapiranja : ClassMap<Vozi>
    {
        public VoziMapiranja()
        {
            Table("KORISTE");

            Id(x => x.IdKoriste, "ID_KORISTE").GeneratedBy.TriggerIdentity();

            Map(x => x.Pocetak, "POCETAK");

            Map(x => x.Kraj, "KRAJ");


            References(x => x.Vozilo).Column("ID_VOZILA");

            References(x => x.Nadzornik).Column("ID_NADZORNIKA");
        }
    }
}
