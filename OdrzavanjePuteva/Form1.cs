using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using OdrzavanjePuteva.Entiteti;
using OdrzavanjePuteva.Mapiranja;

namespace OdrzavanjePuteva
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                OdrzavanjePuteva.Entiteti.Vozilo p = s.Load<OdrzavanjePuteva.Entiteti.Vozilo>(4);

                MessageBox.Show(p.Boja);


                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.Izvrsilac p = new Entiteti.Izvrsilac();

                p.Adresa = "Rasinska 11";
                p.DatumPostavljanja = DateTime.Today;
                p.Ime = "Marko";
                p.Jmbg = "1103397685418";
                p.Prezime = "Jovic";
                //p.Tip_Radnika = "izvrsilac";
                p.Specijalnost = "mostogradnja";
                p.Id_Nadredjenog = 1;
                p.Godina_Rodj = "1997";
                p.Ime_Oca = "Stevan";
                

                OdrzavanjePuteva.Entiteti.Deonica d = s.Load<OdrzavanjePuteva.Entiteti.Deonica>(3);
                p.Deonice.Add(d);

                OdrzavanjePuteva.Entiteti.Vozilo v = s.Load<OdrzavanjePuteva.Entiteti.Vozilo>(4);
                Upravlja u = new Upravlja();
                u.Pocetak = DateTime.Today;
                u.Kraj = DateTime.Today;

                u.Izvrsilac = p;
                u.Vozilo = v;
                p.UpravljaVozilima.Add(u);

              

                s.Save(p);

                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s1 = DataLayer.GetSession();

                Putnicka o = s1.Load<Putnicka>(1);


                o.TipGoriva = "kerozin";

                s1.Update(o);

                s1.Flush();
                s1.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                ISession s = DataLayer.GetSession();

                ISQLQuery q = s.CreateSQLQuery("SELECT 0.* FROM RADNIK R ");
                q.AddEntity(typeof(Radnik));
                IList<Radnik> radnici = q.List<Radnik>();

                foreach(Radnik r in radnici)
                {
                    MessageBox.Show(r.Adresa);
                }

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }
    }
}
