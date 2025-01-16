using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForml3iage
{
    public partial class Form1 : Form
    {
        Personne personne = new Personne();
        List<Personne> list = new List<Personne>();
        private readonly object personneselected;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

       

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
         
          

            personne.prenom = txtPrenom.Text;
            personne.nom = txtNom.Text;
            personne.tel = txtTel.Text;
            if (rbFemme.Checked)
            {
                personne.sexe = "Femme";
            }
            else
            {
                personne.sexe = "Homme";
            }
            string tempocomp = "";

            if (ckbJAVA.Checked)
            {
                tempocomp += "JAVA";
            }

            if (ckbPHP.Checked)
            {
                tempocomp += "PHP";
            }

            if (ckbCsharp.Checked)
            {
                tempocomp += "C#";
            }

            if (ckbCplusplus.Checked)
            {
                tempocomp += "C++";
            }

            personne.competences = tempocomp;
            personne.classe = cmbClasse.Text;

            //save data in list
            list.Add(personne);
            MessageBox.Show("donnees ajoute", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //chargement du datagrid view
            refresh();

            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
            effacer();
        }
        private void effacer()
        {
            txtNom.Text = string.Empty;
            txtTel.Text = string.Empty;
            txtPrenom.Text = string.Empty;

            rbFemme.Checked = false;
            rbHomme.Checked = false;

            ckbCplusplus.Checked = false;
            ckbCsharp.Checked = false;
            ckbJAVA.Checked = false;
            ckbPHP.Checked = false;
            cmbClasse.Text = "selectionner";




        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            effacer();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Personne personneselected = null;
            if (e.RowIndex >= 0 && e.RowIndex < list.Count)
            {
                personneselected = list[e.RowIndex];
                txtNom.Text = personneselected.nom;
                txtPrenom.Text=personneselected.prenom;


                if (personneselected.sexe=="Femme") 
                {
                    rbFemme.Checked = true;
                }else
                {
                    rbHomme.Checked = true;
                }

                string[] langue = personneselected.competences.Split();


                ckbCplusplus.Checked = langue.Contains("C++");
                ckbCsharp.Checked = langue.Contains("Csharp");
                ckbJAVA.Checked = langue.Contains("JAVA");
                ckbPHP.Checked = langue.Contains("PHP");

                cmbClasse.Text = personneselected.classe;
            }
        }

        private void txtPrenom_TextChanged(object sender, EventArgs e)
        {

        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (personneselected == null)
            {
                MessageBox.Show("verifier que vous avez slectionner" , "Avertissement" , MessageBoxButtons.OK);

            }
            else
            {
                DialogResult result = MessageBox.Show("voulez vous confirmer la suppression", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    list.Remove(personneselected);
                    refresh();
                    effacer();
             

                }
            }
        }
        public void refresh()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = list;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (personneselected == null)
            {
                MessageBox.Show("verifier que vous avez slectionner", "Avertissement", MessageBoxButtons.OK);

            }
            else
            {
                personneselected.tel = TxtTel.text;
                personneselected.nom = TxtNom.text;
                personneselected.prenom = TxtPrenom.text;

                personneselected.sexe = (rbFemme.Checked) ? "Femme" : "Homme";

                string tempocomp = "";

                if (ckbJAVA.Checked)
                {
                    tempocomp += "JAVA";
                }

                if (ckbPHP.Checked)
                {
                    tempocomp += "PHP";
                }

                if (ckbCsharp.Checked)
                {
                    tempocomp += "C#";
                }

                if (ckbCplusplus.Checked)
                {
                    tempocomp += "C++";
                }

                personne.competences = tempocomp;
                personne.classe = cmbClasse.Text;

                list[pos]=personneselected;
                refresh();
                effacer();

            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
    }
}
