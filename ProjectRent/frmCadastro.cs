﻿using System;
using System.Windows.Forms;

namespace ProjectRent
{
    public partial class frmCadastro : Form
    {
        public frmCadastro()
        {
            InitializeComponent();
            MessageBox.Show("DATA COM FORMATO INCORRETO PARA INSERIR NO BANCO");
        }

        private void frmCadastro_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Validar campos em branco
            //Retirando as máscaras dos campos para fazer validação
            dateVencimento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            dateInicio.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            dateFim.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            if((txtNome.Text == "") || (txtCPF.Text == "") || (txtCel.Text == "") || (cboxTipo.Text == "") || (!txtValor.MaskCompleted)
                || (dateVencimento.Text == "") || (dateInicio.Text == "") || (dateFim.Text == ""))
            {
                MessageBox.Show("Os campos com * são obrigatório" , "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
            }
            else
            {
                //Retornando a mascara para ser compativel com o datetime
                dateVencimento.TextMaskFormat = MaskFormat.IncludeLiterals;
                dateInicio.TextMaskFormat = MaskFormat.IncludeLiterals;
                dateFim.TextMaskFormat = MaskFormat.IncludeLiterals;
                clsAluguel Aluguel = new clsAluguel();
                //Aluguel.Cod = int.Parse((txtCod.Text));
                Aluguel.Nome = txtNome.Text;
                Aluguel.Rg = txtRG.Text;
                Aluguel.Cpf = txtCPF.Text;
                Aluguel.Cel = txtCel.Text;
                Aluguel.Email = txtEmail.Text;
                Aluguel.Tipo = cboxTipo.Text;
                Aluguel.Num = txtNumLocal.Text;
                Aluguel.DataInicio = DateTime.Parse(dateInicio.Text).Date;
                Aluguel.DataFim = DateTime.Parse(dateFim.Text).Date;
                Aluguel.Valor = double.Parse(txtValor.Text);
                Aluguel.Vencimento = DateTime.Parse(dateVencimento.Text).Date;
                if (checkAgua.Checked)
                {
                    Aluguel.Agua = 1;
                }
                else
                {
                    Aluguel.Agua = 0;
                }
                if(checkEletricidade.Checked)
                {
                    Aluguel.Eletricidade = 1;
                }
                else
                {
                    Aluguel.Eletricidade = 0;
                }
                if (checkGaragem.Checked)
                {
                    Aluguel.Garagem = 1;
                }
                else
                {
                    Aluguel.Garagem = 0;
                }
                if (checkInternet.Checked)
                {
                    Aluguel.Net = 1;
                }
                else
                {
                    Aluguel.Net = 0;
                }
                
                if (txtCod.Text == "") //NOVO
                {
                    Aluguel.GravarBanco();
                    MessageBox.Show("Inquilino registrado com sucesso." , "Novo inquilino", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtCod.Text != "") //Alterar
                {
                    Aluguel.AlterarBanco();
                    MessageBox.Show("Dados do inquilino alterados com sucesso.", "Alteração de dados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //Close();
            }
        }

        private void checkAgua_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkEletricidade_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void checkInternet_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkGaragem_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
